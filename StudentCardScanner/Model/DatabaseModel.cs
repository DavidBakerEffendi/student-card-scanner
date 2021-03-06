﻿using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
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
        public const string DATE_TIME_FORMAT = "yyyy/MM/dd hh:mm:ss tt";
        public const string TABLE_NAME = "tbl_student_scans";
        public const string STUDENT_NO_COL = "student_number";
        public const string SIGN_IN_COL = "sign_in_time";
        public const string SIGN_OUT_COL = "sign_out_time";

        private String currentFile = "";
        private String connString = "";
        private DataGridView dataGrid;
        private readonly MainForm form;

        private ADOX.Catalog cat;
        private ADOX.Table table;
        private ADODB.Connection conn;

        public DatabaseModel(MainForm mainView)
        {
            this.form = mainView;
        }

        /// <summary>
        /// Sets the current file name with the given file name.
        /// </summary>
        /// <param name="fileName">Absolute directory of the file.</param>
        public void SetCurrentFile(string fileName)
        {
            this.currentFile = fileName;
            this.connString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + fileName + "; Jet OLEDB:Engine Type=5";
        }

        /// <summary>
        /// Getter for the currently selected Access database's file name.
        /// </summary>
        /// <returns>The file name and extension without path.</returns>
        public String GetCurrentFileName()
        {
            return currentFile.Substring(currentFile.LastIndexOf("\\") + 1, currentFile.Length - 1 - currentFile.LastIndexOf("\\"));
        }

        /// <summary>
        /// Deletes the currently selected Access database.
        /// </summary>
        public void DeleteCurrentFile()
        {
            if (File.Exists(this.currentFile))
            {
                File.Delete(this.currentFile);
            }
        }

        /// <summary>
        /// Creates a new access database and populates it with the templates table and columns.
        /// </summary>
        /// <returns>True if database created and selected successfully, false if otherwise.</returns>
        public bool CreateNewAccessDatabase()
        {
            bool result = false;
            if (currentFile.Equals(""))
            {
                return result;
            }
            if (File.Exists(@currentFile))
            {
                try {
                    File.Delete(@currentFile);
                } catch (Exception)
                {
                    MessageBox.Show("Unable to replace file \"" + @currentFile + "\"! It may already " +
                        "be in use by another applicaton.", "Database Create Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
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
                if (this.conn != null)
                {
                    if (this.conn.State == 1)
                        this.conn.Close();
                }

                result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Inserts the given student number into the database and sets a sign in or out timestamp depending on the mode.
        /// </summary>
        /// <param name="studentNumber">The student number to log.</param>
        /// <param name="mode">The logging mode, i.e., DatabaseModel.SIGN_IN or DatabaseModel.SIGN_OUT</param>
        /// <returns>True if successfully inserted, false if otherwise.</returns>
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

        /// <summary>
        /// Updates the given student number into the database and sets a sign in or out timestamp depending on the mode.
        /// </summary>
        /// <param name="studentNumber">The student number to log.</param>
        /// <param name="mode">The logging mode, i.e., DatabaseModel.SIGN_IN or DatabaseModel.SIGN_OUT</param>
        /// <returns>True if successfully updated, false if otherwise.</returns>
        internal bool UpdateData(string studentNumber, int mode)
        {
            String logTime = DateTime.Now.ToString(DATE_TIME_FORMAT);
            String query = "UPDATE " + TABLE_NAME + " SET ";

            switch (mode)
            {
                case SIGN_IN:
                    if (!IsFieldNullAtSUNumber(studentNumber, SIGN_IN_COL))
                    {
                        form.FlashSignInPanel();
                        return false;
                    }
                    query += SIGN_IN_COL + "= #" + logTime + "#";
                    break;
                case SIGN_OUT:
                    if (!IsFieldNullAtSUNumber(studentNumber, SIGN_OUT_COL))
                    {
                        form.FlashSignInPanel();
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

        /// <summary>
        /// Checks if the given student number exists in the currently selected database.
        /// </summary>
        /// <param name="studentNumber">The student number to query.</param>
        /// <returns>True if the student number exists, false if otherwise.</returns>
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

        /// <summary>
        /// Checks if a given field (column) in the database is null at the record with the given username.
        /// </summary>
        /// <param name="studentNumber">The student number to query.</param>
        /// <param name="field">The field/column in the database to check if currently null or not.</param>
        /// <returns>
        /// True if the record returns null for the given student number or if the field at the record
        /// with the given student number is null. Returns false if otherwise.
        /// </returns>
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
                        if (reader.GetFieldValue<Object>(0) != DBNull.Value)
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

        /// <summary>
        /// Populates the given data grid with what is currently in the database connected to the program.
        /// </summary>
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
                this.form.SetTotalSignIns(this.dataGrid.RowCount);
            }));

            con.Close();
        }

        internal void ReadFromDatabase(DataGridView dataGrid)
        {
            this.dataGrid = dataGrid;
            this.ReadFromDatabase();
        }

    }
}
