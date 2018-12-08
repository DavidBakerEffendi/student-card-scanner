namespace StudentCardScanner
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
            this.panelAside = new System.Windows.Forms.Panel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.buttonDashboard = new System.Windows.Forms.Button();
            this.linkGitHub = new System.Windows.Forms.LinkLabel();
            this.labelCreditsLang = new System.Windows.Forms.Label();
            this.buttonExport = new System.Windows.Forms.Button();
            this.buttonScan = new System.Windows.Forms.Button();
            this.panelIcon = new System.Windows.Forms.Panel();
            this.pictureLogo = new System.Windows.Forms.PictureBox();
            this.labelLogo = new System.Windows.Forms.Label();
            this.panelScanMain = new System.Windows.Forms.Panel();
            this.panelLastSignIn = new System.Windows.Forms.Panel();
            this.labelStudentSignTime = new System.Windows.Forms.Label();
            this.labelSignTime = new System.Windows.Forms.Label();
            this.labelStudentNumber = new System.Windows.Forms.Label();
            this.labelLastSignIn = new System.Windows.Forms.Label();
            this.panelDatabase = new System.Windows.Forms.Panel();
            this.labelDbName = new System.Windows.Forms.Label();
            this.buttonSaveDb = new System.Windows.Forms.Button();
            this.buttonDeleteDb = new System.Windows.Forms.Button();
            this.buttonOpenDb = new System.Windows.Forms.Button();
            this.buttonNew = new System.Windows.Forms.Button();
            this.labelDbHeading = new System.Windows.Forms.Label();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.panelSignMode = new System.Windows.Forms.Panel();
            this.labelSignMode = new System.Windows.Forms.Label();
            this.radioSignOut = new System.Windows.Forms.RadioButton();
            this.radioSignIn = new System.Windows.Forms.RadioButton();
            this.labelHeading = new System.Windows.Forms.Label();
            this.panelToolbar = new System.Windows.Forms.Panel();
            this.buttonMinimize = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.panelDashboard = new System.Windows.Forms.Panel();
            this.panelDescription = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelStatus = new System.Windows.Forms.Panel();
            this.labelStatus = new System.Windows.Forms.Label();
            this.panelExport = new System.Windows.Forms.Panel();
            this.panelFileSelect = new System.Windows.Forms.Panel();
            this.labelSelectFile = new System.Windows.Forms.Label();
            this.tblstudentscansBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panelAside.SuspendLayout();
            this.panelIcon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).BeginInit();
            this.panelScanMain.SuspendLayout();
            this.panelLastSignIn.SuspendLayout();
            this.panelDatabase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.panelSignMode.SuspendLayout();
            this.panelToolbar.SuspendLayout();
            this.panelDashboard.SuspendLayout();
            this.panelDescription.SuspendLayout();
            this.panelStatus.SuspendLayout();
            this.panelExport.SuspendLayout();
            this.panelFileSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelAside
            // 
            this.panelAside.BackColor = System.Drawing.Color.Black;
            this.panelAside.Controls.Add(this.panelLeft);
            this.panelAside.Controls.Add(this.buttonDashboard);
            this.panelAside.Controls.Add(this.linkGitHub);
            this.panelAside.Controls.Add(this.labelCreditsLang);
            this.panelAside.Controls.Add(this.buttonExport);
            this.panelAside.Controls.Add(this.buttonScan);
            this.panelAside.Controls.Add(this.panelIcon);
            this.panelAside.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelAside.ForeColor = System.Drawing.Color.White;
            this.panelAside.Location = new System.Drawing.Point(0, 0);
            this.panelAside.Name = "panelAside";
            this.panelAside.Size = new System.Drawing.Size(139, 628);
            this.panelAside.TabIndex = 0;
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(63)))), ((int)(((byte)(128)))));
            this.panelLeft.Location = new System.Drawing.Point(129, 92);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(10, 100);
            this.panelLeft.TabIndex = 4;
            // 
            // buttonDashboard
            // 
            this.buttonDashboard.FlatAppearance.BorderSize = 0;
            this.buttonDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDashboard.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDashboard.ForeColor = System.Drawing.Color.White;
            this.buttonDashboard.Image = ((System.Drawing.Image)(resources.GetObject("buttonDashboard.Image")));
            this.buttonDashboard.Location = new System.Drawing.Point(0, 91);
            this.buttonDashboard.Name = "buttonDashboard";
            this.buttonDashboard.Size = new System.Drawing.Size(135, 100);
            this.buttonDashboard.TabIndex = 5;
            this.buttonDashboard.Text = "Dashboard";
            this.buttonDashboard.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonDashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonDashboard.UseVisualStyleBackColor = true;
            this.buttonDashboard.Click += new System.EventHandler(this.buttonDashboard_Click);
            // 
            // linkGitHub
            // 
            this.linkGitHub.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(63)))), ((int)(((byte)(128)))));
            this.linkGitHub.AutoSize = true;
            this.linkGitHub.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkGitHub.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(80)))), ((int)(((byte)(180)))));
            this.linkGitHub.Location = new System.Drawing.Point(4, 609);
            this.linkGitHub.Name = "linkGitHub";
            this.linkGitHub.Size = new System.Drawing.Size(130, 16);
            this.linkGitHub.TabIndex = 1;
            this.linkGitHub.TabStop = true;
            this.linkGitHub.Text = "by David Baker Effendi";
            this.linkGitHub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkGitHub_LinkClicked);
            // 
            // labelCreditsLang
            // 
            this.labelCreditsLang.AutoSize = true;
            this.labelCreditsLang.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCreditsLang.Location = new System.Drawing.Point(4, 591);
            this.labelCreditsLang.Name = "labelCreditsLang";
            this.labelCreditsLang.Size = new System.Drawing.Size(119, 17);
            this.labelCreditsLang.TabIndex = 0;
            this.labelCreditsLang.Text = "Developed in C#";
            // 
            // buttonExport
            // 
            this.buttonExport.FlatAppearance.BorderSize = 0;
            this.buttonExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExport.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExport.ForeColor = System.Drawing.Color.White;
            this.buttonExport.Image = ((System.Drawing.Image)(resources.GetObject("buttonExport.Image")));
            this.buttonExport.Location = new System.Drawing.Point(0, 304);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(135, 100);
            this.buttonExport.TabIndex = 4;
            this.buttonExport.Text = "Export";
            this.buttonExport.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // buttonScan
            // 
            this.buttonScan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonScan.FlatAppearance.BorderSize = 0;
            this.buttonScan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonScan.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonScan.ForeColor = System.Drawing.Color.White;
            this.buttonScan.Image = ((System.Drawing.Image)(resources.GetObject("buttonScan.Image")));
            this.buttonScan.Location = new System.Drawing.Point(0, 198);
            this.buttonScan.Name = "buttonScan";
            this.buttonScan.Size = new System.Drawing.Size(135, 100);
            this.buttonScan.TabIndex = 3;
            this.buttonScan.Text = "Start Scanning";
            this.buttonScan.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonScan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonScan.UseVisualStyleBackColor = true;
            this.buttonScan.Click += new System.EventHandler(this.buttonScan_Click);
            // 
            // panelIcon
            // 
            this.panelIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(80)))), ((int)(((byte)(180)))));
            this.panelIcon.Controls.Add(this.pictureLogo);
            this.panelIcon.Controls.Add(this.labelLogo);
            this.panelIcon.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelIcon.Location = new System.Drawing.Point(0, 0);
            this.panelIcon.Name = "panelIcon";
            this.panelIcon.Size = new System.Drawing.Size(139, 73);
            this.panelIcon.TabIndex = 2;
            // 
            // pictureLogo
            // 
            this.pictureLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureLogo.Image")));
            this.pictureLogo.Location = new System.Drawing.Point(16, 6);
            this.pictureLogo.Name = "pictureLogo";
            this.pictureLogo.Size = new System.Drawing.Size(100, 42);
            this.pictureLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureLogo.TabIndex = 4;
            this.pictureLogo.TabStop = false;
            this.pictureLogo.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // labelLogo
            // 
            this.labelLogo.AutoSize = true;
            this.labelLogo.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLogo.Location = new System.Drawing.Point(11, 48);
            this.labelLogo.Name = "labelLogo";
            this.labelLogo.Size = new System.Drawing.Size(118, 21);
            this.labelLogo.TabIndex = 3;
            this.labelLogo.Text = "Card Scanner";
            // 
            // panelScanMain
            // 
            this.panelScanMain.Controls.Add(this.panelLastSignIn);
            this.panelScanMain.Controls.Add(this.panelDatabase);
            this.panelScanMain.Controls.Add(this.panelSignMode);
            this.panelScanMain.ForeColor = System.Drawing.Color.White;
            this.panelScanMain.Location = new System.Drawing.Point(139, 75);
            this.panelScanMain.Name = "panelScanMain";
            this.panelScanMain.Size = new System.Drawing.Size(704, 550);
            this.panelScanMain.TabIndex = 6;
            this.panelScanMain.Visible = false;
            // 
            // panelLastSignIn
            // 
            this.panelLastSignIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.panelLastSignIn.Controls.Add(this.labelStudentSignTime);
            this.panelLastSignIn.Controls.Add(this.labelSignTime);
            this.panelLastSignIn.Controls.Add(this.labelStudentNumber);
            this.panelLastSignIn.Controls.Add(this.labelLastSignIn);
            this.panelLastSignIn.Location = new System.Drawing.Point(14, 140);
            this.panelLastSignIn.Name = "panelLastSignIn";
            this.panelLastSignIn.Size = new System.Drawing.Size(238, 132);
            this.panelLastSignIn.TabIndex = 4;
            // 
            // labelStudentSignTime
            // 
            this.labelStudentSignTime.AutoSize = true;
            this.labelStudentSignTime.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStudentSignTime.Location = new System.Drawing.Point(66, 101);
            this.labelStudentSignTime.Name = "labelStudentSignTime";
            this.labelStudentSignTime.Size = new System.Drawing.Size(0, 19);
            this.labelStudentSignTime.TabIndex = 6;
            // 
            // labelSignTime
            // 
            this.labelSignTime.AutoSize = true;
            this.labelSignTime.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSignTime.Location = new System.Drawing.Point(10, 101);
            this.labelSignTime.Name = "labelSignTime";
            this.labelSignTime.Size = new System.Drawing.Size(50, 19);
            this.labelSignTime.TabIndex = 5;
            this.labelSignTime.Text = "Time:";
            // 
            // labelStudentNumber
            // 
            this.labelStudentNumber.AutoSize = true;
            this.labelStudentNumber.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStudentNumber.Location = new System.Drawing.Point(58, 53);
            this.labelStudentNumber.Name = "labelStudentNumber";
            this.labelStudentNumber.Size = new System.Drawing.Size(0, 32);
            this.labelStudentNumber.TabIndex = 4;
            this.labelStudentNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelLastSignIn
            // 
            this.labelLastSignIn.AutoSize = true;
            this.labelLastSignIn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLastSignIn.Location = new System.Drawing.Point(10, 10);
            this.labelLastSignIn.Name = "labelLastSignIn";
            this.labelLastSignIn.Size = new System.Drawing.Size(94, 19);
            this.labelLastSignIn.TabIndex = 3;
            this.labelLastSignIn.Text = "Last sign in:";
            // 
            // panelDatabase
            // 
            this.panelDatabase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.panelDatabase.Controls.Add(this.labelDbName);
            this.panelDatabase.Controls.Add(this.buttonSaveDb);
            this.panelDatabase.Controls.Add(this.buttonDeleteDb);
            this.panelDatabase.Controls.Add(this.buttonOpenDb);
            this.panelDatabase.Controls.Add(this.buttonNew);
            this.panelDatabase.Controls.Add(this.labelDbHeading);
            this.panelDatabase.Controls.Add(this.dataGrid);
            this.panelDatabase.Location = new System.Drawing.Point(268, 16);
            this.panelDatabase.Name = "panelDatabase";
            this.panelDatabase.Size = new System.Drawing.Size(424, 512);
            this.panelDatabase.TabIndex = 3;
            // 
            // labelDbName
            // 
            this.labelDbName.AutoSize = true;
            this.labelDbName.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDbName.Location = new System.Drawing.Point(114, 14);
            this.labelDbName.Name = "labelDbName";
            this.labelDbName.Size = new System.Drawing.Size(0, 19);
            this.labelDbName.TabIndex = 6;
            // 
            // buttonSaveDb
            // 
            this.buttonSaveDb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.buttonSaveDb.FlatAppearance.BorderSize = 0;
            this.buttonSaveDb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSaveDb.Image = ((System.Drawing.Image)(resources.GetObject("buttonSaveDb.Image")));
            this.buttonSaveDb.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSaveDb.Location = new System.Drawing.Point(118, 464);
            this.buttonSaveDb.Name = "buttonSaveDb";
            this.buttonSaveDb.Size = new System.Drawing.Size(92, 33);
            this.buttonSaveDb.TabIndex = 5;
            this.buttonSaveDb.Text = "Save";
            this.buttonSaveDb.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonSaveDb.UseVisualStyleBackColor = false;
            // 
            // buttonDeleteDb
            // 
            this.buttonDeleteDb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.buttonDeleteDb.FlatAppearance.BorderSize = 0;
            this.buttonDeleteDb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeleteDb.Image = ((System.Drawing.Image)(resources.GetObject("buttonDeleteDb.Image")));
            this.buttonDeleteDb.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDeleteDb.Location = new System.Drawing.Point(314, 464);
            this.buttonDeleteDb.Name = "buttonDeleteDb";
            this.buttonDeleteDb.Size = new System.Drawing.Size(92, 33);
            this.buttonDeleteDb.TabIndex = 4;
            this.buttonDeleteDb.Text = "Delete";
            this.buttonDeleteDb.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonDeleteDb.UseVisualStyleBackColor = false;
            // 
            // buttonOpenDb
            // 
            this.buttonOpenDb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.buttonOpenDb.FlatAppearance.BorderSize = 0;
            this.buttonOpenDb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOpenDb.Image = ((System.Drawing.Image)(resources.GetObject("buttonOpenDb.Image")));
            this.buttonOpenDb.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonOpenDb.Location = new System.Drawing.Point(216, 464);
            this.buttonOpenDb.Name = "buttonOpenDb";
            this.buttonOpenDb.Size = new System.Drawing.Size(92, 33);
            this.buttonOpenDb.TabIndex = 3;
            this.buttonOpenDb.Text = "Open";
            this.buttonOpenDb.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonOpenDb.UseVisualStyleBackColor = false;
            this.buttonOpenDb.Click += new System.EventHandler(this.buttonOpenDb_Click);
            // 
            // buttonNew
            // 
            this.buttonNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.buttonNew.FlatAppearance.BorderSize = 0;
            this.buttonNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNew.Image = ((System.Drawing.Image)(resources.GetObject("buttonNew.Image")));
            this.buttonNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonNew.Location = new System.Drawing.Point(20, 464);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(92, 33);
            this.buttonNew.TabIndex = 2;
            this.buttonNew.Text = "New";
            this.buttonNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonNew.UseVisualStyleBackColor = false;
            this.buttonNew.Click += new System.EventHandler(this.buttonNew_Click);
            // 
            // labelDbHeading
            // 
            this.labelDbHeading.AutoSize = true;
            this.labelDbHeading.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDbHeading.Location = new System.Drawing.Point(16, 14);
            this.labelDbHeading.Name = "labelDbHeading";
            this.labelDbHeading.Size = new System.Drawing.Size(92, 19);
            this.labelDbHeading.TabIndex = 1;
            this.labelDbHeading.Text = "Database: ";
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.AllowUserToOrderColumns = true;
            this.dataGrid.Location = new System.Drawing.Point(20, 39);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            this.dataGrid.Size = new System.Drawing.Size(386, 419);
            this.dataGrid.TabIndex = 0;
            // 
            // panelSignMode
            // 
            this.panelSignMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.panelSignMode.Controls.Add(this.labelSignMode);
            this.panelSignMode.Controls.Add(this.radioSignOut);
            this.panelSignMode.Controls.Add(this.radioSignIn);
            this.panelSignMode.Location = new System.Drawing.Point(14, 16);
            this.panelSignMode.Name = "panelSignMode";
            this.panelSignMode.Size = new System.Drawing.Size(238, 110);
            this.panelSignMode.TabIndex = 2;
            // 
            // labelSignMode
            // 
            this.labelSignMode.AutoSize = true;
            this.labelSignMode.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSignMode.Location = new System.Drawing.Point(10, 14);
            this.labelSignMode.Name = "labelSignMode";
            this.labelSignMode.Size = new System.Drawing.Size(58, 19);
            this.labelSignMode.TabIndex = 2;
            this.labelSignMode.Text = "Mode:";
            // 
            // radioSignOut
            // 
            this.radioSignOut.AutoSize = true;
            this.radioSignOut.Location = new System.Drawing.Point(14, 70);
            this.radioSignOut.Name = "radioSignOut";
            this.radioSignOut.Size = new System.Drawing.Size(95, 25);
            this.radioSignOut.TabIndex = 1;
            this.radioSignOut.Text = "Sign Out";
            this.radioSignOut.UseVisualStyleBackColor = true;
            // 
            // radioSignIn
            // 
            this.radioSignIn.AutoSize = true;
            this.radioSignIn.Checked = true;
            this.radioSignIn.Location = new System.Drawing.Point(14, 39);
            this.radioSignIn.Name = "radioSignIn";
            this.radioSignIn.Size = new System.Drawing.Size(79, 25);
            this.radioSignIn.TabIndex = 0;
            this.radioSignIn.TabStop = true;
            this.radioSignIn.Text = "Sign In";
            this.radioSignIn.UseVisualStyleBackColor = true;
            // 
            // labelHeading
            // 
            this.labelHeading.AutoSize = true;
            this.labelHeading.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHeading.Location = new System.Drawing.Point(20, 23);
            this.labelHeading.Name = "labelHeading";
            this.labelHeading.Size = new System.Drawing.Size(125, 25);
            this.labelHeading.TabIndex = 2;
            this.labelHeading.Text = "Dashboard";
            // 
            // panelToolbar
            // 
            this.panelToolbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.panelToolbar.Controls.Add(this.buttonMinimize);
            this.panelToolbar.Controls.Add(this.buttonExit);
            this.panelToolbar.Controls.Add(this.labelHeading);
            this.panelToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelToolbar.ForeColor = System.Drawing.Color.White;
            this.panelToolbar.Location = new System.Drawing.Point(139, 0);
            this.panelToolbar.Name = "panelToolbar";
            this.panelToolbar.Size = new System.Drawing.Size(704, 73);
            this.panelToolbar.TabIndex = 5;
            this.panelToolbar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelToolbar_MouseDown);
            // 
            // buttonMinimize
            // 
            this.buttonMinimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.buttonMinimize.FlatAppearance.BorderSize = 0;
            this.buttonMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMinimize.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMinimize.ForeColor = System.Drawing.Color.White;
            this.buttonMinimize.Image = ((System.Drawing.Image)(resources.GetObject("buttonMinimize.Image")));
            this.buttonMinimize.Location = new System.Drawing.Point(595, 0);
            this.buttonMinimize.Name = "buttonMinimize";
            this.buttonMinimize.Size = new System.Drawing.Size(50, 30);
            this.buttonMinimize.TabIndex = 6;
            this.buttonMinimize.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonMinimize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonMinimize.UseVisualStyleBackColor = false;
            this.buttonMinimize.Click += new System.EventHandler(this.buttonMinimize_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.buttonExit.FlatAppearance.BorderSize = 0;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit.ForeColor = System.Drawing.Color.White;
            this.buttonExit.Image = ((System.Drawing.Image)(resources.GetObject("buttonExit.Image")));
            this.buttonExit.Location = new System.Drawing.Point(652, 0);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(50, 30);
            this.buttonExit.TabIndex = 5;
            this.buttonExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            this.buttonExit.MouseEnter += new System.EventHandler(this.buttonExit_MouseEnter);
            this.buttonExit.MouseLeave += new System.EventHandler(this.buttonExit_MouseLeave);
            // 
            // panelDashboard
            // 
            this.panelDashboard.Controls.Add(this.panelDescription);
            this.panelDashboard.Controls.Add(this.panelStatus);
            this.panelDashboard.ForeColor = System.Drawing.Color.White;
            this.panelDashboard.Location = new System.Drawing.Point(139, 75);
            this.panelDashboard.Name = "panelDashboard";
            this.panelDashboard.Size = new System.Drawing.Size(704, 550);
            this.panelDashboard.TabIndex = 7;
            // 
            // panelDescription
            // 
            this.panelDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.panelDescription.Controls.Add(this.label1);
            this.panelDescription.Location = new System.Drawing.Point(14, 16);
            this.panelDescription.Name = "panelDescription";
            this.panelDescription.Size = new System.Drawing.Size(672, 202);
            this.panelDescription.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Description";
            // 
            // panelStatus
            // 
            this.panelStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.panelStatus.Controls.Add(this.labelStatus);
            this.panelStatus.Location = new System.Drawing.Point(14, 239);
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Size = new System.Drawing.Size(672, 294);
            this.panelStatus.TabIndex = 2;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.Location = new System.Drawing.Point(13, 14);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(136, 19);
            this.labelStatus.TabIndex = 2;
            this.labelStatus.Text = "Computer status:";
            // 
            // panelExport
            // 
            this.panelExport.Controls.Add(this.panelFileSelect);
            this.panelExport.ForeColor = System.Drawing.Color.White;
            this.panelExport.Location = new System.Drawing.Point(139, 75);
            this.panelExport.Name = "panelExport";
            this.panelExport.Size = new System.Drawing.Size(704, 550);
            this.panelExport.TabIndex = 8;
            // 
            // panelFileSelect
            // 
            this.panelFileSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.panelFileSelect.Controls.Add(this.labelSelectFile);
            this.panelFileSelect.Location = new System.Drawing.Point(14, 16);
            this.panelFileSelect.Name = "panelFileSelect";
            this.panelFileSelect.Size = new System.Drawing.Size(280, 202);
            this.panelFileSelect.TabIndex = 2;
            // 
            // labelSelectFile
            // 
            this.labelSelectFile.AutoSize = true;
            this.labelSelectFile.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectFile.Location = new System.Drawing.Point(13, 14);
            this.labelSelectFile.Name = "labelSelectFile";
            this.labelSelectFile.Size = new System.Drawing.Size(85, 19);
            this.labelSelectFile.TabIndex = 2;
            this.labelSelectFile.Text = "Select file:";
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(843, 628);
            this.Controls.Add(this.panelScanMain);
            this.Controls.Add(this.panelDashboard);
            this.Controls.Add(this.panelExport);
            this.Controls.Add(this.panelToolbar);
            this.Controls.Add(this.panelAside);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Text = "mainForm";
            this.panelAside.ResumeLayout(false);
            this.panelAside.PerformLayout();
            this.panelIcon.ResumeLayout(false);
            this.panelIcon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).EndInit();
            this.panelScanMain.ResumeLayout(false);
            this.panelLastSignIn.ResumeLayout(false);
            this.panelLastSignIn.PerformLayout();
            this.panelDatabase.ResumeLayout(false);
            this.panelDatabase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.panelSignMode.ResumeLayout(false);
            this.panelSignMode.PerformLayout();
            this.panelToolbar.ResumeLayout(false);
            this.panelToolbar.PerformLayout();
            this.panelDashboard.ResumeLayout(false);
            this.panelDescription.ResumeLayout(false);
            this.panelDescription.PerformLayout();
            this.panelStatus.ResumeLayout(false);
            this.panelStatus.PerformLayout();
            this.panelExport.ResumeLayout(false);
            this.panelFileSelect.ResumeLayout(false);
            this.panelFileSelect.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelAside;
        private System.Windows.Forms.Panel panelIcon;
        private System.Windows.Forms.Label labelLogo;
        private System.Windows.Forms.Label labelHeading;
        private System.Windows.Forms.Button buttonScan;
        private System.Windows.Forms.PictureBox pictureLogo;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelToolbar;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.LinkLabel linkGitHub;
        private System.Windows.Forms.Label labelCreditsLang;
        private System.Windows.Forms.Button buttonMinimize;
        private System.Windows.Forms.Panel panelScanMain;
        private System.Windows.Forms.Label labelDbHeading;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.Panel panelSignMode;
        private System.Windows.Forms.Panel panelDatabase;
        private System.Windows.Forms.Label labelDbName;
        private System.Windows.Forms.Button buttonSaveDb;
        private System.Windows.Forms.Button buttonDeleteDb;
        private System.Windows.Forms.Button buttonOpenDb;
        private System.Windows.Forms.Button buttonNew;
        private System.Windows.Forms.Label labelSignMode;
        private System.Windows.Forms.RadioButton radioSignOut;
        private System.Windows.Forms.RadioButton radioSignIn;
        private System.Windows.Forms.Panel panelLastSignIn;
        private System.Windows.Forms.Label labelStudentSignTime;
        private System.Windows.Forms.Label labelSignTime;
        private System.Windows.Forms.Label labelStudentNumber;
        private System.Windows.Forms.Label labelLastSignIn;
        private System.Windows.Forms.Button buttonDashboard;
        private System.Windows.Forms.Panel panelDashboard;
        private System.Windows.Forms.Panel panelStatus;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Panel panelExport;
        private System.Windows.Forms.Panel panelFileSelect;
        private System.Windows.Forms.Label labelSelectFile;
        private System.Windows.Forms.Panel panelDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource tblstudentscansBindingSource;
    }
}

