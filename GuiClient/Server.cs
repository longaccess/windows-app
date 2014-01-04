using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using Thrift.Protocol;
using Thrift.Transport;
using ThriftInterface;
using System.Management;

namespace GuiClient
{
    class ThriftFacade
    {

        private static string CliPath
        {
            get
            {
               
                var currrentPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                return System.IO.Path.Combine(currrentPath, @"lacli\lacli.exe");
            }
        }
        string CliPathDummy = @"D:\Dropbox\Job\LongAccess\DummyCLI\bin\Debug\DummyCLI.exe";
        private static string CliProcName
        {
            get
            {
                return System.IO.Path.GetFileNameWithoutExtension(CliPathDummy);
            }
        }
        private static int[] PortArray = new int[] { 9090, 9091, 9092 };
        private static Process CliProc;
        private static CLI.Iface Cli;
        public static CLI.Iface GetCLI()
        {
            if (Cli == null)//|| TryPingTheServer() == false)
            {
                Cli = SetupCli();
            }            
            return Cli;
        }
        private static void DummySetup()
        {
            Cli = new InterfaceImpl();
        }
        private static CLI.Iface SetupCli()
        {
            bool ServerResponded = false;
            foreach (var port in PortArray)
            {
                TTransport transport =new TFramedTransport( new TSocket("localhost", port));
                CliProc = GetCLIProcess(port);
                TProtocol protocol = new TBinaryProtocol(transport);
                var tempCli = new CLI.Client(protocol);
                transport.Open();
                ServerResponded = TryPingTheServer(tempCli);
                if (ServerResponded)
                {
                    return tempCli;
                }
                else
                {
                    CliProc.Kill();
                }
            }
            return null;
        }
        static Exception PingException;
        private static bool TryPingTheServer(CLI.Iface cli)
        {
            try
            {
                cli.PingCLI();
                return true;
            }
            catch (Exception e)
            {
                PingException = e;  
                return false;
            }
        }
        private static object Locker = new object();
        private static Process GetCLIProcess(int port)
        {

            string appDataPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "LongAccess");
            if (!System.IO.Directory.Exists(appDataPath))
            {
                System.IO.Directory.CreateDirectory(appDataPath);
            }
            lock (Locker)
            {
                var RunningProcs = GetRelevantProcesses(CliProcName);
                foreach (var RunningProc in RunningProcs)
                {
                    if (!RunningProc.Process.HasExited && RunningProc.CommandLine.Contains(port.ToString()))
                    {
                        return RunningProc.Process;
                    }
                    else
                    {
                        RunningProc.Process.Kill();
                    }
                }

                ProcessStartInfo ProcInfo = new ProcessStartInfo(CliPath, "--batch --home " +
                  InQuotes(appDataPath) +
                   " server --port " + port.ToString());
                //ProcInfo.CreateNoWindow = true;
                //ProcInfo.WindowStyle = ProcessWindowStyle.Hidden;
                Process tempCliProc = new Process();
                tempCliProc.StartInfo = ProcInfo;
                try
                {
                    tempCliProc.Start();
                }
                catch (Exception)
                {
                    throw new ApplicationException("The command line interface application needed can not be started");
                }
                System.Windows.Forms.Application.ApplicationExit += Application_ApplicationExit;

                System.Threading.Thread.Sleep(100);
                return tempCliProc;
            }
        }


        static void Application_ApplicationExit(object sender, EventArgs e)
        {
            Cli.CloseWhenPossible();
        }
        private static string InQuotes(string input)
        {
            return "\"" + input + "\"";
        }
        private static ProcessWithProps[] GetRelevantProcesses(string ProcNameToSearch)
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

    }
    public struct ProcessWithProps
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
