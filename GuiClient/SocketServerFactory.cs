using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Thrift.Transport;
namespace GuiClient
{
    class SocketServerFactory : ServerFactory
    {
        int[] PortsTotry;
        string AppPath;
        private int CurrentPort;       
        public SocketServerFactory(int[] portsTotry, string appPath)
        {
            this.PortsTotry = portsTotry;
            this.AppPath = appPath;
        }
        protected override System.Diagnostics.Process GetProcess()
        {
            string args = "-d 4 --batch --home " +
                  InQuotes(AppDataPath) +
                   " server --port " + CurrentPort.ToString();
            return GetProcessHelper(AppPath, args, (ProcArgs) => ProcArgs.Contains(args));
        }

        protected override Thrift.Transport.TTransport GetTransport()
        {
            return new TFramedTransport(new TSocket("localhost", CurrentPort));
        }

        protected override int NumberOfTrials
        {
            get { return PortsTotry.Length; }
        }

        protected override void NextTrial()
        {
            CurrentPort = PortsTotry[TrialsCnt];           
        }
    }
}
