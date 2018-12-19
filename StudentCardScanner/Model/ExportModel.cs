using Microsoft.Office.Interop.Access;
using System;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace StudentCardScanner.Model
{
    class ExportModel
    {
        private string currentFile = "";
        private string connString = "";
        private DataGridView dataGrid;
        private string exportFileType = "";
        private string exportFilter = "";
        private string fileToExportTo = "";

        private ADOX.Catalog cat;
        private ADOX.Table table;
        private ADODB.Connection conn;

        /// <summary>
        /// Sets the current file name with the given file name.
        /// </summary>
        /// <param name="fileName">Absolute directory of the file.</param>
        public void SetCurrentFile(string fileName)
        {
            this.currentFile = fileName;
            this.connString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + fileName + "; Jet OLEDB:Engine Type=5";
        }

        public String GetCurrentFileName()
        {
            return currentFile.Substring(currentFile.LastIndexOf("\\") + 1, currentFile.Length - 1 - currentFile.LastIndexOf("\\"));
        }

        // Populates the given data grid with what is currently in the database connected to the program 
        internal void ReadFromDatabase()
        {
            OleDbConnection con = new OleDbConnection(this.connString);
            OleDbCommand cmd = new OleDbCommand("Select * From " + DatabaseModel.TABLE_NAME, con);
            con.Open();
            cmd.CommandType = CommandType.Text;
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable scores = new DataTable();
            da.Fill(scores);

            this.dataGrid.Invoke(new MethodInvoker(() => {
                this.dataGrid.DataSource = scores;
                this.dataGrid.Columns[0].HeaderText = "Student Number";
                this.dataGrid.Columns[1].HeaderText = "Sign In Time";
                this.dataGrid.Columns[2].HeaderText = "Sign Out Time";
                this.dataGrid.Columns[0].Width = 95;
                this.dataGrid.Columns[1].Width = 150;
                this.dataGrid.Columns[2].Width = 150;
                this.dataGrid.ColumnHeadersHeight = 50;
            }));

            con.Close();
        }

        internal void ReadFromDatabase(DataGridView dataGrid)
        {
            this.dataGrid = dataGrid;
            this.ReadFromDatabase();
        }

        public void setExportFileType(string fileType)
        {
            switch (fileType) {
                case ".xslx":
                    this.exportFilter = "Excel Files (*.xlsx)|*.xlsx";
                    break;
                case ".csv":
                    this.exportFilter = "CSV Files (*.csv)|*.csv";
                    break;
                default:
                    this.exportFilter = "";
                    break;
            }
            this.exportFileType = fileType;
        }

        public string getExportFileType()
        {
            return this.exportFileType;
        }

        public string getExportFilter()
        {
            return this.exportFilter;
        }

        public void ExportCurrentFileToExcel(string fileName)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            try
            {
                var application = new Microsoft.Office.Interop.Access.Application();
                application.OpenCurrentDatabase(this.currentFile);
                application.DoCmd.TransferSpreadsheet(AcDataTransferType.acExport,
                    AcSpreadSheetType.acSpreadsheetTypeExcel12Xml,
                    DatabaseModel.TABLE_NAME, fileName, true);
                application.CloseCurrentDatabase();
                application.Quit();
                Marshal.ReleaseComObject(application);
                MessageBox.Show("\"" + fileName + "\" saved successfully!", "Export Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch (Exception ex)
            {
                MessageBox.Show("\"" + fileName + "\" failed to export! Error: \"" + ex.ToString() +
                    "\".", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ExportCurrentFileToCSV(string fileName)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            // Instantiate string builder and headings
            StringBuilder sb = new StringBuilder();
            sb.Append(DatabaseModel.STUDENT_NO_COL + "," + DatabaseModel.SIGN_IN_COL + "," + DatabaseModel.SIGN_OUT_COL + "\n");

            try
            {
                // Microsoft Access provider factory
                DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.OleDb");
                using (DbConnection connection = factory.CreateConnection())
                {
                    connection.ConnectionString = this.connString;
                    connection.Open();
                    DbCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT * FROM [" + DatabaseModel.TABLE_NAME + "]";
                    DbDataReader reader = command.ExecuteReader(CommandBehavior.Default);

                    DataTable dt = new DataTable(DatabaseModel.TABLE_NAME + "_export");
                    dt.Load(reader);

                    foreach (DataRow row in dt.Rows)
                    {
                        foreach (DataColumn dc in row.Table.Columns)
                        {
                            sb.Append(row[dc.ColumnName].ToString());
                            sb.Append(",");
                        }
                        sb.Remove(sb.Length - 1, 1); // Remove the last comma 
                        sb.Append("\n");
                    }
                    connection.Close();
                }
            } catch (Exception ex)
            {
                MessageBox.Show("\"" + fileName + "\" failed to export! Failed to read from file: \"" + this.currentFile +
                    "\".", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.ToString());
                return;
            }
           
            try
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(fileName))
                {
                    sw.WriteLine(sb.ToString());
                }
                MessageBox.Show("\"" + fileName + "\" saved successfully!", "Export Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch (Exception ex)
            {
                MessageBox.Show("\"" + fileName + "\" failed to export! Error: \"" + ex.ToString() +
                   "\".", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
