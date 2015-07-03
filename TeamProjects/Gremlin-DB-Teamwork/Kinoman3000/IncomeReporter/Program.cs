using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Globalization;
using System.Threading;
using CinemaSystem.Reporters;

namespace IncomeReporter
{

    class ScreeningIncome
    {
        public string CinemaHallName { get; set; }
        public string MovieTitle { get; set; }
        public DateTime ScreeningTime { get; set; }
        public string SoldTickets { get; set; }
        public string Income { get; set; }

        public override string ToString()
        {
            return String.Format("{0} {1} {2} {3} {4} ",this.CinemaHallName, this.MovieTitle, this.ScreeningTime, this.SoldTickets, this.Income);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            string database = "cinema_income";
            string user = "root";
            string password = "";
            string connString = String.Format("server=localhost;user={1};password={2};database={0};port=3306;Convert Zero Datetime=True", database, user, password);
            //
            try
            {
                MySqlConnection connection = new MySqlConnection(connString);
                //
                SqlConnection dbCon = new SqlConnection("Server=.; " + "Database=CinemaSystem; Integrated Security=true");
                //SqlConnection dbCon = new SqlConnection("Server=.; " + "Database=CinemaSystem; Integrated Security=true");

                dbCon.Open();

                SqlCommand cmdCategoriesAndProducts = new SqlCommand(
                    @"SELECT MAX(c.Name) AS [CinemaHallName], MAX(m.Title) AS [MovieTitle], 
                    MAX(s.Date) AS [ScreeningTime] ,COUNT(*) AS [SoldTickets], 
                    COUNT(*) * MAX(s.TicketPrice) AS [Income] FROM Screenings s
                    INNER JOIN CinemaHalls c ON s.CinemaHallId=c.Id
                    INNER JOIN Movies m ON s.MovieID=m.Id
                    INNER JOIN Tickets t ON t.ScreeningId=s.Id
                    GROUP BY t.ScreeningId;", dbCon);

                SqlDataReader reader = cmdCategoriesAndProducts.ExecuteReader();
                List<ScreeningIncome> incomes = new List<ScreeningIncome>();
                Console.WriteLine("Sql Server connection established...");
                using (reader)
                {
                    while (reader.Read())
                    {
                        ScreeningIncome income = new ScreeningIncome();

                        income.CinemaHallName = (string)reader["CinemaHallName"].ToString();
                        income.MovieTitle = (string)reader["MovieTitle"].ToString();
                        income.ScreeningTime = (DateTime)reader["ScreeningTime"];
                        income.SoldTickets = (string)reader["SoldTickets"].ToString();
                        income.Income = (string)reader["Income"].ToString();
                        incomes.Add(income);
                    }
                }
                Console.WriteLine("Income reports generated...");
                connection.Open();
                //
                Console.WriteLine("MySql Server connection established...");
                string truncateQuery = "TRUNCATE screenings_income;";
                MySqlCommand cmdTruncate = new MySqlCommand(truncateQuery, connection);
                cmdTruncate.ExecuteNonQuery();
                //
                Console.WriteLine("Writing reports...");

                               
                var listOfIncomeDictionaries = new List<Dictionary<string, string>>();

                foreach (ScreeningIncome income in incomes)
                {
                    Console.WriteLine("-> "+income.ToString());
                    //
                    string insertQueryValues = String.Format("INSERT INTO screenings_income(MovieTitle,CinemaHallName,TicketsSold,Income,ScreeningTime)VALUES('{0}','{1}',{2},{3},'{4:yyyy/mm/dd hh:mm:ss}');", income.MovieTitle, income.CinemaHallName, income.SoldTickets, income.Income, income.ScreeningTime);

                    var incomeDictionary = new Dictionary<string, string>();

                    incomeDictionary.Add("Hall Name", income.CinemaHallName);
                    incomeDictionary.Add("Income", income.Income);
                    incomeDictionary.Add("Movie Title", income.MovieTitle);
                    incomeDictionary.Add("Screening Time", income.ScreeningTime.ToString());
                    incomeDictionary.Add("Sold Tickets", income.SoldTickets);

                    listOfIncomeDictionaries.Add(incomeDictionary);

                    MySqlCommand cmdInsertIncome= new MySqlCommand(insertQueryValues, connection);
                    cmdInsertIncome.ExecuteNonQuery();

                }
                var jsonReporter = new JsonReporter();
                string title = "Income Reports"; 
                jsonReporter.Report(listOfIncomeDictionaries, title);

                Console.WriteLine("Income report written to MySql Server...");
                connection.Close();
                
            }            
            catch (Exception genE)
            {
                Console.WriteLine(genE.Message);
            }
        }
    }
}
