using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Thrift.Protocol;
using Thrift.Transport;
using ThriftInterface;
using System.Management;
using System.Diagnostics;
namespace GuiClient
{
    abstract class ServerFactory
    {       
        protected CLI.Iface CliInstance;
        public CLI.Iface GetCLI()
        {
            bool works = CliIsWorking();
            if (!works)
            {
                CliInstance = CreateCli();
            }
            return CliInstance;
        }
        private static object Locker = new object();
        protected string AppDataPath
        {
            get
            {
                return System.IO.Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "LongAccess");
            }
        }
        protected int TrialsCnt { get; set; }
        protected int PingTimeOut = 5000;
        private CLI.Iface CreateCli()
        {

            if (!System.IO.Directory.Exists(AppDataPath))
            {
                System.IO.Directory.CreateDirectory(AppDataPath);
            }           
            lock (Locker)
            {
                CLI.Iface tempCli = null;
                TrialsCnt = 0;
                var ExceptionList = new List<Exception>();
                bool cliIsWorking = false;
                do
                {
                    NextTrial();
                    try
                    {
                        
                        Process CliProc = GetProcess();
                        TTransport transport = GetTransport();
                        TProtocol protocol = new TBinaryProtocol(transport);
                        tempCli = null;// new ProxyToBackEnd(new CLI.Client(protocol), false);
                        cliIsWorking = TryOpenAndPingUntilTimeOut(tempCli, transport);

                    }
                    catch (Exception e)
                    {
                        ExceptionList.Add(e);
                        cliIsWorking = false;
                    }
                    TrialsCnt++;
                } while (TrialsCnt < NumberOfTrials && !cliIsWorking);
                if (tempCli == null)
                {
                    throw new Exception("Background app could not be initialized");
                }
                return tempCli;
            }
        }       
        

        private bool TryOpenAndPingUntilTimeOut(CLI.Iface cli, TTransport transport)
        {
            Exception ex = null;
            var watch = new Stopwatch();
            watch.Start();
            while (watch.ElapsedMilliseconds < PingTimeOut)
            {
                try
                {
                    transport.Open();
                    return cli.PingCLI();
                }
                catch (Exception e)
                {
                    ex = e;
                }
            }
            watch.Stop();
            throw ex;
        }
        protected abstract Process GetProcess();
        protected Process GetProcessHelper(string AppPath, string Args, Func<string, bool> ArgumentsAreRelevant)
        {
            var CliProcName = System.IO.Path.GetFileNameWithoutExtension(AppPath);
            var RunningProcs = GetRelevantProcesses(CliProcName);
            foreach (var RunningProc in RunningProcs)
            {
                bool argsAreOk=ArgumentsAreRelevant(RunningProc.CommandLine);
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
            Logger.WriteLine("Started new process. "+RunningProcs.Length +" running procs were found");
            return tempCliProc;
        }
        protected string InQuotes(string input)
        {
            return "\"" + input + "\"";
        }
        protected abstract TTransport GetTransport();
        protected abstract int NumberOfTrials
        {
            get;
        }
        protected abstract void NextTrial();

        private bool CliIsWorking()
        {
            if (CliInstance == null)
            {
                return false;
            }
            else
            {
                try
                {

                    return CliInstance.PingCLI();
                }
                catch (Exception e)
                {
                    Logger.WriteLine("Regular Ping failed: "+e.Message);
                    return false;
                }
            }
        }

        protected bool throws(Action code)
        {
            try
            {
                code();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
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
    }
}
