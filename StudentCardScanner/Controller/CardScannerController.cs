using StudentCardScanner.Model;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;

namespace StudentCardScanner.Controller
{
    class SerialPortController
    {
        private readonly DatabaseModel databaseModel;
        private readonly MainForm form;

        private SerialPort port;
        private string commPort;
        private Queue<byte> receivedData = new Queue<byte>();
        private readonly int INCOMING_SIZE = 26;

        public SerialPortController(MainForm form, DatabaseModel databaseModel)
        {
            this.form = form;
            this.databaseModel = databaseModel;

            ThreadStart checkScanner = RunStatusCheck;
            new Thread(checkScanner).Start();
        }

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
                    // TODO: add port listener perhaps?
                }
            }
            else
            {
                Console.WriteLine("Scanner not ready!");
                this.form.SetScannerReady(false);
            }
        }

        // Checks if the current scanner is ready to scan or not
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

        private void port_DataReceived(object sender,
          SerialDataReceivedEventArgs e)
        {
            // Show all the incoming data in the port's buffer
            byte[] data = new byte[port.BytesToRead];
            port.Read(data, 0, data.Length);
            data.ToList().ForEach(b => receivedData.Enqueue(b));
            processData();
        }

        void processData()
        {
            // Determine if we have a "packet" in the queue
            if (receivedData.Count >= INCOMING_SIZE)
            {
                var packet = Enumerable.Range(0, INCOMING_SIZE).Select(i => receivedData.Dequeue());
                String studentNumber = Encoding.Default.GetString(packet.ToArray()).Substring(8, 8);
                this.LogStudentNumber(studentNumber);
            }
        }

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

            if (result)
            {
                this.form.SetLastCardScanned(studentNumber);
                this.databaseModel.ReadFromDatabase();
            }
        }

    }
}
