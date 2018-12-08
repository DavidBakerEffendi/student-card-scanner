using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StudentCardScanner.Model
{
    /// <summary>
    /// The main DatabaseModel class.
    /// Contains all methods for performing basic database related actions.
    /// </summary>
    class DatabaseModel
    {

        public const int SIGN_IN = 0x0;
        public const int SIGN_OUT = 0x1;
        private const string TABLE_NAME = "tbl_student_scans";
        private const string STUDENT_NO_COL = "student_number";
        private const string SIGN_IN_COL = "sign_in_time";
        private const string SIGN_OUT_COL = "sign_out_time";

        private String currentFile = "";
        private String connString = "";
        private DataGridView dataGrid;

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

        // Creates a new access database and populates it with the templates table and columns.
        public bool CreateNewAccessDatabase()
        {
            bool result = false;
            if (currentFile.Equals(""))
            {
                return result;
            }

            this.cat = new ADOX.Catalog();
            this.table = new ADOX.Table();

            // Create the table and it's fields. 
            table.Name = TABLE_NAME;
            table.Columns.Append(STUDENT_NO_COL);
            table.Columns.Append(SIGN_IN_COL);
            table.Columns.Append(SIGN_OUT_COL);

            try
            {
                this.cat.Create(this.connString);
                this.cat.Tables.Append(table);
                this.conn = cat.ActiveConnection as ADODB.Connection;
                this.CloseCurrentConnection();

                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }

        internal void InsertData(string studentNumber, int mode)
        {
            DateTime logTime = DateTime.Today;
            String query = "INSERT INTO " + TABLE_NAME + "(" + STUDENT_NO_COL + "," + SIGN_IN_COL + ", " + SIGN_OUT_COL + ") ";
            switch (mode)
            {
                case SIGN_IN:
                    query += "VALUES (" + studentNumber + ", " + logTime + ", null);";
                    break;
                case SIGN_OUT:
                    query += "VALUES (" + studentNumber + ", null, " + logTime + ");";
                    break;
            }

            Console.WriteLine("Executing query: '" + query + "'");

            try
            {
                this.OpenNewConnection();
                ADODB.Recordset rs = new ADODB.Recordset();
                rs.Open(query, conn);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: '" + ex.ToString() + "'");
            }
            finally
            {
                this.CloseCurrentConnection();
            }
        }

        internal void UpdateData(string studentNumber, int mode)
        {

        }

        public bool StudentNumberExists(string studentNumber)
        {
            String query = "Select " + STUDENT_NO_COL + " from " + TABLE_NAME + " where " + STUDENT_NO_COL + "=" + studentNumber;
            try
            {
                this.OpenNewConnection();
                ADODB.Recordset rs = new ADODB.Recordset();
                rs.Open(query, conn);

                Console.WriteLine("fields " + rs.Fields.Count);

                if (rs.Fields.Count > 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                this.CloseCurrentConnection();
            }

        }

        // Opens a new ADODB connection using the current file name
        public void OpenNewConnection()
        {
            if (this.conn == null)
                this.conn = new ADODB.Connection();
            if (this.conn.State == 0)
                this.conn.Open(this.connString);
        }

        // Closes the current ADODB connection
        public void CloseCurrentConnection()
        {
            if (this.conn != null)
            {
                if (this.conn.State == 1)
                    this.conn.Close();
            }
        }

        // Populates the given data grid with what is currently in the database connected to the program 
        internal void PopulateDataGrid()
        {
            this.OpenNewConnection();
            ADODB.Recordset rs = new ADODB.Recordset();
            rs.Open("Select * From " + TABLE_NAME, this.conn);
            dataGrid.DataSource = rs;
            this.CloseCurrentConnection();
        }

        internal void PopulateDataGrid(DataGridView dataGrid)
        {
            this.dataGrid = dataGrid;
            this.PopulateDataGrid();
        }
    }
}
