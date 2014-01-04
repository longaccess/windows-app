using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ThriftInterface
{
    class InterfaceImpl : ThriftInterface.CLI.Iface
    {
        public InterfaceImpl()
        {
            initDummyState();
        }
        public List<Capsule> Capsules;
        public List<Archive> Archives;
        public List<Certificate> Certificates;
        private string certFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public void initDummyState()
        {
            Capsules = new List<Capsule>();
            for (int i = 0; i < 5; i++)
            {
                var capsule = new Capsule()
                {
                    ID = Guid.NewGuid().ToString(),
                    AvailableSizeInBytes = 1000*1024*1024,
                    ExpirationDate = new DateInfo(DateTime.Today),
                    Title = "Capsule" + i,
                    TotalSizeInBytes =(long) 2 * 1024 * 1024 * 1024 
                };
                capsule.CapsuleContents = new List<ArchiveInfo>();
                for (int j = 0; j < 10; j++)
                {
                    var content = new ArchiveInfo()
                    {
                        Title = "Title" + j,
                        Description = "Description " + j,
                        SizeInBytes = j * 10 * 1024 * 1024,
                        CreatedDate = new DateInfo(DateTime.Today.AddDays(-1 - j))
                    };
                    capsule.CapsuleContents.Add(content);
                }
                Capsules.Add(capsule);
            }
            Archives = new List<Archive>();
            for (int i = 0; i < 5; i++)
            {
                var archive = new Archive() { LocalID = Guid.NewGuid().ToString(), Status = ArchiveStatus.InProgress };
                var content = new ArchiveInfo()
                {
                    Title = "Title" + i,
                    Description = "Description " + i,
                    SizeInBytes = i * 10 * 1024 * 1024,
                    CreatedDate = new DateInfo(DateTime.Today.AddDays(-1 - i))
                };
                archive.Info = content;
                Archives.Add(archive);
            }
            Certificates = new List<Certificate>();
            for (int i = 0; i < 5; i++)
            {
                var content = new ArchiveInfo()
                {
                    Title = "Title" + i,
                    Description = "Description " + i,
                    SizeInBytes = i * 10 * 1024 * 1024,
                    CreatedDate = new DateInfo(DateTime.Today.AddDays(-1 - i))
                };
                var cert = new Certificate() { RelatedArchive = content };

                Certificates.Add(cert);
            }
            DummySettings.ArchivesFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            DummySettings.CertificatesFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        }

        public string GetCertificateFolder()
        {
            return certFolder;
        }

        public string GetarchivesFolder()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        public void SetCertificateFolder(string path)
        {
            certFolder = path;
        }

        public string GetDefaultExtractionPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        public void Decrypt(string archivePath, string key, string destinationPath)
        {
            //nothing here
        }

        //=============================================================
        bool CLI.Iface.PingCLI()
        {
            return true;
        }
        bool LoggedIn = false;
        bool CLI.Iface.LoginUser(string username, string Pass, bool Remember)
        {
            if (!(username == "a" & Pass == "a"))
            {
                LoggedIn = false;
                throw new ThriftInterface.InvalidOperation() { What = ErrorType.Authentication, Why = "Credentials.." };
                return false;
            }
            LoggedIn = true;
            return true;
        }

        bool CLI.Iface.UserIsLoggedIn()
        {
            return LoggedIn;
        }

        bool CLI.Iface.Logout()
        {
            return true;
        }

        List<Capsule> CLI.Iface.GetCapsules()
        {
            return Capsules;
        }

        Archive CLI.Iface.CreateArchive(List<string> filePaths)
        {
            System.Threading.Thread.Sleep(4000);
            var arch = new Archive() { LocalID = Guid.NewGuid().ToString(), Status = ArchiveStatus.InProgress };
            var info = new ArchiveInfo() { CreatedDate = new DateInfo(DateTime.Today), SizeInBytes = 500 * 1024 * 1024 };
            arch.Info = info;
            Archives.Add(arch);
            return arch;
        }

        List<Archive> CLI.Iface.GetUploads()
        {
            return Archives;
        }

        void CLI.Iface.UploadToCapsule(string ArchiveLocalID, string CapsuleID, string title, string description)
        {
            var caps = Capsules.First(c => c.ID == CapsuleID);
            var arch = Archives.First(a => a.LocalID == ArchiveLocalID);
            caps.CapsuleContents.Add(arch.Info);
        }

        void CLI.Iface.ResumeUpload(string ArchiveLocalID)
        {
            Archives.First(ar => ar.LocalID == ArchiveLocalID).Status = ArchiveStatus.InProgress;
        }
        Random rnd = new Random();
        TransferStatus CLI.Iface.QueryArchiveStatus(string ArchiveLocalID)
        {
            return new TransferStatus() { Progress = rnd.NextDouble(), ETA = "oo", StatusDescription = "goood" };
        }

        void CLI.Iface.PauseUpload(string ArchiveLocalID)
        {
            Archives.First(ar => ar.LocalID == ArchiveLocalID).Status = ArchiveStatus.Paused;
        }

        void CLI.Iface.CancelUpload(string ArchiveLocalID)
        {
            Archives.First(ar => ar.LocalID == ArchiveLocalID).Status = ArchiveStatus.Stopped;
        }

        List<Certificate> CLI.Iface.GetCertificates()
        {
            return Certificates;
        }

        byte[] CLI.Iface.ExportCertificate(string ArchiveID, CertExportFormat format)
        {
            return new byte[10];
        }

        void CLI.Iface.Decrypt(string archivePath, string key, string destinationPath)
        {
            //ok
        }
        private Settings DummySettings = new Settings();
        Settings CLI.Iface.GetSettings()
        {
            return DummySettings;
        }

        void CLI.Iface.SetSettings(Settings settings)
        {
            this.DummySettings = settings;
        }


        void CLI.Iface.CloseWhenPossible()
        {
            //nothing here
        }
    }
}
