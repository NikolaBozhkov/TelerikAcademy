namespace ZipExcel.Client
{
    using System;
    using System.Data;
    using System.Data.OleDb;
    using System.Linq;

    using ZipExcel.Client.Contracts;

    internal class ExcelParser : IParser
    {
        public void Parse(string folderName, string pathOfFile)
        {
            var connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 12.0;", pathOfFile);
            var con = new OleDbConnection(connectionString);

            con.Open();
            using (con)
            {
                var dataTable = new DataTable();
                var adapter = new OleDbDataAdapter("SELECT * FROM [Tickets$] ", con);

                adapter.Fill(dataTable);

                foreach (var row in dataTable.Rows)
                {
                    // TODO: get data to be stored in the SQL DB
                }
            }
        }
    }
}