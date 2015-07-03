using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace ZipExcel.Client
{
    public class ExcelWriter
    {
        private SQLiteConnection con;

        public ExcelWriter()
        {
            
        }

        public DataTable ReadFromSQLite(string database, string table, string filePath)
        {
            DataTable DT = new DataTable();
            this.con = new SQLiteConnection("Data Source=" + database);
            con.Open();
            var cmd = con.CreateCommand();
            cmd.CommandText = string.Format("SELECT * FROM {0}", table);
            var adapter = new SQLiteDataAdapter(cmd);
            adapter.AcceptChangesDuringFill = false;
            adapter.Fill(DT);
            con.Close();
            DT.TableName = table;
            con.Close();
            return DT;
        }

        public static void Save(string excelFile, DataTable table)
        {
            using (ExcelWriterBetter writer = new ExcelWriterBetter(excelFile))
            {
                writer.WriteStartDocument();

                writer.WriteStartWorksheet(string.Format("{0}", table.TableName)); // Write the worksheet contents
                writer.WriteStartRow(); //Write header row
                foreach (DataColumn col in table.Columns)
                {
                    writer.WriteExcelUnstyledCell(col.Caption);
                }
                writer.WriteEndRow();
                foreach (DataRow row in table.Rows)
                { //write data
                    writer.WriteStartRow();
                    foreach (object o in row.ItemArray)
                    {
                        writer.WriteExcelAutoStyledCell(o);
                    }
                    writer.WriteEndRow();
                }
                writer.WriteEndWorksheet(); // Close up the document

                writer.WriteEndDocument();
                writer.Close();
            }
        }

        MySqlConnection conMySql;

        public DataTable ReadFromMySql(string database, string table)
        {
            DataTable DT = new DataTable();
            string connString = String.Format("server=localhost;user={1};password={2};database={0};port=3306;Convert Zero Datetime=True", database, "root", "");
            this.conMySql = new MySqlConnection(connString);
            conMySql.Open();
            var cmd = conMySql.CreateCommand();
            cmd.CommandText = string.Format("SELECT * FROM {0}", table);
            var adapter = new MySqlDataAdapter(cmd);
            adapter.AcceptChangesDuringFill = false;
            adapter.Fill(DT);
            conMySql.Close();
            DT.TableName = table;
            return DT;
        }

        //public void WriteOnExcelFromSQLite()
        //{
        //    var bookRepository = new SQLiteBookRepository(@"..\..\books_repository");
        //
        //    bookRepository.OpenConnection();
        //
        //    bookRepository.Truncate();
        //}
        

        //public void Write(string fileDirectory)
        //{
        //    string excelConString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
        //        fileDirectory + ";Extended Properties='Excel 12.0 xml;HDR=Yes';";
        //    
        //    var excelCon = new OleDbConnection(excelConString);
        //    excelCon.Open();
        //    
        //    DataTable excelSchema = excelCon.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
        //    string sheetName = excelSchema.Rows[0]["TABLE_NAME"].ToString();
        //    
        //    using (excelCon)
        //    {
        //        foreach (var balance in filmBalances)
        //        {
        //            OleDbCommand cmdInsertNameScore = new OleDbCommand(@"INSERT INTO [" + sheetName + @"] VALUES (@filmId, @expences, @income)", excelCon);
        //            cmdInsertNameScore.Parameters.AddWithValue("@filmId", balance.FilmID);
        //            cmdInsertNameScore.Parameters.AddWithValue("@expences", balance.Expences);
        //            cmdInsertNameScore.Parameters.AddWithValue("@income", balance.Income);
        //            
        //            //                                       
        //            var queryResult = cmdInsertNameScore.ExecuteNonQuery();
        //        }
        //    }
        //
        //}
    }
}
