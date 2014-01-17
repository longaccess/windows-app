using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using ThriftInterface;
namespace GuiClient
{
    enum TabPages : int
    {
        Signin = 0,
        Upload = 1,
        Decrypt = 2,
        Navigation = 3,
        Certificates = 4,
        Uploads = 5
    }
    public partial class MainForm : Form
    {
        #region helpers
        private static string ReleaseCliPath
        {
            get
            {
                var currrentPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                return System.IO.Path.Combine(currrentPath, @"lacli\lacli.exe");
            }
        }
        static string TestCLIPath = @"D:\Dropbox\lacli\kouk\lacli\lacli.exe";
        static string CliPathDummy = @"D:\Dropbox\Job\LongAccess\DummyCLI\bin\Debug\DummyCLI.exe";
        //private ServerFactory Server = new SocketServerFactory(new int[] { 9090, 9091, 9092 }, ReleaseCliPath);
        private ProxyToBackEnd proxy = new ProxyToBackEnd(ReleaseCliPath);
        private ThriftInterface.CLI.Iface Cli
        {
            get { return proxy; }
        }
        private Properties.Settings AppSettings
        {
            get
            {
                return Properties.Settings.Default;
            }
        }
        private ThriftInterface.Settings CliSettings
        {
            get
            {
                return Cli.GetSettings();
            }
        }
        private void BindData<T>(IEnumerable<T> data, BindingSource bs, ListControl control,
           Expression<Func<T, object>> DisplayProp, Action SelectionChangedEvent)
        {
            bs.DataSource = data;
            if (data.FirstOrDefault() != null)
            {
                bs.Position = 0;
                SelectionChangedEvent();
            }
            bs.CurrentItemChanged += new EventHandler(delegate(Object o, EventArgs a) { SelectionChangedEvent(); });
            control.DataSource = bs;
            control.DisplayMember = (DisplayProp.Body as MemberExpression).Member.Name;
        }
        private void SetSettingsValue<TProp>(Expression<Func<Settings, TProp>> setting, TProp value)
        {
            var memberSelectorExpression = setting.Body as MemberExpression;
            if (memberSelectorExpression != null)
            {
                var property = memberSelectorExpression.Member as PropertyInfo;
                if (property != null)
                {
                    Settings temp = Cli.GetSettings();
                    property.SetValue(temp, value, null);
                    Cli.SetSettings(temp);
                }
            }
        }
        public void RunAsync<TResult>(Func<TResult> AsyncWork, Action<TResult> CallingWork, Action IfFailed = null)
        {
            //CallingWork(AsyncWork());
            //return;
            var CallingThreadContext = System.Threading.SynchronizationContext.Current;
            AsyncCallback Callback = (cookie) =>
            {
                var target = (Func<TResult>)cookie.AsyncState;

                CallingThreadContext.Post(o =>
                {
                    try
                    {
                        TResult result = target.EndInvoke(cookie);
                        CallingWork(result);
                    }
                    catch
                    {
                        if (IfFailed != null)
                        {
                            IfFailed();
                        }
                        throw;
                    }
                }, null);
            };
            AsyncWork.BeginInvoke(Callback, AsyncWork);
        }

        public void RunAsync(Action AsyncWork, Action CallingWork, Action IfFailed = null)
        {
            //AsyncWork();
            //CallingWork();
            //return;
            var CallingThreadContext = System.Threading.SynchronizationContext.Current;
            AsyncCallback Callback = (cookie) =>
            {
                var target = (Action)cookie.AsyncState;

                CallingThreadContext.Post(o =>
                {
                    try
                    {
                        target.EndInvoke(cookie);
                        CallingWork();
                    }
                    catch
                    {
                        if (IfFailed != null)
                        {
                            IfFailed();
                        }
                        throw;
                    }
                }, null);
            };
            AsyncWork.BeginInvoke(Callback, AsyncWork);
        }


        #endregion

        #region General

        public MainForm()
        {

            InitializeComponent();
        }
        private TabPages LoginCallerPage;
        private void ShowPage(TabPages Page)
        {
            if (Page == TabPages.Upload | Page == TabPages.Uploads)
            {
                bool loggedIn = Cli.UserIsLoggedIn();
                if (!loggedIn)
                {
                    LoginCallerPage = Page;
                    ShowPage(TabPages.Signin);
                    return;
                }
            }
            OnPageShown(Page);
            tabPageContainer.SelectedIndex = (int)Page;
        }
        private void OnPageShown(TabPages page)
        {
            tmrProgress.Stop();//To stop the background querying
            switch (page)
            {
                case TabPages.Signin:
                    if (CliSettings.RememberMe)
                        LoadUserCredentials();
                    else
                        clearSigninPage();
                    break;
                case TabPages.Upload:
                    //ResetUploadScreen(); dont reset it, may loose an arcive
                    break;
                case TabPages.Decrypt:
                    ResetDecryptScreen();
                    break;
                case TabPages.Navigation:
                    break;
                case TabPages.Certificates:
                    LoadCertificates();
                    break;
                case TabPages.Uploads:
                    ResetUploadManagerPage();
                    LoadArchives();
                    break;
                default:
                    break;
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {

            tabPageContainer.ItemSize = new Size(0, 1);
            tabPageContainer.SizeMode = TabSizeMode.Fixed;
            OnPageLoaded();
        }

        void Application_ApplicationExit(object sender, EventArgs e)
        {
            Cli.CloseWhenPossible();
        }
        private void OnPageLoaded()
        {
            string AppDataPath = System.IO.Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "LongAccess");
            if (!System.IO.Directory.Exists(AppDataPath))
            {
                System.IO.Directory.CreateDirectory(AppDataPath);
            }
            Application.ThreadException += Application_ThreadException;
            Application.ApplicationExit += Application_ApplicationExit;
            ShowPage(TabPages.Navigation);
            ForcedUpdate();
            lblVersion.Text = Cli.GetVersion().Version;
            this.txtKeyB.KeyPress += HexInput_KeyDown;
            this.txtKeyC.KeyPress += HexInput_KeyDown;
            this.txtKeyD.KeyPress += HexInput_KeyDown;
            this.txtKeyE.KeyPress += HexInput_KeyDown;
            this.txtKeyB.TextChanged += KeyInput_TextChanged;
            this.txtKeyC.TextChanged += KeyInput_TextChanged;
            this.txtKeyD.TextChanged += KeyInput_TextChanged;
            this.txtKeyE.TextChanged += KeyInput_TextChanged;
        }
        private void ForcedUpdate()
        {
            if (DateTime.Today > new DateTime(2014, 1, 30))
            {
                MessageBox.Show("This version of the application will no longer work. Please download the latest version");
                System.Diagnostics.Process.Start(AppSettings.DownloadUrl);
                Application.Exit();
            }
        }
        void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            if (e.Exception.GetType() == typeof(ThriftInterface.InvalidOperation))
            {
                var customEx = (ThriftInterface.InvalidOperation)e.Exception;
                if (customEx.What == ErrorType.Authentication)
                {
                    ShowPage(TabPages.Signin);
                }
                MessageBox.Show(customEx.Why, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.WriteLine("Thrift exception: " + customEx.What + " " + customEx.Why);
            }
            else
            {
                Logger.WriteLine("GUI error: " + e.Exception.ToString());
                MessageBox.Show(e.Exception.Message);
            }
        }
        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {

        }
        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
        #endregion General
        #region NavigationMenu
        private void btnnavUpload_Click(object sender, EventArgs e)
        {
            ShowPage(TabPages.Upload);
        }

        private void btnNavDecrypt_Click(object sender, EventArgs e)
        {
            ShowPage(TabPages.Decrypt);
        }
        private void btnNavManageCerts_Click(object sender, EventArgs e)
        {
            ShowPage(TabPages.Certificates);
        }

        private void btnNavManageUploads_Click(object sender, EventArgs e)
        {
            ShowPage(TabPages.Uploads);
        }
        private void MenuUpload_Click(object sender, EventArgs e)
        {
            ShowPage(TabPages.Upload);
        }

        private void MenuDecrypt_Click(object sender, EventArgs e)
        {
            ShowPage(TabPages.Decrypt);
        }

        private void MenuLogout_Click(object sender, EventArgs e)
        {
            Cli.Logout();
            clearSigninPage();
            ShowPage(TabPages.Navigation);
        }
        private void MenuCerts_Click(object sender, EventArgs e)
        {
            ShowPage(TabPages.Certificates);
        }

        private void menuUploads_Click(object sender, EventArgs e)
        {
            ShowPage(TabPages.Uploads);
        }
        #endregion NavigationMenu
        #region LoginScreen

        private bool IsPrintableCharacter(char candidate)
        {
            return !(candidate < 32 || candidate > 127);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var resp = Cli.LoginUser(txtEmail.Text, txtPassword.Text, cbRemember.Checked);
            ShowPage(LoginCallerPage);
        }
        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                e.Handled = true;
                button1_Click(sender, null);
            }
        }
        private void btnGoToDecrypt_Click(object sender, EventArgs e)
        {
            ShowPage(TabPages.Decrypt);
        }
        private void lblSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(AppSettings.SingUpUrl);
        }
        private void lblForgotPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(AppSettings.RetrievePassUrl);
        }
        private void LoadUserCredentials()
        {
            var settings = CliSettings;
            cbRemember.Checked = settings.RememberMe;
            txtPassword.Text = settings.StoredPassword;
            txtEmail.Text = settings.StoredUserName;
        }
        private void clearSigninPage()
        {
            cbRemember.Checked = false;
            txtPassword.Text = "";
            txtEmail.Text = "";
        }
        #endregion LoginScreen

        #region DecryptScreen
        private void txtArchivePath_TextChanged(object sender, EventArgs e)
        {
            SetDecryptButtonState();
        }
        void KeyInput_TextChanged(object sender, EventArgs e)
        {
            var txtbox = (MaskedTextBox)sender;
            SetDecryptButtonState();
        }

        void HexInput_KeyDown(object sender, KeyPressEventArgs e)
        {
            MaskedTextBox txtbox = (MaskedTextBox)sender;
            char c = e.KeyChar;
            if (c == (char)Keys.Return)
            {
                txtbox.Parent.SelectNextControl(ActiveControl, true, true, true, true);
                e.Handled = true;
                return;
            }
            if (IsPrintableCharacter(c) & !IsHexChar(c) & !txtbox.MaskCompleted)
            {
                e.Handled = true;
                e.KeyChar = (char)0;
                txtbox.BackColor = Color.FromArgb(255, 202, 184);
            }
            else
            {
                txtbox.BackColor = System.Drawing.SystemColors.Window;
            }
        }
        private void SetDecryptButtonState()
        {
            if (txtKeyB.MaskCompleted & txtKeyC.MaskCompleted &
                txtKeyD.MaskCompleted & txtKeyE.MaskCompleted
                & System.IO.File.Exists(txtArchivePath.Text))
            {
                btnExtractArchive.Enabled = true;
            }
            else
            {
                btnExtractArchive.Enabled = false;
            }
        }
        private bool IsHexString(string str)
        {
            return str.All((c) => IsHexChar(c));
        }
        private bool IsHexChar(char c)
        {
            return ((c >= '0' && c <= '9') ||
                     (c >= 'a' && c <= 'f') ||
                     (c >= 'A' && c <= 'F'));
        }
        private void ResetDecryptScreen()
        {
            btnExtractArchive.Enabled = false;
        }

        private void btnSelectArchive_Click(object sender, EventArgs e)
        {
            if (dlgSelectArchive.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtArchivePath.Text = dlgSelectArchive.FileName;
                SetDecryptButtonState();
            }
        }
        private void btnExtractArchive_Click(object sender, EventArgs e)
        {
            string key = txtKeyB.Text + txtKeyC.Text + txtKeyD.Text + txtKeyE.Text;
            key = key.Replace(" ", "").Replace(".", "").Replace(",", "");
            if (System.IO.Directory.Exists(AppSettings.DefaultExtractionFolder))
            {
                dlgSelectExtractionFolder.SelectedPath = AppSettings.DefaultExtractionFolder;
            }
            if (dlgSelectExtractionFolder.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                AppSettings.DefaultExtractionFolder = dlgSelectExtractionFolder.SelectedPath;
                AppSettings.Save();
                var folder = dlgSelectExtractionFolder.SelectedPath;
                RunAsync(() => Cli.Decrypt(txtArchivePath.Text, key, folder), () => MessageBox.Show("Decryption completed."));
            }
        }
        #endregion DecryptScreen
        #region UploadScreen
        private BindingSource bsCapsules = new BindingSource();

        private void ResetUploadScreen()
        {
            lblReportSelFiles.Text = "";
            txtTitle.Text = "";
            txtDescr.Text = "";
            btnUpload.Enabled = false;
            LoadCapsulesToControl(0);
        }
        private void btnReloadCapsules_Click(object sender, EventArgs e)
        {
            if (ArchiveToUpload != null)
            {
                LoadCapsulesToControl(ArchiveToUpload.Info.SizeInBytes);
            }
            else
            {
                LoadCapsulesToControl(0);
            }
        }
        private string SelectedCapsuleID;
        private void LoadCapsulesToControl(long ArchiveSizeInBytes)
        {
            RunAsync(
                () => Cli.GetCapsules(),
                (AllCapsules) =>
                {
                    var validCapsules = AllCapsules.Where(cap => cap.AvailableSizeInBytes > ArchiveSizeInBytes)
                     .OrderByDescending(cap => cap.AvailableSizeInBytes).ToList();
                    if (validCapsules.Count == 0)
                    {
                        if (AllCapsules.Count > 0)
                        {
                            MessageBox.Show("There is not enough space in any of your capsules. Go to our website to get more space!", "More space needed",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("You don't have any capsules. Go to our website to get one!", "More space needed",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        System.Diagnostics.Process.Start(AppSettings.GetCapsulesUrl);
                    }
                    else
                    {
                        BindData(validCapsules, bsCapsules, cmbCapsules, c => c.DisplayProp,
                                                () => SelectedCapsuleID = ((Capsule)bsCapsules.Current).ID);
                    }

                });
        }
        private Archive ArchiveToUpload;
        private void btnSelectFiles_Click(object sender, EventArgs e)
        {
            if (dlgSelectUploadFiles.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                List<string> SelectedFiles;
                SelectedFiles = new List<string>();
                SelectedFiles.Add(dlgSelectUploadFiles.SelectedPath);
                var allFiles = System.IO.Directory.GetFiles(dlgSelectUploadFiles.SelectedPath, "*.*", System.IO.SearchOption.AllDirectories);
                lblReportSelFiles.Text = allFiles.Length + " files selected. Compressing them for upload...";

                RunAsync(
                    () => Cli.CreateArchive(SelectedFiles),
                    (archive) =>
                    {
                        ArchiveToUpload = archive;
                        lblReportSelFiles.Text = "Compression completed! Final size is " +
                            Utilities.ToMb(ArchiveToUpload.Info.SizeInBytes) + " Mb.";
                        LoadCapsulesToControl(ArchiveToUpload.Info.SizeInBytes);
                        btnUpload.Enabled = true;
                    },
                    () =>
                    {
                        lblReportSelFiles.Text = "Archive creation failed, please try again.";
                    });
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text.Trim().Length == 0)
            {
                MessageBox.Show("Set a descriptive title for the upload before uploading it.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                Cli.UploadToCapsule(ArchiveToUpload.LocalID, SelectedCapsuleID,
                    txtTitle.Text, txtDescr.Text);
                ShowPage(TabPages.Uploads);
                ResetUploadScreen();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion UploadScreen

        #region Certificates
        //private void ResetCertifiacatesPage()
        //{
        //    txtCertFolder.Text = CliSettings.CertificatesFolder;
        //    LoadCertificates();
        //}
        private BindingSource bsCertificates = new BindingSource();
        private Certificate SelectedCertificate;
        private void LoadCertificates()
        {
            RunAsync(
                () => Cli.GetCertificates().OrderByDescending((cert) => cert.RelatedArchive.CreatedDate.ToDateTime()),
                (AllCertificates) =>
                {
                    btnExportCert.Enabled = AllCertificates.FirstOrDefault() != null;
                    txtCertFolder.Text = CliSettings.CertificatesFolder;
                    BindData(AllCertificates, bsCertificates, lbCertificates, c => c.DisplayProp,
                        () =>
                        {
                            SelectedCertificate = (Certificate)bsCertificates.Current;
                            txtCertArchID.Text = SelectedCertificate.Sig.ArchiveID;
                            txtCertTitlePrev.Text = SelectedCertificate.RelatedArchive.Title;
                            txtCertDescrPrev.Text = SelectedCertificate.RelatedArchive.Description;
                        });

                });
        }
        private void btnSelCertFolder_Click(object sender, EventArgs e)
        {
            if (dlgSelectExtractionFolder.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtCertFolder.Text = dlgSelectExtractionFolder.SelectedPath;
                SetSettingsValue(s => s.CertificatesFolder, dlgSelectExtractionFolder.SelectedPath);
                LoadCertificates();
            }
        }
        private void btnExportCert_Click(object sender, EventArgs e)
        {
            dlgSaveCertificate.DefaultExt = ".html";
            dlgSaveCertificate.AddExtension = true;
            dlgSaveCertificate.FileName = SelectedCertificate.RelatedArchive.Title;
            if (dlgSaveCertificate.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var htmlData = Cli.ExportCertificate(SelectedCertificate.LocalID, CertExportFormat.HTML);
                var filename = dlgSaveCertificate.FileName;
                System.IO.File.WriteAllBytes(filename, htmlData);
                if (cbOpenCert.Checked)
                {
                    System.Diagnostics.Process.Start(filename);
                }
            }
        }
        #endregion Certificates
        #region UploadManager
        private BindingSource bsArchives = new BindingSource();
        private Archive SelectedArchive;
        private void LoadArchives()
        {
            RunAsync(
                () => Cli.GetUploads().OrderByDescending(arch => arch.Info.CreatedDate.ToDateTime()).ToList(),
            (Uploads) =>
            {
                BindData(Uploads, bsArchives, lbUploads, c => c.DisplayProp,
                        () =>
                        {
                            SelectedArchive = (Archive)bsArchives.Current;
                            SetControlsStateBasedOnStatus(SelectedArchive.Status);
                            UpdateUploadStatus(SelectedArchive);
                        });
                if (ArchiveToUpload != null)
                {
                    int archIndex = Uploads.FindIndex(arch => arch.LocalID == ArchiveToUpload.LocalID);
                    bsArchives.Position = archIndex;
                }
            });
        }
        private void tmrProgress_Tick(object sender, EventArgs e)
        {
            UpdateUploadStatus(SelectedArchive);
        }
        private void SetControlsStateBasedOnStatus(ArchiveStatus status)
        {
            switch (status)
            {
                case ArchiveStatus.Completed:
                    btnResumeUpload.Enabled = false;
                    btnPauseUpload.Enabled = false;
                    btnCancelUpload.Enabled = false;
                    tmrProgress.Enabled = false;
                    break;
                case ArchiveStatus.InProgress:
                    btnResumeUpload.Enabled = false;
                    btnPauseUpload.Enabled = true;
                    btnCancelUpload.Enabled = true;
                    tmrProgress.Enabled = true;
                    break;
                case ArchiveStatus.Paused:
                    btnResumeUpload.Enabled = true;
                    btnPauseUpload.Enabled = false;
                    btnCancelUpload.Enabled = true;
                    tmrProgress.Enabled = true;
                    break;
                case ArchiveStatus.Stopped:

                    break;
                case ArchiveStatus.Failed:
                    btnResumeUpload.Enabled = false;
                    btnPauseUpload.Enabled = false;
                    btnCancelUpload.Enabled = true;
                    tmrProgress.Enabled = false;
                    break;
                case ArchiveStatus.Local:
                    btnResumeUpload.Enabled = true;
                    btnPauseUpload.Enabled = false;
                    btnCancelUpload.Enabled = true;
                    tmrProgress.Enabled = true;
                    break;
                default:
                    btnResumeUpload.Enabled = false;
                    btnPauseUpload.Enabled = false;
                    btnCancelUpload.Enabled = false;
                    tmrProgress.Enabled = false;
                    break;
            }


        }
        private void UpdateUploadStatus(Archive archive)
        {
            RunAsync(
                () =>
                Cli.QueryArchiveStatus(archive.LocalID),
                (status) =>
                {
                    double progress = status.Progress / (double)(status.Progress + status.RemainingBytes + 1);
                    //progress = Math.Min(1, progress);
                    try
                    {
                        pbUpload.Value = (int)(progress * 100);
                    }
                    catch (Exception e)
                    {
                        throw new Exception("Error in progress bar: value= " + (int)(progress * 100), e);
                    }
                    lblUploadETA.Text = "ETA: " + status.ETA;
                    lblUploadStatus.Text = "Status: " + status.Status.ToString();
                    SetControlsStateBasedOnStatus(status.Status);
                },
                () =>
                {
                    ResetUploadManagerPage();
                });
        }
        private void btnResumeUpload_Click(object sender, EventArgs e)
        {
            Cli.ResumeUpload(SelectedArchive.LocalID);
            UpdateUploadStatus(SelectedArchive);
        }
        private void btnPauseUpload_Click(object sender, EventArgs e)
        {
            Cli.PauseUpload(SelectedArchive.LocalID);
            var res = Cli.QueryArchiveStatus(SelectedArchive.LocalID);
            UpdateUploadStatus(SelectedArchive);


        }
        private void btnCancelUpload_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Permanently cancel this Upload?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
            {
                RunAsync(() => Cli.CancelUpload(SelectedArchive.LocalID), () => LoadArchives());
            }

        }
        private void btnRemoveUploads_Click(object sender, EventArgs e)
        {
            RunAsync(
                () =>
                {
                    var uploads = Cli.GetUploads();
                    foreach (var item in uploads)
                    {
                        if (item.Status == ArchiveStatus.Completed || item.Status == ArchiveStatus.Failed)
                        {
                            Cli.CancelUpload(item.LocalID);
                        }
                    }
                },
                () =>
                {
                    ResetUploadManagerPage();
                    LoadArchives();
                });

        }
        private void ResetUploadManagerPage()
        {
            pbUpload.Value = 0;
            lblUploadETA.Text = "ETA: ";
            lblUploadStatus.Text = "Status: ";
            btnResumeUpload.Enabled = false;
            btnPauseUpload.Enabled = false;
            btnCancelUpload.Enabled = false;
            tmrProgress.Enabled = false;
        }
        #endregion UploadManager

        private static long GetFilesTotalSizeinKb(List<string> files)
        {
            long sum = 0;
            foreach (var file in files)
            {
                sum += (long)(new System.IO.FileInfo(file).Length / 1024f);
            }
            return sum;
        }

        private Dictionary<string, Archive> UploadsDict;
        private void tmrCertificateReminder_Tick(object sender, EventArgs e)
        {
            if (UploadsDict == null)
            {
                var uploads = Cli.GetUploads();
                UploadsDict = Cli.GetUploads().ToDictionary((up) => up.LocalID, (up) => up);
                return;
            }
            var newList = Cli.GetUploads();
            foreach (var updatedUpload in newList)
            {
                if (UploadsDict.ContainsKey(updatedUpload.LocalID))
                {
                    var match = UploadsDict[updatedUpload.LocalID];
                    UploadsDict[match.LocalID] = updatedUpload;
                    if (updatedUpload.Status == ArchiveStatus.Completed && match.Status != ArchiveStatus.Completed)
                    {
                        RemindToPrintCertificate(updatedUpload);
                    }
                }
                else
                {
                    UploadsDict.Add(updatedUpload.LocalID, updatedUpload);
                }
            }
        }
        private void RemindToPrintCertificate(Archive archive)
        {
            MessageBox.Show("Uploading of \"" + archive.Info.Title + "\" completed! We strongly recomend to save and print the related certificate.",
                "Print the certificate.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowPage(TabPages.Certificates);
        }


    }
}
