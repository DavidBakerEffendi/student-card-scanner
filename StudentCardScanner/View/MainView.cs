using StudentCardScanner.Controller;
using StudentCardScanner.Model;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace StudentCardScanner
{
    /// <summary>
    /// The event handlers for the main form.
    /// </summary>
    public partial class MainForm : Form
    {

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private DatabaseModel databaseModel;
        private ExportModel exportModel;
        private SerialPortController serialPortController;
        private NetworkController networkController;

        /// <summary>
        /// The driver class for the main form and its event handelers.
        /// </summary>
        public MainForm()
        {
            /* Initialize UI */
            InitializeComponent(); // VS Studio Autogen code
            this.panelDashboard.Visible = true;
            this.panelScanMain.Visible = false;
            this.panelExport.Visible = false;
            /* Initialize models and controllers */
            this.databaseModel = new DatabaseModel(this);
            this.exportModel = new ExportModel();
            this.serialPortController = new SerialPortController(this, databaseModel);
            this.networkController = new NetworkController(this, databaseModel);
        }

        /// <summary>
        /// Handles the nagivation to the dashboard page.
        /// </summary>
        /// <param name="sender">Sender of the request.</param>
        /// <param name="e">Event arguments.</param>
        private void ButtonDashboard_Click(object sender, EventArgs e)
        {
            panelLeft.Height = buttonDashboard.Height;
            panelLeft.Top = buttonDashboard.Top;

            panelDashboard.Visible = true;
            panelScanMain.Visible = false;
            panelExport.Visible = false;

            labelHeading.Text = buttonDashboard.Text;
        }

        /// <summary>
        /// Handles the nagivation to the scanner page.
        /// </summary>
        /// <param name="sender">Sender of the request.</param>
        /// <param name="e">Event arguments.</param>
        private void ButtonScan_Click(object sender, EventArgs e)
        {
            panelLeft.Height = buttonScan.Height;
            panelLeft.Top = buttonScan.Top;

            panelDashboard.Visible = false;
            panelScanMain.Visible = true;
            panelExport.Visible = false;

            labelHeading.Text = buttonScan.Text;
        }

        /// <summary>
        /// Handles the nagivation to the export page.
        /// </summary>
        /// <param name="sender">Sender of the request.</param>
        /// <param name="e">Event arguments.</param>
        private void ButtonExport_Click(object sender, EventArgs e)
        {
            panelLeft.Height = buttonExport.Height;
            panelLeft.Top = buttonExport.Top;

            panelDashboard.Visible = false;
            panelScanMain.Visible = false;
            panelExport.Visible = true;

            labelHeading.Text = buttonExport.Text;
        }

        /// <summary>
        /// Opens the user's web browser to the given URL.
        /// </summary>
        /// <param name="url">The URL to open.</param>
        private void LinkTo(String url)
        {
            try
            {
                linkGitHub.LinkVisited = true;
                System.Diagnostics.Process.Start(url);
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to open link.");
            }
        }

        /// <summary>
        /// Opens the user's web browser to the project author's GitHub.
        /// </summary>
        /// <param name="sender">Sender of the request.</param>
        /// <param name="e">Event arguments.</param>
        private void LinkGitHub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkTo("https://github.com/DavidBakerEffendi");
        }

        /// <summary>
        /// Opens the user's web browser to the project's GitHub.
        /// </summary>
        /// <param name="sender">Sender of the request.</param>
        /// <param name="e">Event arguments.</param>
        private void PictureLogo_Click(object sender, EventArgs e)
        {
            LinkTo("https://github.com/DavidBakerEffendi/student-card-scanner");
        }

        /// <summary>
        /// Obtains and returns the sign mode. (sign in or sign out)
        /// </summary>
        /// <returns>The sign in or sign out flag as an integer.</returns>
        public int GetSignMode()
        {
            if (this.radioSignIn.Checked)
            {
                return DatabaseModel.SIGN_IN;
            } else
            {
                return DatabaseModel.SIGN_OUT;
            }
        }

        /// <summary>
        /// Changes the colour of the exit button on mouse enter to red.
        /// </summary>
        /// <param name="sender">Sender of the request.</param>
        /// <param name="e">Event arguments.</param>
        private void ButtonExit_MouseEnter(object sender, EventArgs e) => buttonExit.BackColor = Color.FromArgb(1, 244, 81, 30);

        /// <summary>
        /// Changes the colour of the exit button back to the original colour of the form.
        /// </summary>
        /// <param name="sender">Sender of the request.</param>
        /// <param name="e">Event arguments.</param>
        private void ButtonExit_MouseLeave(object sender, EventArgs e) => buttonExit.BackColor = Color.FromArgb(255, 33, 33, 33);

        /// <summary>
        /// Exits the application once the user clicks on the exit button.
        /// </summary>
        /// <param name="sender">Sender of the request.</param>
        /// <param name="e">Event arguments.</param>
        private void ButtonExit_Click(object sender, EventArgs e) => Application.Exit();

        /// <summary>
        /// Minimizes the application when the user clicks on the minimize button.
        /// </summary>
        /// <param name="sender">Sender of the request.</param>
        /// <param name="e">Event arguments.</param>
        private void ButtonMinimize_Click(object sender, EventArgs e) => this.WindowState = FormWindowState.Minimized;

        /// <summary>
        /// Allows the application to be moved around the screen when dragged on the toolbar panel.
        /// </summary>
        /// <param name="sender">Sender of the request.</param>
        /// <param name="e">Event arguments.</param>
        private void PanelToolbar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        /// <summary>
        /// Creates a new Access database and overwrites a currently existing one if there already exists a database with the same name.
        /// </summary>
        /// <param name="sender">Sender of the request.</param>
        /// <param name="e">Event arguments.</param>
        private void ButtonNew_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.FileName = "NewDatabase.accdb";
            dlg.DefaultExt = "accdb";
            dlg.ValidateNames = true;
            dlg.Filter = "Access Database (.accdb)|";
            dlg.Title = "Choose save location";
            dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dlg.RestoreDirectory = true;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.databaseModel.SetCurrentFile(dlg.FileName);
                this.databaseModel.CreateNewAccessDatabase();
                this.databaseModel.ReadFromDatabase(this.dataGrid);
                this.labelDbName.Text = this.databaseModel.GetCurrentFileName();
                this.SetDatabasePanelEnabled(true);
                this.buttonCloseDb.Enabled = true;
                this.buttonDeleteDb.Enabled = true;
            }
        }

        /// <summary>
        /// Displays the last scanned student number on the GUI with the timestamp.
        /// </summary>
        /// <param name="studentNumber">The student number to display.</param>
        public void SetLastCardScanned(string studentNumber)
        {
            if (this.Controls[0].InvokeRequired)
            {
                this.Controls[0].BeginInvoke((Action)(() =>
                {
                    this.labelStudentSignTime.Text = DateTime.Now.ToString("HH:mm:ss");
                    this.labelStudentNumber.Text = studentNumber;
                    this.databaseModel.ReadFromDatabase();
                    this.Focus();
                }));
            }
        }

        /// <summary>
        /// Sets the enabled state of the database panel on the scanner page.
        /// </summary>
        /// <param name="enable">The enabled flag to set to.</param>
        public void SetDatabasePanelEnabled(bool enable)
        {
            this.panelDatabase.Enabled = enable;
        }

        /// <summary>
        /// Allows the selection of an existing Access database to append records to.
        /// </summary>
        /// <param name="sender">Sender of the request.</param>
        /// <param name="e">Event arguments.</param>
        private void ButtonOpenDb_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = "accdb";
            dlg.ValidateNames = true;
            dlg.Filter = "Access Database (*.accdb)|*.accdb";
            dlg.Title = "Open existing database";
            dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dlg.RestoreDirectory = true;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.databaseModel.SetCurrentFile(dlg.FileName);
                this.databaseModel.ReadFromDatabase(this.dataGrid);
                this.labelDbName.Text = this.databaseModel.GetCurrentFileName();
                this.SetDatabasePanelEnabled(true);
                this.buttonCloseDb.Enabled = true;
                this.buttonDeleteDb.Enabled = true;
            }
        }

        /// <summary>
        /// Returns true if the user has selected to read data from the scanner, false if otherwise.
        /// </summary>
        public Boolean GetToggleScanner()
        {
            return this.checkToggleScanner.Checked;
        }

        /// <summary>
        /// Sets the enabled state of the scanner toggle button.
        /// </summary>
        /// <param name="flag">The enabled flag to set to.</param>
        public void SetScannerReady(bool flag)
        {
            this.checkToggleScanner.Enabled = flag;
        }

        /// <summary>
        /// Sets the scanner driver status on the dashboard page.
        /// </summary>
        /// <param name="flag">The status flag to set.</param>
        public void SetScannerDriverStatus(bool flag)
        {
            this.BeginInvoke(new MethodInvoker(() =>
            {
                this.pictureDriverCheck.Visible = flag;
                this.pictureDriverUncheck.Visible = !flag;
            }));
        }

        /// <summary>
        /// Sets the scanner device status on the dashboard page.
        /// </summary>
        /// <param name="flag">The status flag to set.</param>
        public void SetScannerDeviceStatus(bool flag)
        {
            this.BeginInvoke(new MethodInvoker(() =>
            {
                this.pictureDeviceCheck.Visible = flag;
                this.pictureDeviceUncheck.Visible = !flag;
            }));
        }

        /// <summary>
        /// Sets the network status on the dashboard page.
        /// </summary>
        /// <param name="flag">The status flag to set.</param>
        public void SetNetworkConnectedStatus(bool flag)
        {
            this.BeginInvoke(new MethodInvoker(() =>
            {
                this.pictureNetworkDisconnect.Visible = !flag;
                this.pictureNetworkConnect.Visible = flag;
            }));
        }

        /// <summary>
        /// Sets the local IP on the dashboard page.
        /// </summary>
        /// <param name="flag">The status flag to set.</param>
        public void SetNetworkLocalIP(string ip)
        {
            this.BeginInvoke(new MethodInvoker(() =>
            {
                this.labelLocalIP.Text = ip;
            }));
        }

        /// <summary>
        /// Closes the currently selected database.
        /// </summary>
        /// <param name="sender">Sender of the request.</param>
        /// <param name="e">Event arguments.</param>
        private void ButtonCloseDb_Click(object sender, EventArgs e)
        {
            CloseDatabasePanel();
            if (!this.databaseModel.GetCurrentFileName().Equals(""))
            {
                this.databaseModel.SetCurrentFile("");
            }
        }

        /// <summary>
        /// Deletes the currently selected database.
        /// </summary>
        /// <param name="sender">Sender of the request.</param>
        /// <param name="e">Event arguments.</param>
        private void ButtonDeleteDb_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you would like to delete '" + this.databaseModel.GetCurrentFileName() + "'?","Confirm delete action", 
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                try
                {
                    this.databaseModel.DeleteCurrentFile();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error deleting database: " + ex.ToString());
                }
                finally
                {
                    CloseDatabasePanel();
                }
            }
        }

        /// <summary>
        /// "Closes" the database panel components on the form.
        /// </summary>
        internal void CloseDatabasePanel()
        {
            this.buttonCloseDb.Enabled = false;
            this.buttonDeleteDb.Enabled = false;
            this.dataGrid.DataSource = null;
            this.labelDbName.Text = "";
            this.SetDatabasePanelEnabled(false);
        }

        /// <summary>
        /// Selects an Access database to be exported.
        /// </summary>
        /// <param name="sender">Sender of the request.</param>
        /// <param name="e">Event arguments.</param>
        private void ButtonSelectExportDB_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = "accdb";
            dlg.ValidateNames = true;
            dlg.Filter = "Access Database (.accdb)|";
            dlg.Title = "Open existing database";
            dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dlg.RestoreDirectory = true;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.exportModel.SetCurrentFile(dlg.FileName);
                this.exportModel.ReadFromDatabase(this.dataGridExport);
                this.panelDatabaseExport.Enabled = true;
                this.panelFormatSelect.Enabled = true;
                this.labelSelectedExport.Text = this.exportModel.GetCurrentFileName();
            }
        }

        /// <summary>
        /// Sets the export file type on the export model when the user changes the export option.
        /// </summary>
        /// <param name="sender">Sender of the request.</param>
        /// <param name="e">Event arguments.</param>
        private void SelectExportOption_CLick(object sender, EventArgs e)
        {
            if (this.radioButtonExcel.Checked) { this.exportModel.setExportFileType(".xlsx"); }
            else if (this.radioButtonCSV.Checked) { this.exportModel.setExportFileType(".csv"); }
            this.panelExportConfirm.Enabled = true;
        }

        /// <summary>
        /// Exports the records in the selected Access database to export to the selected destination file.
        /// </summary>
        /// <param name="sender">Sender of the request.</param>
        /// <param name="e">Event arguments.</param>
        private void ButtonExportDB_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.FileName = "NewDatabase" + this.exportModel.getExportFileType();
            dlg.DefaultExt = this.exportModel.getExportFileType();
            dlg.ValidateNames = true;
            dlg.Filter = this.exportModel.getExportFilter();
            dlg.Title = "Choose location to export " + this.exportModel.GetCurrentFileName() + " to:";
            dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dlg.RestoreDirectory = true;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                switch (this.exportModel.getExportFileType())
                {
                    case ".xlsx":
                        Cursor.Current = Cursors.WaitCursor;
                        this.exportModel.ExportCurrentFileToExcel(dlg.FileName);
                        break;
                    case ".csv":
                        Cursor.Current = Cursors.WaitCursor;
                        this.exportModel.ExportCurrentFileToCSV(dlg.FileName);
                        break;
                }
                Cursor.Current = Cursors.Default;

            }
        }

        /// <summary>
        /// Flashes the student number display panel from primary blue to secondary red back to primary blue.
        /// </summary>
        public void FlashSignInPanel()
        {
            if (this.Controls[0].InvokeRequired)
            {
                this.Controls[0].BeginInvoke((Action)(() =>
                {
                    panelLastSignIn.BackColor = Color.FromArgb(255, 63, 128);
                }));
            }
            Thread.Sleep(100);
            if (this.Controls[0].InvokeRequired)
            {
                this.Controls[0].BeginInvoke((Action)(() =>
                {
                    panelLastSignIn.BackColor = Color.FromArgb(62, 80, 180);
                }));
            }
        }

        public void SetTotalSignIns(int count)
        {
            this.labelTotalSignInCount.Text = count.ToString();
        }
    }
}
