using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using StudentCardScanner.Model;
using StudentCardScanner.Controller;

namespace StudentCardScanner
{
    public partial class MainForm : Form
    {

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private DatabaseModel databaseModel;
        private SerialPortController serialPortController;
        private NetworkController networkController;

        public MainForm()
        {
            InitializeComponent();
            this.databaseModel = new DatabaseModel();
            this.serialPortController = new SerialPortController(this, databaseModel);
            this.networkController = new NetworkController(this, databaseModel);
        }


        private void buttonDashboard_Click(object sender, EventArgs e)
        {
            panelLeft.Height = buttonDashboard.Height;
            panelLeft.Top = buttonDashboard.Top;

            panelDashboard.Visible = true;
            panelScanMain.Visible = false;
            panelExport.Visible = false;

            labelHeading.Text = buttonDashboard.Text;
        }

        private void buttonScan_Click(object sender, EventArgs e)
        {
            panelLeft.Height = buttonScan.Height;
            panelLeft.Top = buttonScan.Top;

            panelDashboard.Visible = false;
            panelScanMain.Visible = true;
            panelExport.Visible = false;

            labelHeading.Text = buttonScan.Text;
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            panelLeft.Height = buttonExport.Height;
            panelLeft.Top = buttonExport.Top;

            panelDashboard.Visible = false;
            panelScanMain.Visible = false;
            panelExport.Visible = true;

            labelHeading.Text = buttonExport.Text;
        }

        private void linkTo(String url)
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

        private void linkGitHub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkTo("https://github.com/DavidBakerEffendi");
        }

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

        private void buttonExit_MouseEnter(object sender, EventArgs e) => buttonExit.BackColor = Color.FromArgb(1, 244, 81, 30);

        private void buttonExit_MouseLeave(object sender, EventArgs e) => buttonExit.BackColor = Color.FromArgb(255, 33, 33, 33);

        private void buttonExit_Click(object sender, EventArgs e) => Application.Exit();

        private void buttonMinimize_Click(object sender, EventArgs e) => this.WindowState = FormWindowState.Minimized;

        private void panelToolbar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            linkTo("https://github.com/DavidBakerEffendi");
        }

        private void buttonNew_Click(object sender, EventArgs e)
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
                this.databaseModel.PopulateDataGrid(this.dataGrid);
                this.labelDbName.Text = this.databaseModel.getCurrentFileName();
                this.SetDatabasePanelEnabled(true);
            }

        }

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

        public void SetDatabasePanelEnabled(bool enable)
        {
            this.panelDatabase.Enabled = enable;
        }

        private void buttonOpenDb_Click(object sender, EventArgs e)
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
                this.databaseModel.SetCurrentFile(dlg.FileName);
                this.databaseModel.PopulateDataGrid(this.dataGrid);
                this.labelDbName.Text = this.databaseModel.getCurrentFileName();
                this.SetDatabasePanelEnabled(true);
            }
        }

        private void buttonSaveDb_Click(object sender, EventArgs e)
        {
            // TODO
        }

        // Returns true if the user has selected to read data from the scanner, false if otherwise.
        public Boolean GetToggleScanner()
        {
            return this.checkToggleScanner.Checked;
        }

        public void SetScannerReady(bool flag)
        {
            this.checkToggleScanner.Enabled = flag;
        }

        public void SetScannerDriverStatus(bool flag)
        {
            this.BeginInvoke(new MethodInvoker(() =>
            {
                this.pictureDriverCheck.Visible = flag;
                this.pictureDriverUncheck.Visible = !flag;
            }));
        }

        public void SetScannerDeviceStatus(bool flag)
        {
            this.BeginInvoke(new MethodInvoker(() =>
            {
                this.pictureDeviceCheck.Visible = flag;
                this.pictureDeviceUncheck.Visible = !flag;
            }));
        }

        public void SetNetworkConnectedStatus(bool flag)
        {
            this.BeginInvoke(new MethodInvoker(() =>
            {
                this.pictureNetworkDisconnect.Visible = !flag;
                this.pictureNetworkConnect.Visible = flag;
            }));
        }

        public void SetNetworkLocalIP(string ip)
        {
            this.BeginInvoke(new MethodInvoker(() =>
            {
                this.labelLocalIP.Text = ip;
            }));
        }
    }
}
