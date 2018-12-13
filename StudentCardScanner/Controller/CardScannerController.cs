using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using StudentCardScanner.Model;

namespace StudentCardScanner.Controller
{
    class SerialPortController
    {
        private DatabaseModel databaseModel;
        private MainForm form;
        private SerialPort port = new SerialPort("COM8", 19200, Parity.None, 8, StopBits.One);
        private Queue<byte> receivedData = new Queue<byte>();
        private readonly int INCOMING_SIZE = 26;

        public SerialPortController(MainForm form, DatabaseModel databaseModel)
        {
            this.form = form;
            this.databaseModel = databaseModel;
            // Attach a method to be called when there
            // is data waiting in the port's buffer
            port.DataReceived += new
              SerialDataReceivedEventHandler(port_DataReceived);
            // Begin communications
            port.Open();
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
            Console.WriteLine("processingData...");
            // Determine if we have a "packet" in the queue
            if (receivedData.Count > INCOMING_SIZE)
            {
                var packet = Enumerable.Range(0, INCOMING_SIZE).Select(i => receivedData.Dequeue());
                String studentNumber = Encoding.Default.GetString(packet.ToArray()).Substring(8, 8);
                Console.WriteLine("SU card: " + studentNumber);
                this.LogStudentNumber(studentNumber);
            }
        }

        internal void LogStudentNumber(string studentNumber)
        {
            Console.WriteLine("LogStudentNumber(" + studentNumber + ")");
            this.form.setLastCardScanned(studentNumber);

            if (!this.databaseModel.StudentNumberExists(studentNumber))
            {
                Console.WriteLine("Student number does not exist, creating new entry...");
                this.databaseModel.InsertData(studentNumber, this.form.GetSignMode());
            } else
            {
                Console.WriteLine("Student number does exist, updating existing entry...");
                this.databaseModel.UpdateData(studentNumber, this.form.GetSignMode());
            }

            this.databaseModel.PopulateDataGrid();
        }

    }
}
