using StudentCardScanner.Model;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;

namespace StudentCardScanner.Controller
{
    /// <summary>
    /// Controls the incoming data from the Mifare Secure card reader.
    /// </summary>
    class SerialPortController
    {
        private readonly DatabaseModel databaseModel;
        private readonly MainForm form;

        private SerialPort port;
        private string commPort;
        private Queue<byte> receivedData = new Queue<byte>();
        private readonly int INCOMING_SIZE = 26;

        /// <summary>
        /// Creates a SerialPortController class and initialises a local copy of references to the form and database model.
        /// </summary>
        /// <param name="form">The UI form.</param>
        /// <param name="databaseModel">The database model.</param>
        public SerialPortController(MainForm form, DatabaseModel databaseModel)
        {
            this.form = form;
            this.databaseModel = databaseModel;

            ThreadStart checkScanner = RunStatusCheck;
            new Thread(checkScanner).Start();
        }

        /// <summary>
        /// Checks the status of the necessary driver and whether the card scanner is connected or not.
        /// </summary>
        private void RunStatusCheck()
        {
            while (!this.form.Created)
            {
                // Wait until form is created
                Thread.Sleep(100);
            }

            if (ScannerReady())
            {
                if (!ConnectToDevice())
                {
                    // TODO: add port listener for a reconnect perhaps?
                }
            }
            else
            {
                Console.WriteLine("Scanner not ready!");
                this.form.SetScannerReady(false);
            }
        }

        /// <summary>
        ///  Checks if the current scanner is ready to scan or not.
        /// </summary>
        /// <returns>True if the scanner is ready, false if otherwise.</returns>
        public bool ScannerReady()
        {
            
            // Check if driver is installed:
            try
            {
                using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SYSTEM\\DriverDatabase\\DeviceIds\\USB\\VID_067B&PID_2303"))
                {
                    if (key == null)
                    {
                        this.form.SetScannerDriverStatus(false);
                        this.form.SetScannerDeviceStatus(false);
                        return false;
                    } else
                    {
                        this.form.SetScannerDriverStatus(true);
                        this.form.SetScannerDeviceStatus(false);
                    }
                }
            } catch (Exception)
            {
                this.form.SetScannerDriverStatus(false);
                this.form.SetScannerDeviceStatus(false);
                return false;
            }

            // Check if device is connected:
            try
            {
                using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"HARDWARE\\DEVICEMAP\\SERIALCOMM"))
                {
                    commPort = key.GetValue("\\DEVICE\\ProlificSerial0").ToString();
                    if (commPort == null)
                    {
                        this.form.SetScannerDeviceStatus(false);
                        return false;
                    } else
                    {
                        this.form.SetScannerDeviceStatus(true);
                    }
                }
            } catch (Exception)
            {
                this.form.SetScannerDeviceStatus(false);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Attempts to connect to the Mifare Secure card reader via the SerialPort API.
        /// </summary>
        /// <returns>True if connection successful, false if otherwise.</returns>
        public bool ConnectToDevice()
        {
            port = new SerialPort(commPort, 19200, Parity.None, 8, StopBits.One);
            // Attach a method to be called when there
            // is data waiting in the port's buffer
            port.DataReceived += new
              SerialDataReceivedEventHandler(port_DataReceived);
            try
            {
                // Begin communications
                port.Open();
                return true;
            } catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// An event listener for incoming serial data from the card scanner.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The SerialDataReceived event arguments object.</param>
        private void port_DataReceived(object sender,
          SerialDataReceivedEventArgs e)
        {
            // Show all the incoming data in the port's buffer
            byte[] data = new byte[port.BytesToRead];
            port.Read(data, 0, data.Length);
            data.ToList().ForEach(b => receivedData.Enqueue(b));
            processData();
        }

        /// <summary>
        /// Processes data and logs the student number when all 26 bytes of the incoming packet are captured.
        /// </summary>
        internal void processData()
        {
            // Determine if we have a "packet" in the queue
            if (receivedData.Count >= INCOMING_SIZE)
            {
                var packet = Enumerable.Range(0, INCOMING_SIZE).Select(i => receivedData.Dequeue());
                String studentNumber = Encoding.Default.GetString(packet.ToArray()).Substring(8, 8);
                this.LogStudentNumber(studentNumber);
            }
        }

        /// <summary>
        /// Logs the student number to the database.
        /// </summary>
        /// <param name="studentNumber">The student number to log.</param>
        internal void LogStudentNumber(string studentNumber)
        {
            // If data from scanner is not consented, then return.
            if (!this.form.GetToggleScanner()) return;

            bool result = false;

            if (!this.databaseModel.StudentNumberExists(studentNumber))
            {
                result = this.databaseModel.InsertData(studentNumber, this.form.GetSignMode());
            } else
            {
                result = this.databaseModel.UpdateData(studentNumber, this.form.GetSignMode());
            }

            this.form.SetLastCardScanned(studentNumber);

            if (result)
            {
                this.databaseModel.ReadFromDatabase();
            }
        }

    }
}
