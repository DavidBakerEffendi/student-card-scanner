using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
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
        private const string DATE_TIME_FORMAT = "yyyy/MM/dd hh:mm:ss tt";
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

        public String getCurrentFileName()
        {
            return currentFile.Substring(currentFile.LastIndexOf("\\") + 1, currentFile.Length - 1 - currentFile.LastIndexOf("\\"));
        }

        // Creates a new access database and populates it with the templates table and columns.
        public bool CreateNewAccessDatabase()
        {
            bool result = false;
            if (currentFile.Equals(""))
            {
                return result;
            }
            if (File.Exists(@currentFile))
            {
                File.Delete(@currentFile);
            }

            this.cat = new ADOX.Catalog();
            this.table = new ADOX.Table();

            // Create the table and it's fields. 
            table.Name = TABLE_NAME;
            table.Columns.Append(STUDENT_NO_COL, ADOX.DataTypeEnum.adLongVarWChar);
            table.Columns.Append(SIGN_IN_COL, ADOX.DataTypeEnum.adDate);
            table.Columns.Append(SIGN_OUT_COL, ADOX.DataTypeEnum.adDate);
            table.Columns[SIGN_IN_COL].Attributes = ADOX.ColumnAttributesEnum.adColNullable;
            table.Columns[SIGN_OUT_COL].Attributes = ADOX.ColumnAttributesEnum.adColNullable;

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
                Console.WriteLine("Error: " + ex);
                result = false;
            }

            return result;
        }

        internal bool InsertData(string studentNumber, int mode)
        {
            String logTime = DateTime.Now.ToString(DATE_TIME_FORMAT);
            String query = "INSERT INTO " + TABLE_NAME + "(" + STUDENT_NO_COL + ", " + SIGN_IN_COL + ", " + SIGN_OUT_COL + ") ";
            switch (mode)
            {
                case SIGN_IN:
                    query += "VALUES ('" + studentNumber + "', #" + logTime + "#, null);";
                    break;
                case SIGN_OUT:
                    query += "VALUES ('" + studentNumber + "', null, #" + logTime + "#);";
                    break;
            }

            Console.WriteLine("Executing query: '" + query + "'");

            OleDbCommand command = new OleDbCommand(query);
            try
            {
                using (OleDbConnection connection = new OleDbConnection(this.connString))
                {
                    // Set the Connection to the new OleDbConnection.
                    command.Connection = connection;
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: '" + ex.ToString() + "'");
                return false;
            }
        }

        internal bool UpdateData(string studentNumber, int mode)
        {
            String logTime = DateTime.Now.ToString(DATE_TIME_FORMAT);
            String query = "UPDATE " + TABLE_NAME + " SET ";
            switch (mode)
            {
                case SIGN_IN:
                    if (!IsFieldNullAtSUNumber(studentNumber, SIGN_IN_COL))
                    {
                        MessageBox.Show("\"" + studentNumber + "\" has already signed in!", "Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    query += SIGN_IN_COL + "= #" + logTime + "#";
                    break;
                case SIGN_OUT:
                    if (!IsFieldNullAtSUNumber(studentNumber, SIGN_OUT_COL))
                    {
                        MessageBox.Show("\"" + studentNumber + "\" has already signed out!", "Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    query += SIGN_OUT_COL + "= #" + logTime + "#";
                    break;
            }
            query += " WHERE " + STUDENT_NO_COL + "='" + studentNumber + "';";

            Console.WriteLine("Executing query: '" + query + "'");

            OleDbCommand command = new OleDbCommand(query);
            try
            {
                using (OleDbConnection connection = new OleDbConnection(this.connString))
                {
                    // Set the Connection to the new OleDbConnection.
                    command.Connection = connection;
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: '" + ex.ToString() + "'");
                return false;
            }
        }

        // Checks if the given student number exists in the current database.
        public bool StudentNumberExists(string studentNumber)
        {
            String query = "SELECT " + STUDENT_NO_COL + " FROM " + TABLE_NAME + " WHERE " + STUDENT_NO_COL + "='" + studentNumber + "';";
            OleDbCommand command = new OleDbCommand(query);
 
            try
            {
                using (OleDbConnection connection = new OleDbConnection(this.connString))
                {
                    // Set the Connection to the new OleDbConnection.
                    command.Connection = connection;
                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();

                    // Open the connection and execute the insert command.
                    try
                    {
                        int count = 0;
                        // Always call Read before accessing data.
                        while (reader.Read())
                        {
                            count++;
                        }
                        
                        if (count > 0)
                        {
                            return true;
                        } else
                        {
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return false;
                    } finally
                    {
                        // Always call Close when done reading.
                        reader.Close();
                    }
                    // The connection is automatically closed when the
                    // code exits the using block.
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool IsFieldNullAtSUNumber(string studentNumber, string field)
        {
            String query = "SELECT " + field + " FROM " + TABLE_NAME + " WHERE " + STUDENT_NO_COL + "='" + studentNumber + "';";
            OleDbCommand command = new OleDbCommand(query);

            try
            {
                using (OleDbConnection connection = new OleDbConnection(this.connString))
                {
                    // Set the Connection to the new OleDbConnection.
                    command.Connection = connection;
                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();

                    // Open the connection and execute the insert command.
                    try
                    {
                        // Always call Read before accessing data.
                        reader.Read();
                        Console.WriteLine("Checking if field '" + reader.GetFieldValue<Object>(0) + "' null: " + reader.GetFieldValue<Object>(0).Equals(null));
                        if (!reader.GetFieldValue<Object>(0).Equals(null))
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return true;
                    }
                    finally
                    {
                        // Always call Close when done reading.
                        reader.Close();
                    }
                    // The connection is automatically closed when the
                    // code exits the using block.
                }
            }
            catch (Exception)
            {
                return true;
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
        internal void ReadFromDatabase()
        {
            OleDbConnection con = new OleDbConnection(this.connString);
            OleDbCommand cmd = new OleDbCommand("Select * From " + TABLE_NAME, con);
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
                this.dataGrid.Columns[0].Width = 105;
                this.dataGrid.Columns[1].Width = 180;
                this.dataGrid.Columns[2].Width = 180;
                this.dataGrid.ColumnHeadersHeight = 50;
            }));

            con.Close();
        }

        internal void PopulateDataGrid(DataGridView dataGrid)
        {
            this.dataGrid = dataGrid;
            this.ReadFromDatabase();
        }

    }
}
