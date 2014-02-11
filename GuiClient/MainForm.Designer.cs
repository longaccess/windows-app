namespace GuiClient
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabPageContainer = new System.Windows.Forms.TabControl();
            this.tbpgLogin = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cbRemember = new System.Windows.Forms.CheckBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblForgotPass = new System.Windows.Forms.LinkLabel();
            this.lblSignUp = new System.Windows.Forms.LinkLabel();
            this.btnSignIn = new System.Windows.Forms.Button();
            this.tbpgUpload = new System.Windows.Forms.TabPage();
            this.btnReloadCapsules = new System.Windows.Forms.Button();
            this.lblReportSelFiles = new System.Windows.Forms.Label();
            this.btnUpload = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.txtDescr = new System.Windows.Forms.RichTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnSelectFiles = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbCapsules = new System.Windows.Forms.ComboBox();
            this.tbpgDownload = new System.Windows.Forms.TabPage();
            this.btnExtractArchive = new System.Windows.Forms.Button();
            this.txtKeyE = new System.Windows.Forms.MaskedTextBox();
            this.txtKeyD = new System.Windows.Forms.MaskedTextBox();
            this.txtKeyC = new System.Windows.Forms.MaskedTextBox();
            this.txtKeyB = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtArchivePath = new System.Windows.Forms.TextBox();
            this.btnSelectArchive = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbpgNav = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNavManageUploads = new System.Windows.Forms.Button();
            this.btnNavManageCerts = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnNavDecrypt = new System.Windows.Forms.Button();
            this.btnnavUpload = new System.Windows.Forms.Button();
            this.tbpgCerts = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCertArchID = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.cbOpenCert = new System.Windows.Forms.CheckBox();
            this.btnExportCert = new System.Windows.Forms.Button();
            this.txtCertDescrPrev = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtCertTitlePrev = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.lbCertificates = new System.Windows.Forms.ListBox();
            this.btnSelCertFolder = new System.Windows.Forms.Button();
            this.txtCertFolder = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.tbpgUploads = new System.Windows.Forms.TabPage();
            this.btnRemoveUploads = new System.Windows.Forms.Button();
            this.lblUploadStatus = new System.Windows.Forms.Label();
            this.pbUpload = new System.Windows.Forms.ProgressBar();
            this.lblUploadETA = new System.Windows.Forms.Label();
            this.btnCancelUpload = new System.Windows.Forms.Button();
            this.btnPauseUpload = new System.Windows.Forms.Button();
            this.lbUploads = new System.Windows.Forms.ListBox();
            this.label21 = new System.Windows.Forms.Label();
            this.btnResumeUpload = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuUpload = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuDecrypt = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuCerts = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUploads = new System.Windows.Forms.ToolStripMenuItem();
            this.dlgSelectExtractionFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.tmrQueryUploadStatus = new System.Windows.Forms.Timer(this.components);
            this.dlgSaveCertificate = new System.Windows.Forms.SaveFileDialog();
            this.bgwCreateArchive = new System.ComponentModel.BackgroundWorker();
            this.dlgSelectArchive = new System.Windows.Forms.OpenFileDialog();
            this.dlgSelectUploadFiles = new System.Windows.Forms.FolderBrowserDialog();
            this.label23 = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tmrCertificateReminder = new System.Windows.Forms.Timer(this.components);
            this.btnUpdate = new System.Windows.Forms.Button();
            this.tabPageContainer.SuspendLayout();
            this.tbpgLogin.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tbpgUpload.SuspendLayout();
            this.tbpgDownload.SuspendLayout();
            this.tbpgNav.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            this.tbpgCerts.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tbpgUploads.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPageContainer
            // 
            this.tabPageContainer.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabPageContainer.Controls.Add(this.tbpgLogin);
            this.tabPageContainer.Controls.Add(this.tbpgUpload);
            this.tabPageContainer.Controls.Add(this.tbpgDownload);
            this.tabPageContainer.Controls.Add(this.tbpgNav);
            this.tabPageContainer.Controls.Add(this.tbpgCerts);
            this.tabPageContainer.Controls.Add(this.tbpgUploads);
            this.tabPageContainer.Location = new System.Drawing.Point(0, 29);
            this.tabPageContainer.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageContainer.Name = "tabPageContainer";
            this.tabPageContainer.SelectedIndex = 0;
            this.tabPageContainer.Size = new System.Drawing.Size(546, 630);
            this.tabPageContainer.TabIndex = 0;
            // 
            // tbpgLogin
            // 
            this.tbpgLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.tbpgLogin.Controls.Add(this.panel2);
            this.tbpgLogin.Controls.Add(this.cbRemember);
            this.tbpgLogin.Controls.Add(this.txtPassword);
            this.tbpgLogin.Controls.Add(this.txtEmail);
            this.tbpgLogin.Controls.Add(this.label2);
            this.tbpgLogin.Controls.Add(this.label1);
            this.tbpgLogin.Controls.Add(this.lblForgotPass);
            this.tbpgLogin.Controls.Add(this.lblSignUp);
            this.tbpgLogin.Controls.Add(this.btnSignIn);
            this.tbpgLogin.ForeColor = System.Drawing.Color.Black;
            this.tbpgLogin.Location = new System.Drawing.Point(4, 29);
            this.tbpgLogin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbpgLogin.Name = "tbpgLogin";
            this.tbpgLogin.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbpgLogin.Size = new System.Drawing.Size(538, 597);
            this.tbpgLogin.TabIndex = 0;
            this.tbpgLogin.Text = "Sign in";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(6, 7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(526, 190);
            this.panel2.TabIndex = 10;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(0, 40);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(524, 109);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // cbRemember
            // 
            this.cbRemember.AutoSize = true;
            this.cbRemember.Location = new System.Drawing.Point(133, 395);
            this.cbRemember.Name = "cbRemember";
            this.cbRemember.Size = new System.Drawing.Size(113, 21);
            this.cbRemember.TabIndex = 9;
            this.cbRemember.Text = "Remember me";
            this.cbRemember.UseVisualStyleBackColor = true;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtPassword.Location = new System.Drawing.Point(133, 355);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(270, 33);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtEmail.Location = new System.Drawing.Point(133, 309);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(270, 33);
            this.txtEmail.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label2.Location = new System.Drawing.Point(38, 361);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 21);
            this.label2.TabIndex = 7;
            this.label2.Text = "Password:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label1.Location = new System.Drawing.Point(65, 315);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "e-mail:";
            // 
            // lblForgotPass
            // 
            this.lblForgotPass.AutoSize = true;
            this.lblForgotPass.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblForgotPass.Location = new System.Drawing.Point(130, 491);
            this.lblForgotPass.Name = "lblForgotPass";
            this.lblForgotPass.Size = new System.Drawing.Size(114, 17);
            this.lblForgotPass.TabIndex = 4;
            this.lblForgotPass.TabStop = true;
            this.lblForgotPass.Text = "Forgot password?";
            this.lblForgotPass.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblForgotPass_LinkClicked);
            // 
            // lblSignUp
            // 
            this.lblSignUp.AutoSize = true;
            this.lblSignUp.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblSignUp.Location = new System.Drawing.Point(130, 470);
            this.lblSignUp.Name = "lblSignUp";
            this.lblSignUp.Size = new System.Drawing.Size(52, 17);
            this.lblSignUp.TabIndex = 3;
            this.lblSignUp.TabStop = true;
            this.lblSignUp.Text = "Sign up";
            this.lblSignUp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblSignUp_LinkClicked);
            // 
            // btnSignIn
            // 
            this.btnSignIn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSignIn.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.btnSignIn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSignIn.Location = new System.Drawing.Point(132, 423);
            this.btnSignIn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(271, 43);
            this.btnSignIn.TabIndex = 2;
            this.btnSignIn.Text = "Sign in";
            this.btnSignIn.UseVisualStyleBackColor = true;
            this.btnSignIn.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbpgUpload
            // 
            this.tbpgUpload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.tbpgUpload.Controls.Add(this.btnReloadCapsules);
            this.tbpgUpload.Controls.Add(this.lblReportSelFiles);
            this.tbpgUpload.Controls.Add(this.btnUpload);
            this.tbpgUpload.Controls.Add(this.label17);
            this.tbpgUpload.Controls.Add(this.txtDescr);
            this.tbpgUpload.Controls.Add(this.label15);
            this.tbpgUpload.Controls.Add(this.label16);
            this.tbpgUpload.Controls.Add(this.txtTitle);
            this.tbpgUpload.Controls.Add(this.label14);
            this.tbpgUpload.Controls.Add(this.label13);
            this.tbpgUpload.Controls.Add(this.label12);
            this.tbpgUpload.Controls.Add(this.btnSelectFiles);
            this.tbpgUpload.Controls.Add(this.label11);
            this.tbpgUpload.Controls.Add(this.label10);
            this.tbpgUpload.Controls.Add(this.cmbCapsules);
            this.tbpgUpload.Location = new System.Drawing.Point(4, 29);
            this.tbpgUpload.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbpgUpload.Name = "tbpgUpload";
            this.tbpgUpload.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbpgUpload.Size = new System.Drawing.Size(538, 597);
            this.tbpgUpload.TabIndex = 1;
            this.tbpgUpload.Text = "Upload";
            // 
            // btnReloadCapsules
            // 
            this.btnReloadCapsules.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnReloadCapsules.Location = new System.Drawing.Point(441, 378);
            this.btnReloadCapsules.Margin = new System.Windows.Forms.Padding(7);
            this.btnReloadCapsules.Name = "btnReloadCapsules";
            this.btnReloadCapsules.Size = new System.Drawing.Size(60, 29);
            this.btnReloadCapsules.TabIndex = 24;
            this.btnReloadCapsules.Text = "Reload";
            this.btnReloadCapsules.UseVisualStyleBackColor = true;
            this.btnReloadCapsules.Click += new System.EventHandler(this.btnReloadCapsules_Click);
            // 
            // lblReportSelFiles
            // 
            this.lblReportSelFiles.AutoSize = true;
            this.lblReportSelFiles.Location = new System.Drawing.Point(103, 86);
            this.lblReportSelFiles.Name = "lblReportSelFiles";
            this.lblReportSelFiles.Size = new System.Drawing.Size(0, 17);
            this.lblReportSelFiles.TabIndex = 23;
            // 
            // btnUpload
            // 
            this.btnUpload.Enabled = false;
            this.btnUpload.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnUpload.Location = new System.Drawing.Point(175, 455);
            this.btnUpload.Margin = new System.Windows.Forms.Padding(7);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(189, 39);
            this.btnUpload.TabIndex = 22;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label17.Location = new System.Drawing.Point(102, 24);
            this.label17.Margin = new System.Windows.Forms.Padding(7);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(153, 21);
            this.label17.TabIndex = 21;
            this.label17.Text = "Select files to upload";
            // 
            // txtDescr
            // 
            this.txtDescr.Location = new System.Drawing.Point(102, 226);
            this.txtDescr.Name = "txtDescr";
            this.txtDescr.Size = new System.Drawing.Size(335, 118);
            this.txtDescr.TabIndex = 20;
            this.txtDescr.Text = "";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label15.Location = new System.Drawing.Point(102, 195);
            this.label15.Margin = new System.Windows.Forms.Padding(7);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(171, 21);
            this.label15.TabIndex = 19;
            this.label15.Text = "Set Archive Description";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label16.Location = new System.Drawing.Point(62, 352);
            this.label16.Margin = new System.Windows.Forms.Padding(7);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(28, 25);
            this.label16.TabIndex = 18;
            this.label16.Text = "4.";
            // 
            // txtTitle
            // 
            this.txtTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtTitle.Location = new System.Drawing.Point(102, 151);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(335, 29);
            this.txtTitle.TabIndex = 17;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label14.Location = new System.Drawing.Point(102, 120);
            this.label14.Margin = new System.Windows.Forms.Padding(7);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(121, 21);
            this.label14.TabIndex = 16;
            this.label14.Text = "Set Archive Title";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label13.Location = new System.Drawing.Point(62, 192);
            this.label13.Margin = new System.Windows.Forms.Padding(7);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(28, 25);
            this.label13.TabIndex = 15;
            this.label13.Text = "3.";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label12.Location = new System.Drawing.Point(62, 117);
            this.label12.Margin = new System.Windows.Forms.Padding(7);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(28, 25);
            this.label12.TabIndex = 13;
            this.label12.Text = "2.";
            // 
            // btnSelectFiles
            // 
            this.btnSelectFiles.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnSelectFiles.Location = new System.Drawing.Point(102, 50);
            this.btnSelectFiles.Margin = new System.Windows.Forms.Padding(7);
            this.btnSelectFiles.Name = "btnSelectFiles";
            this.btnSelectFiles.Size = new System.Drawing.Size(135, 29);
            this.btnSelectFiles.TabIndex = 12;
            this.btnSelectFiles.Text = "Select Files";
            this.btnSelectFiles.UseVisualStyleBackColor = true;
            this.btnSelectFiles.Click += new System.EventHandler(this.btnSelectFiles_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label11.Location = new System.Drawing.Point(62, 21);
            this.label11.Margin = new System.Windows.Forms.Padding(7);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(28, 25);
            this.label11.TabIndex = 11;
            this.label11.Text = "1.";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label10.Location = new System.Drawing.Point(98, 355);
            this.label10.Margin = new System.Windows.Forms.Padding(7);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(110, 21);
            this.label10.TabIndex = 10;
            this.label10.Text = "Select Capsule";
            // 
            // cmbCapsules
            // 
            this.cmbCapsules.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.cmbCapsules.FormattingEnabled = true;
            this.cmbCapsules.Location = new System.Drawing.Point(102, 378);
            this.cmbCapsules.Margin = new System.Windows.Forms.Padding(7);
            this.cmbCapsules.Name = "cmbCapsules";
            this.cmbCapsules.Size = new System.Drawing.Size(335, 29);
            this.cmbCapsules.TabIndex = 9;
            // 
            // tbpgDownload
            // 
            this.tbpgDownload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.tbpgDownload.Controls.Add(this.btnExtractArchive);
            this.tbpgDownload.Controls.Add(this.txtKeyE);
            this.tbpgDownload.Controls.Add(this.txtKeyD);
            this.tbpgDownload.Controls.Add(this.txtKeyC);
            this.tbpgDownload.Controls.Add(this.txtKeyB);
            this.tbpgDownload.Controls.Add(this.label9);
            this.tbpgDownload.Controls.Add(this.label8);
            this.tbpgDownload.Controls.Add(this.label7);
            this.tbpgDownload.Controls.Add(this.label6);
            this.tbpgDownload.Controls.Add(this.label5);
            this.tbpgDownload.Controls.Add(this.txtArchivePath);
            this.tbpgDownload.Controls.Add(this.btnSelectArchive);
            this.tbpgDownload.Controls.Add(this.label4);
            this.tbpgDownload.Location = new System.Drawing.Point(4, 29);
            this.tbpgDownload.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbpgDownload.Name = "tbpgDownload";
            this.tbpgDownload.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbpgDownload.Size = new System.Drawing.Size(538, 597);
            this.tbpgDownload.TabIndex = 2;
            this.tbpgDownload.Text = "Download";
            // 
            // btnExtractArchive
            // 
            this.btnExtractArchive.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnExtractArchive.Location = new System.Drawing.Point(188, 450);
            this.btnExtractArchive.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExtractArchive.Name = "btnExtractArchive";
            this.btnExtractArchive.Size = new System.Drawing.Size(163, 42);
            this.btnExtractArchive.TabIndex = 18;
            this.btnExtractArchive.Text = "Extract Data";
            this.btnExtractArchive.UseVisualStyleBackColor = true;
            this.btnExtractArchive.Click += new System.EventHandler(this.btnExtractArchive_Click);
            // 
            // txtKeyE
            // 
            this.txtKeyE.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtKeyE.Location = new System.Drawing.Point(134, 383);
            this.txtKeyE.Mask = "AA AA AA AA , AA AA AA AA";
            this.txtKeyE.Name = "txtKeyE";
            this.txtKeyE.Size = new System.Drawing.Size(271, 35);
            this.txtKeyE.TabIndex = 17;
            this.txtKeyE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtKeyD
            // 
            this.txtKeyD.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtKeyD.Location = new System.Drawing.Point(134, 334);
            this.txtKeyD.Mask = "AA AA AA AA , AA AA AA AA";
            this.txtKeyD.Name = "txtKeyD";
            this.txtKeyD.Size = new System.Drawing.Size(271, 35);
            this.txtKeyD.TabIndex = 16;
            this.txtKeyD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtKeyC
            // 
            this.txtKeyC.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtKeyC.Location = new System.Drawing.Point(134, 285);
            this.txtKeyC.Mask = "AA AA AA AA , AA AA AA AA";
            this.txtKeyC.Name = "txtKeyC";
            this.txtKeyC.Size = new System.Drawing.Size(271, 35);
            this.txtKeyC.TabIndex = 15;
            this.txtKeyC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtKeyB
            // 
            this.txtKeyB.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtKeyB.Location = new System.Drawing.Point(134, 236);
            this.txtKeyB.Mask = "AA AA AA AA , AA AA AA AA";
            this.txtKeyB.Name = "txtKeyB";
            this.txtKeyB.Size = new System.Drawing.Size(271, 35);
            this.txtKeyB.TabIndex = 14;
            this.txtKeyB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label9.Location = new System.Drawing.Point(106, 390);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(22, 25);
            this.label9.TabIndex = 13;
            this.label9.Text = "E";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(104, 341);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 25);
            this.label8.TabIndex = 12;
            this.label8.Text = "D";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(104, 292);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 25);
            this.label7.TabIndex = 11;
            this.label7.Text = "C";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(104, 243);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 25);
            this.label6.TabIndex = 10;
            this.label6.Text = "B";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(91, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(362, 25);
            this.label5.TabIndex = 9;
            this.label5.Text = "Enter the key as shown on your certificate";
            // 
            // txtArchivePath
            // 
            this.txtArchivePath.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtArchivePath.Location = new System.Drawing.Point(136, 115);
            this.txtArchivePath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtArchivePath.Name = "txtArchivePath";
            this.txtArchivePath.Size = new System.Drawing.Size(394, 25);
            this.txtArchivePath.TabIndex = 8;
            this.txtArchivePath.TextChanged += new System.EventHandler(this.txtArchivePath_TextChanged);
            // 
            // btnSelectArchive
            // 
            this.btnSelectArchive.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnSelectArchive.Location = new System.Drawing.Point(11, 107);
            this.btnSelectArchive.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSelectArchive.Name = "btnSelectArchive";
            this.btnSelectArchive.Size = new System.Drawing.Size(119, 37);
            this.btnSelectArchive.TabIndex = 7;
            this.btnSelectArchive.Text = "Select Archive";
            this.btnSelectArchive.UseVisualStyleBackColor = true;
            this.btnSelectArchive.Click += new System.EventHandler(this.btnSelectArchive_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(160, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(218, 32);
            this.label4.TabIndex = 6;
            this.label4.Text = "Archive Decryption";
            // 
            // tbpgNav
            // 
            this.tbpgNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.tbpgNav.Controls.Add(this.panel3);
            this.tbpgNav.Controls.Add(this.panel1);
            this.tbpgNav.Location = new System.Drawing.Point(4, 29);
            this.tbpgNav.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbpgNav.Name = "tbpgNav";
            this.tbpgNav.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbpgNav.Size = new System.Drawing.Size(538, 597);
            this.tbpgNav.TabIndex = 3;
            this.tbpgNav.Text = "Navigation";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Location = new System.Drawing.Point(6, 7);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(526, 190);
            this.panel3.TabIndex = 11;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.InitialImage = null;
            this.pictureBox2.Location = new System.Drawing.Point(0, 40);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(524, 109);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnNavManageUploads);
            this.panel1.Controls.Add(this.btnNavManageCerts);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnNavDecrypt);
            this.panel1.Controls.Add(this.btnnavUpload);
            this.panel1.Location = new System.Drawing.Point(7, 200);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(524, 392);
            this.panel1.TabIndex = 8;
            // 
            // btnNavManageUploads
            // 
            this.btnNavManageUploads.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNavManageUploads.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnNavManageUploads.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnNavManageUploads.Location = new System.Drawing.Point(98, 299);
            this.btnNavManageUploads.Margin = new System.Windows.Forms.Padding(9);
            this.btnNavManageUploads.Name = "btnNavManageUploads";
            this.btnNavManageUploads.Size = new System.Drawing.Size(329, 55);
            this.btnNavManageUploads.TabIndex = 9;
            this.btnNavManageUploads.Text = "Check my current uploads";
            this.btnNavManageUploads.UseVisualStyleBackColor = true;
            this.btnNavManageUploads.Click += new System.EventHandler(this.btnNavManageUploads_Click);
            // 
            // btnNavManageCerts
            // 
            this.btnNavManageCerts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNavManageCerts.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnNavManageCerts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnNavManageCerts.Location = new System.Drawing.Point(98, 226);
            this.btnNavManageCerts.Margin = new System.Windows.Forms.Padding(9);
            this.btnNavManageCerts.Name = "btnNavManageCerts";
            this.btnNavManageCerts.Size = new System.Drawing.Size(329, 55);
            this.btnNavManageCerts.TabIndex = 8;
            this.btnNavManageCerts.Text = "Export/Print a local certificate";
            this.btnNavManageCerts.UseVisualStyleBackColor = true;
            this.btnNavManageCerts.Click += new System.EventHandler(this.btnNavManageCerts_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(92, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 32);
            this.label3.TabIndex = 5;
            this.label3.Text = "I want to...";
            // 
            // btnNavDecrypt
            // 
            this.btnNavDecrypt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNavDecrypt.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnNavDecrypt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnNavDecrypt.Location = new System.Drawing.Point(98, 153);
            this.btnNavDecrypt.Margin = new System.Windows.Forms.Padding(9);
            this.btnNavDecrypt.Name = "btnNavDecrypt";
            this.btnNavDecrypt.Size = new System.Drawing.Size(329, 55);
            this.btnNavDecrypt.TabIndex = 7;
            this.btnNavDecrypt.Text = "Extract an archive using a key";
            this.btnNavDecrypt.UseVisualStyleBackColor = true;
            this.btnNavDecrypt.Click += new System.EventHandler(this.btnNavDecrypt_Click);
            // 
            // btnnavUpload
            // 
            this.btnnavUpload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnnavUpload.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnnavUpload.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnnavUpload.Location = new System.Drawing.Point(98, 80);
            this.btnnavUpload.Margin = new System.Windows.Forms.Padding(9);
            this.btnnavUpload.Name = "btnnavUpload";
            this.btnnavUpload.Size = new System.Drawing.Size(329, 55);
            this.btnnavUpload.TabIndex = 6;
            this.btnnavUpload.Text = "Upload files to a capsule";
            this.btnnavUpload.UseVisualStyleBackColor = true;
            this.btnnavUpload.Click += new System.EventHandler(this.btnnavUpload_Click);
            // 
            // tbpgCerts
            // 
            this.tbpgCerts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.tbpgCerts.Controls.Add(this.groupBox1);
            this.tbpgCerts.Controls.Add(this.lbCertificates);
            this.tbpgCerts.Controls.Add(this.btnSelCertFolder);
            this.tbpgCerts.Controls.Add(this.txtCertFolder);
            this.tbpgCerts.Controls.Add(this.label18);
            this.tbpgCerts.Location = new System.Drawing.Point(4, 29);
            this.tbpgCerts.Name = "tbpgCerts";
            this.tbpgCerts.Padding = new System.Windows.Forms.Padding(3);
            this.tbpgCerts.Size = new System.Drawing.Size(538, 597);
            this.tbpgCerts.TabIndex = 4;
            this.tbpgCerts.Text = "Certificates";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCertArchID);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.cbOpenCert);
            this.groupBox1.Controls.Add(this.btnExportCert);
            this.groupBox1.Controls.Add(this.txtCertDescrPrev);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.txtCertTitlePrev);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Location = new System.Drawing.Point(11, 273);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(519, 315);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selected Certificate";
            // 
            // txtCertArchID
            // 
            this.txtCertArchID.BackColor = System.Drawing.SystemColors.Window;
            this.txtCertArchID.Location = new System.Drawing.Point(79, 61);
            this.txtCertArchID.Name = "txtCertArchID";
            this.txtCertArchID.ReadOnly = true;
            this.txtCertArchID.Size = new System.Drawing.Size(393, 25);
            this.txtCertArchID.TabIndex = 7;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(4, 64);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(69, 17);
            this.label22.TabIndex = 6;
            this.label22.Text = "Archive ID:";
            // 
            // cbOpenCert
            // 
            this.cbOpenCert.AutoSize = true;
            this.cbOpenCert.Checked = true;
            this.cbOpenCert.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbOpenCert.Location = new System.Drawing.Point(346, 271);
            this.cbOpenCert.Name = "cbOpenCert";
            this.cbOpenCert.Size = new System.Drawing.Size(80, 21);
            this.cbOpenCert.TabIndex = 5;
            this.cbOpenCert.Text = "Open file";
            this.cbOpenCert.UseVisualStyleBackColor = true;
            // 
            // btnExportCert
            // 
            this.btnExportCert.Enabled = false;
            this.btnExportCert.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnExportCert.Location = new System.Drawing.Point(179, 263);
            this.btnExportCert.Name = "btnExportCert";
            this.btnExportCert.Size = new System.Drawing.Size(161, 33);
            this.btnExportCert.TabIndex = 4;
            this.btnExportCert.Text = "Save to html file";
            this.btnExportCert.UseVisualStyleBackColor = true;
            this.btnExportCert.Click += new System.EventHandler(this.btnExportCert_Click);
            // 
            // txtCertDescrPrev
            // 
            this.txtCertDescrPrev.BackColor = System.Drawing.SystemColors.Window;
            this.txtCertDescrPrev.Location = new System.Drawing.Point(47, 109);
            this.txtCertDescrPrev.Multiline = true;
            this.txtCertDescrPrev.Name = "txtCertDescrPrev";
            this.txtCertDescrPrev.ReadOnly = true;
            this.txtCertDescrPrev.Size = new System.Drawing.Size(425, 148);
            this.txtCertDescrPrev.TabIndex = 3;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(4, 89);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(77, 17);
            this.label20.TabIndex = 2;
            this.label20.Text = "Description:";
            // 
            // txtCertTitlePrev
            // 
            this.txtCertTitlePrev.BackColor = System.Drawing.SystemColors.Window;
            this.txtCertTitlePrev.Location = new System.Drawing.Point(79, 30);
            this.txtCertTitlePrev.Name = "txtCertTitlePrev";
            this.txtCertTitlePrev.ReadOnly = true;
            this.txtCertTitlePrev.Size = new System.Drawing.Size(393, 25);
            this.txtCertTitlePrev.TabIndex = 1;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(6, 33);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(35, 17);
            this.label19.TabIndex = 0;
            this.label19.Text = "Title:";
            // 
            // lbCertificates
            // 
            this.lbCertificates.FormattingEnabled = true;
            this.lbCertificates.ItemHeight = 17;
            this.lbCertificates.Location = new System.Drawing.Point(58, 93);
            this.lbCertificates.Name = "lbCertificates";
            this.lbCertificates.Size = new System.Drawing.Size(425, 174);
            this.lbCertificates.TabIndex = 3;
            // 
            // btnSelCertFolder
            // 
            this.btnSelCertFolder.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnSelCertFolder.Location = new System.Drawing.Point(351, 43);
            this.btnSelCertFolder.Name = "btnSelCertFolder";
            this.btnSelCertFolder.Size = new System.Drawing.Size(132, 35);
            this.btnSelCertFolder.TabIndex = 2;
            this.btnSelCertFolder.Text = "Change Folder";
            this.btnSelCertFolder.UseVisualStyleBackColor = true;
            this.btnSelCertFolder.Click += new System.EventHandler(this.btnSelCertFolder_Click);
            // 
            // txtCertFolder
            // 
            this.txtCertFolder.Location = new System.Drawing.Point(175, 12);
            this.txtCertFolder.Name = "txtCertFolder";
            this.txtCertFolder.Size = new System.Drawing.Size(308, 25);
            this.txtCertFolder.TabIndex = 1;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(8, 15);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(161, 17);
            this.label18.TabIndex = 0;
            this.label18.Text = "Default Certificates Folder:";
            // 
            // tbpgUploads
            // 
            this.tbpgUploads.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.tbpgUploads.Controls.Add(this.btnRemoveUploads);
            this.tbpgUploads.Controls.Add(this.lblUploadStatus);
            this.tbpgUploads.Controls.Add(this.pbUpload);
            this.tbpgUploads.Controls.Add(this.lblUploadETA);
            this.tbpgUploads.Controls.Add(this.btnCancelUpload);
            this.tbpgUploads.Controls.Add(this.btnPauseUpload);
            this.tbpgUploads.Controls.Add(this.lbUploads);
            this.tbpgUploads.Controls.Add(this.label21);
            this.tbpgUploads.Controls.Add(this.btnResumeUpload);
            this.tbpgUploads.Location = new System.Drawing.Point(4, 29);
            this.tbpgUploads.Name = "tbpgUploads";
            this.tbpgUploads.Padding = new System.Windows.Forms.Padding(3);
            this.tbpgUploads.Size = new System.Drawing.Size(538, 597);
            this.tbpgUploads.TabIndex = 5;
            this.tbpgUploads.Text = "Uploads";
            // 
            // btnRemoveUploads
            // 
            this.btnRemoveUploads.Location = new System.Drawing.Point(335, 366);
            this.btnRemoveUploads.Name = "btnRemoveUploads";
            this.btnRemoveUploads.Size = new System.Drawing.Size(185, 35);
            this.btnRemoveUploads.TabIndex = 9;
            this.btnRemoveUploads.Text = "Remove completed or failed";
            this.btnRemoveUploads.UseVisualStyleBackColor = true;
            this.btnRemoveUploads.Click += new System.EventHandler(this.btnRemoveUploads_Click);
            // 
            // lblUploadStatus
            // 
            this.lblUploadStatus.AutoSize = true;
            this.lblUploadStatus.Location = new System.Drawing.Point(135, 58);
            this.lblUploadStatus.Name = "lblUploadStatus";
            this.lblUploadStatus.Size = new System.Drawing.Size(50, 17);
            this.lblUploadStatus.TabIndex = 8;
            this.lblUploadStatus.Text = "Status: ";
            // 
            // pbUpload
            // 
            this.pbUpload.Location = new System.Drawing.Point(342, 29);
            this.pbUpload.Name = "pbUpload";
            this.pbUpload.Size = new System.Drawing.Size(178, 17);
            this.pbUpload.TabIndex = 6;
            // 
            // lblUploadETA
            // 
            this.lblUploadETA.AutoSize = true;
            this.lblUploadETA.Location = new System.Drawing.Point(135, 29);
            this.lblUploadETA.Name = "lblUploadETA";
            this.lblUploadETA.Size = new System.Drawing.Size(33, 17);
            this.lblUploadETA.TabIndex = 5;
            this.lblUploadETA.Text = "ETA:";
            // 
            // btnCancelUpload
            // 
            this.btnCancelUpload.BackgroundImage = global::GuiClient.Properties.Resources.stop;
            this.btnCancelUpload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCancelUpload.Enabled = false;
            this.btnCancelUpload.Location = new System.Drawing.Point(96, 21);
            this.btnCancelUpload.Name = "btnCancelUpload";
            this.btnCancelUpload.Size = new System.Drawing.Size(33, 33);
            this.btnCancelUpload.TabIndex = 4;
            this.btnCancelUpload.Text = " ";
            this.btnCancelUpload.UseVisualStyleBackColor = true;
            this.btnCancelUpload.Click += new System.EventHandler(this.btnCancelUpload_Click);
            // 
            // btnPauseUpload
            // 
            this.btnPauseUpload.BackgroundImage = global::GuiClient.Properties.Resources.pause;
            this.btnPauseUpload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPauseUpload.Enabled = false;
            this.btnPauseUpload.Location = new System.Drawing.Point(57, 21);
            this.btnPauseUpload.Name = "btnPauseUpload";
            this.btnPauseUpload.Size = new System.Drawing.Size(33, 33);
            this.btnPauseUpload.TabIndex = 3;
            this.btnPauseUpload.Text = " ";
            this.btnPauseUpload.UseVisualStyleBackColor = true;
            this.btnPauseUpload.Click += new System.EventHandler(this.btnPauseUpload_Click);
            // 
            // lbUploads
            // 
            this.lbUploads.FormattingEnabled = true;
            this.lbUploads.ItemHeight = 17;
            this.lbUploads.Location = new System.Drawing.Point(18, 135);
            this.lbUploads.Name = "lbUploads";
            this.lbUploads.Size = new System.Drawing.Size(502, 225);
            this.lbUploads.TabIndex = 2;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(15, 115);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(127, 17);
            this.label21.TabIndex = 1;
            this.label21.Text = "Select from Uploads";
            // 
            // btnResumeUpload
            // 
            this.btnResumeUpload.BackgroundImage = global::GuiClient.Properties.Resources.play;
            this.btnResumeUpload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnResumeUpload.Enabled = false;
            this.btnResumeUpload.Location = new System.Drawing.Point(18, 21);
            this.btnResumeUpload.Name = "btnResumeUpload";
            this.btnResumeUpload.Size = new System.Drawing.Size(33, 33);
            this.btnResumeUpload.TabIndex = 0;
            this.btnResumeUpload.Text = " ";
            this.btnResumeUpload.UseVisualStyleBackColor = true;
            this.btnResumeUpload.Click += new System.EventHandler(this.btnResumeUpload_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStrip1.Size = new System.Drawing.Size(546, 29);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.BackColor = System.Drawing.Color.White;
            this.toolStripMenuItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuUpload,
            this.MenuDecrypt,
            this.MenuLogout,
            this.MenuCerts,
            this.menuUploads});
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(62, 25);
            this.toolStripMenuItem1.Text = "Menu";
            // 
            // MenuUpload
            // 
            this.MenuUpload.Name = "MenuUpload";
            this.MenuUpload.Size = new System.Drawing.Size(217, 26);
            this.MenuUpload.Text = "Upload File(s)";
            this.MenuUpload.Click += new System.EventHandler(this.MenuUpload_Click);
            // 
            // MenuDecrypt
            // 
            this.MenuDecrypt.Name = "MenuDecrypt";
            this.MenuDecrypt.Size = new System.Drawing.Size(217, 26);
            this.MenuDecrypt.Text = "Decrypt Archive";
            this.MenuDecrypt.Click += new System.EventHandler(this.MenuDecrypt_Click);
            // 
            // MenuLogout
            // 
            this.MenuLogout.Name = "MenuLogout";
            this.MenuLogout.Size = new System.Drawing.Size(217, 26);
            this.MenuLogout.Text = "Sign out";
            this.MenuLogout.Click += new System.EventHandler(this.MenuLogout_Click);
            // 
            // MenuCerts
            // 
            this.MenuCerts.Name = "MenuCerts";
            this.MenuCerts.Size = new System.Drawing.Size(217, 26);
            this.MenuCerts.Text = "Manage Certificates";
            this.MenuCerts.Click += new System.EventHandler(this.MenuCerts_Click);
            // 
            // menuUploads
            // 
            this.menuUploads.Name = "menuUploads";
            this.menuUploads.Size = new System.Drawing.Size(217, 26);
            this.menuUploads.Text = "Manage Uploads";
            this.menuUploads.Click += new System.EventHandler(this.menuUploads_Click);
            // 
            // dlgSelectExtractionFolder
            // 
            this.dlgSelectExtractionFolder.Description = "Select the folder to save the extracted archive";
            // 
            // tmrQueryUploadStatus
            // 
            this.tmrQueryUploadStatus.Interval = 3000;
            this.tmrQueryUploadStatus.Tick += new System.EventHandler(this.tmrProgress_Tick);
            // 
            // dlgSelectArchive
            // 
            this.dlgSelectArchive.AddExtension = false;
            this.dlgSelectArchive.Title = "Select the archive to extract";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(1, 659);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(55, 17);
            this.label23.TabIndex = 25;
            this.label23.Text = "Version:";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(57, 659);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(0, 17);
            this.lblVersion.TabIndex = 26;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // tmrCertificateReminder
            // 
            this.tmrCertificateReminder.Enabled = true;
            this.tmrCertificateReminder.Interval = 5000;
            this.tmrCertificateReminder.Tick += new System.EventHandler(this.tmrCertificateReminder_Tick);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(137, 653);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 29);
            this.btnUpdate.TabIndex = 27;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Visible = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.ClientSize = new System.Drawing.Size(546, 685);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.tabPageContainer);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "Longaccess";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabPageContainer.ResumeLayout(false);
            this.tbpgLogin.ResumeLayout(false);
            this.tbpgLogin.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tbpgUpload.ResumeLayout(false);
            this.tbpgUpload.PerformLayout();
            this.tbpgDownload.ResumeLayout(false);
            this.tbpgDownload.PerformLayout();
            this.tbpgNav.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tbpgCerts.ResumeLayout(false);
            this.tbpgCerts.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tbpgUploads.ResumeLayout(false);
            this.tbpgUploads.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabPageContainer;
        private System.Windows.Forms.TabPage tbpgLogin;
        private System.Windows.Forms.TabPage tbpgUpload;
        private System.Windows.Forms.TabPage tbpgDownload;
        private System.Windows.Forms.LinkLabel lblSignUp;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSignIn;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lblForgotPass;
        private System.Windows.Forms.TabPage tbpgNav;
        private System.Windows.Forms.Button btnNavDecrypt;
        private System.Windows.Forms.Button btnnavUpload;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtArchivePath;
        private System.Windows.Forms.Button btnSelectArchive;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox txtKeyB;
        private System.Windows.Forms.Button btnExtractArchive;
        private System.Windows.Forms.MaskedTextBox txtKeyE;
        private System.Windows.Forms.MaskedTextBox txtKeyD;
        private System.Windows.Forms.MaskedTextBox txtKeyC;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem MenuUpload;
        private System.Windows.Forms.ToolStripMenuItem MenuDecrypt;
        private System.Windows.Forms.ToolStripMenuItem MenuLogout;
        private System.Windows.Forms.TabPage tbpgCerts;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnSelectFiles;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbCapsules;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.RichTextBox txtDescr;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblReportSelFiles;
        private System.Windows.Forms.ListBox lbCertificates;
        private System.Windows.Forms.Button btnSelCertFolder;
        private System.Windows.Forms.TextBox txtCertFolder;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCertDescrPrev;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtCertTitlePrev;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.FolderBrowserDialog dlgSelectExtractionFolder;
        private System.Windows.Forms.TabPage tbpgUploads;
        private System.Windows.Forms.ListBox lbUploads;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button btnResumeUpload;
        private System.Windows.Forms.Button btnCancelUpload;
        private System.Windows.Forms.Button btnPauseUpload;
        private System.Windows.Forms.ProgressBar pbUpload;
        private System.Windows.Forms.Label lblUploadETA;
        private System.Windows.Forms.Button btnExportCert;
        private System.Windows.Forms.ToolStripMenuItem MenuCerts;
        private System.Windows.Forms.ToolStripMenuItem menuUploads;
        private System.Windows.Forms.Timer tmrQueryUploadStatus;
        private System.Windows.Forms.SaveFileDialog dlgSaveCertificate;
        private System.Windows.Forms.CheckBox cbRemember;
        private System.Windows.Forms.Panel panel2;
        private System.ComponentModel.BackgroundWorker bgwCreateArchive;
        private System.Windows.Forms.TextBox txtCertArchID;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.CheckBox cbOpenCert;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnNavManageUploads;
        private System.Windows.Forms.Button btnNavManageCerts;
        private System.Windows.Forms.OpenFileDialog dlgSelectArchive;
        private System.Windows.Forms.Label lblUploadStatus;
        private System.Windows.Forms.FolderBrowserDialog dlgSelectUploadFiles;
        private System.Windows.Forms.Button btnReloadCapsules;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Button btnRemoveUploads;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Timer tmrCertificateReminder;
        private System.Windows.Forms.Button btnUpdate;
    }
}

