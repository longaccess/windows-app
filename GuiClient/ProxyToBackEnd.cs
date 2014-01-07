using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThriftInterface;
using System.Diagnostics;
using System.Threading;
using System.Management;
using Thrift.Protocol;
using Thrift.Transport;

namespace GuiClient
{
    class ProxyToBackEnd : CLI.Iface
    {
        private CLI.Iface Wrapped;

        private int TotalTimeLimit = 60000;
        private int NumberOfTrials = 3;
        private int DelayBetweenFailedCalls = 500;
        private int PingTimeOut = 12000;
        private string BackendPath;
        public ProxyToBackEnd(string BackendPath)
        {
            this.BackendPath = BackendPath;


        }
        private string GetArguments(int port)
        {
            return "-d 4 --batch --home " +
                  "\"" + AppDataPath + "\"" +
                   " server --port " + port.ToString();
        }

        //- StartNewBackEnd
        //  - Do
        //    - Find available port.
        //    - Kill previous process if found
        //    - start new process. Log it.
        //    - Test connection. Log error or success
        //  - Until success or enough trials.
        //  - If no success throw
        //    "If the backend cannot be started these is not much we can do."
        //- call to a thrift function wrapper
        //  - Log call
        //  - Do
        //    - Do
        //      - Log trial to call the thrift function.
        //      - Try call actual thrift function
        //      - Log error or success
        //      - Save returned value.
        //      - If success
        //        - log return
        //        - return  to caller
        //          "It returns and so exits or loops"
        //      - If error is thrift specific??
        //        "Go as usual or throw it? decide later."
        //    - Until enough trials or time-out
        //    - StartNewBackEnd
        //  - Until timeout
        //  - Throw exception
        //    "No success..."
        protected string AppDataPath
        {
            get
            {
                return System.IO.Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "LongAccess");
            }
        }
        protected struct ProcessWithProps
        {
            public ProcessWithProps(Process Process, string CommandLine, string Path)
            {
                this.Process = Process;
                this.CommandLine = CommandLine;
                this.Path = Path;
            }
            public Process Process;
            public string CommandLine;
            public string Path;
        }
        protected ProcessWithProps[] GetRelevantProcesses(string ProcNameToSearch)
        {
            string wmiQueryString = "SELECT ProcessId, ExecutablePath, CommandLine FROM Win32_Process";

            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(wmiQueryString))
            {
                using (ManagementObjectCollection results = searcher.Get())
                {
                    IEnumerable<ProcessWithProps> query = from p in Process.GetProcesses()
                                                          join mo in results.Cast<ManagementObject>()
                                                          on p.Id equals Convert.ToInt32(Convert.ToUInt32(mo["ProcessId"]))
                                                          where p.ProcessName.Contains(ProcNameToSearch)//, StringComparison.InvariantCultureIgnoreCase)
                                                          select new ProcessWithProps(p, (string)mo["CommandLine"], (string)mo["ExecutablePath"]);
                    return query.ToArray();
                }
            }
        }
        private bool TryOpenAndPingUntilTimeOut(CLI.Iface cli, TTransport transport, int Timeout)
        {

            Exception ex = null;
            var watch = new Stopwatch();
            watch.Start();
            while (watch.ElapsedMilliseconds < Timeout)
            {
                try
                {
                    transport.Open();
                    var res = cli.PingCLI();
                    return res;
                }
                catch (Exception e)
                {
                    ex = e;
                }
            }
            watch.Stop();
            throw ex;
        }
        int[] AvailablePorts = new int[] { 9090, 9091, 9092 };
        private static object Locker = new object();
        protected Process GetProcessHelper(string AppPath, string Args)
        {
            var CliProcName = System.IO.Path.GetFileNameWithoutExtension(AppPath);
            var RunningProcs = GetRelevantProcesses(CliProcName);
            foreach (var RunningProc in RunningProcs)
            {
                bool argsAreOk = RunningProc.CommandLine.Contains(Args);
                if (!RunningProc.Process.HasExited && argsAreOk)
                {
                    //RunningProc.Process.OutputDataReceived += CliProc_OutputDataReceived;
                    //RunningProc.Process.ErrorDataReceived += CliProc_OutputDataReceived;
                    Logger.WriteLine("Found and used running process");
                    return RunningProc.Process;
                }
                else
                {
                    RunningProc.Process.Kill();
                }
            }
            ProcessStartInfo ProcInfo = new ProcessStartInfo(AppPath, Args);
            //ProcInfo.CreateNoWindow = true;
            //ProcInfo.WindowStyle = ProcessWindowStyle.Hidden;
            Process tempCliProc = new Process();
            tempCliProc.StartInfo = ProcInfo;
            //tempCliProc.OutputDataReceived += CliProc_OutputDataReceived;
            //tempCliProc.ErrorDataReceived += CliProc_OutputDataReceived;
            tempCliProc.Start();
            Logger.WriteLine("Started new process. " + RunningProcs.Length + " running procs were found");
            return tempCliProc;
        }
        private void StartNewBackEnd(long Timeout)
        {
            SaveToLog("Starting new Process");
            if (!System.IO.Directory.Exists(AppDataPath))
            {
                System.IO.Directory.CreateDirectory(AppDataPath);
            }

            backendInitialized = false;
            Exception ex = null;
            int counter = 0;
            CLI.Iface tempCli = null;
            var sw = Stopwatch.StartNew();
            do
            {
                try
                {
                    int port = AvailablePorts[counter];
                    //    - Kill previous process if found
                    var procs = GetRelevantProcesses(System.IO.Path.GetFileNameWithoutExtension(BackendPath));
                    foreach (var proc in procs)
                    {
                        proc.Process.Kill();
                    }
                    //    - start new process. Log it.
                    ProcessStartInfo ProcInfo = new ProcessStartInfo(BackendPath, GetArguments(port));
                    Process tempCliProc = new Process();
                    tempCliProc.StartInfo = ProcInfo;
                    tempCliProc.Start();

                    TTransport transport = new TFramedTransport(new TSocket("localhost", port));
                    TProtocol protocol = new TBinaryProtocol(transport);
                    tempCli = new CLI.Client(protocol);
                    

                    backendInitialized = TryOpenAndPingUntilTimeOut(tempCli, transport, PingTimeOut);
                    Wrapped = tempCli;
                }
                catch (Exception e)
                {
                    SaveToLog("On starting new proc: " + e.Message);
                    ex = e;
                }
                counter++;
            } while (!backendInitialized && sw.ElapsedMilliseconds < Timeout & counter < AvailablePorts.Length - 1);
            if (!backendInitialized)
            {
                throw new Exception("Unable to start the back-end application and communicate with it", ex);
            }
            SaveToLog("Started new Process");
        }




        private bool backendInitialized;
        private TRet Wrapper<TRet>(Func<TRet> func, string name)
        {
            int Calls = 0;
            SaveToLog(name + " outer Called");
            var stopWatch = Stopwatch.StartNew();
            Exception ex;
            lock (Locker)
            {
                if (!backendInitialized)
                {
                    StartNewBackEnd(TotalTimeLimit-stopWatch.ElapsedMilliseconds);
                }
            }
            do
            {
                do
                {
                    SaveToLog(name + " thrift function called");
                    TRet returnValue;
                    var sw = System.Diagnostics.Stopwatch.StartNew();
                    try
                    {
                        Calls++;
                        lock (Locker)
                        {
                            returnValue = func();
                        }                        
                        sw.Stop();
                        SaveToLog(name + " returned " + returnValue.ToString() + ", after " + sw.ElapsedMilliseconds);
                        return returnValue;
                    }
                    catch (Exception e)
                    {
                        sw.Stop();

                        ex = e;
                        if (e.GetType() == typeof(ThriftInterface.InvalidOperation))
                        {

                            var thriftex = (InvalidOperation)e;
                            SaveToLog(name + " throwed thrift ex \"" + thriftex.What + ", " + thriftex.Why + "\", after " + sw.ElapsedMilliseconds);
                            throw;
                        }
                        else
                        {
                            SaveToLog(name + " throwed \"" + e.Message + "\", after " + sw.ElapsedMilliseconds);
                        }

                        //Wait a little before trying again.
                        if (sw.ElapsedMilliseconds < DelayBetweenFailedCalls)
                        {
                            Thread.Sleep(DelayBetweenFailedCalls - (int)sw.ElapsedMilliseconds);
                        }
                    }
                } while (stopWatch.ElapsedMilliseconds < TotalTimeLimit && Calls <= NumberOfTrials);
                //lock (Locker)
                //{
                //    StartNewBackEnd(TotalTimeLimit - stopWatch.ElapsedMilliseconds);
                //}
            } while (stopWatch.ElapsedMilliseconds < TotalTimeLimit);
            throw new Exception("Unable to communicate with the back-end application", ex);
        }

        private struct VoidStruct
        {
            public static VoidStruct Empty()
            {
                return new VoidStruct();
            }
            public override string ToString()
            {
                return "";
            }
        }
        private void SaveToLog(string Name)
        {
            Logger.WriteLine(Name + ", at thread " + Thread.CurrentThread.ManagedThreadId);
        }
        public void InitializeBackend()
        {
            var temp = PingTimeOut;
            PingTimeOut = 30000;
            StartNewBackEnd(90000);
        }
        #region ThriftCalls
        
        bool CLI.Iface.PingCLI()
        {
            return Wrapper(() => Wrapped.PingCLI(), "PingCLI");
        }

        void CLI.Iface.CloseWhenPossible()
        {
            if (backendInitialized)
            {
                Wrapper(() => { Wrapped.CloseWhenPossible(); return VoidStruct.Empty(); }, "CloseWhenPossible");
            }
        }

        bool CLI.Iface.LoginUser(string username, string Pass, bool Remember)
        {
            return Wrapper(() => Wrapped.LoginUser(username, Pass, Remember), "LoginUser");
        }

        bool CLI.Iface.UserIsLoggedIn()
        {
            return Wrapper(() => Wrapped.UserIsLoggedIn(), "UserIsLoggedIn");
        }

        bool CLI.Iface.Logout()
        {
            return Wrapper(() => Wrapped.Logout(), "Logout");
        }

        List<Capsule> CLI.Iface.GetCapsules()
        {
            return Wrapper(() => Wrapped.GetCapsules(), "GetCapsules");
        }

        Archive CLI.Iface.CreateArchive(List<string> filePaths)
        {
            return Wrapper(() => Wrapped.CreateArchive(filePaths), "CreateArchive");
        }

        List<Archive> CLI.Iface.GetUploads()
        {
            return Wrapper(() => Wrapped.GetUploads(), "GetUploads");
        }

        void CLI.Iface.UploadToCapsule(string ArchiveLocalID, string CapsuleID, string title, string description)
        {
            Wrapper(() => { Wrapped.UploadToCapsule(ArchiveLocalID, CapsuleID, title, description); return VoidStruct.Empty(); }, "UploadToCapsule");
        }

        void CLI.Iface.ResumeUpload(string ArchiveLocalID)
        {
            Wrapper(() => { Wrapped.ResumeUpload(ArchiveLocalID); return VoidStruct.Empty(); }, "ResumeUpload");
        }

        TransferStatus CLI.Iface.QueryArchiveStatus(string ArchiveLocalID)
        {
            return Wrapper(() => Wrapped.QueryArchiveStatus(ArchiveLocalID), "QueryArchiveStatus");
        }

        void CLI.Iface.PauseUpload(string ArchiveLocalID)
        {
            Wrapper(() => { Wrapped.ResumeUpload(ArchiveLocalID); return VoidStruct.Empty(); }, "PauseUpload");
        }

        void CLI.Iface.CancelUpload(string ArchiveLocalID)
        {
            Wrapper(() => { Wrapped.ResumeUpload(ArchiveLocalID); return VoidStruct.Empty(); }, "CancelUpload");
        }

        List<Certificate> CLI.Iface.GetCertificates()
        {
            return Wrapper(() => Wrapped.GetCertificates(), "GetCertificates");
        }

        byte[] CLI.Iface.ExportCertificate(string ArchiveID, CertExportFormat format)
        {
            return Wrapper(() => Wrapped.ExportCertificate(ArchiveID, format), "ExportCertificate");
        }

        void CLI.Iface.Decrypt(string archivePath, string key, string destinationPath)
        {
            Wrapper(() => { Wrapped.Decrypt(archivePath, key, destinationPath); return VoidStruct.Empty(); }, "Decrypt");
        }

        Settings CLI.Iface.GetSettings()
        {
            return Wrapper(() => Wrapped.GetSettings(), "GetSettings");
        }

        void CLI.Iface.SetSettings(Settings settings)
        {
            Wrapper(() => { Wrapped.SetSettings(settings); return VoidStruct.Empty(); }, "SetSettings");
        }
        public VersionInfo GetLatestVersion()
        {
            return Wrapper(() => Wrapped.GetLatestVersion(), "GetLatestVersion");
        }

        public VersionInfo GetVersion()
        {
           return Wrapper(() => Wrapped.GetVersion(), "GetVersion");
        }
        #endregion

       
    }
}
