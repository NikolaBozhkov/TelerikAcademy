namespace TicketClient
{
    using CinemaSystem.Mongo.Data;
    using mongo = CinemaSystem.Mongo.Models;
    using MongoDB.Driver;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using sql = CinemaSystem.Models;
    using CinemaSystem.Data;
    using TicketClient.Logic;
    using System.Globalization;
    using System.Data.SqlClient;
    using ZipExcel.Client;
    using System.Diagnostics;


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public const string PDF_REPORTS_DIR = @"..\..\..\IssuedTickets";
        public const string SQL_DB = ".\\SQLEXPRESS";

        Dictionary<string, Controls.Ticket> ticketsInList;
        private CinemaMongoData mongoData;
        //private CinemaSystemData sqlData;//=new CinemaSystemData();

        public IQueryable<mongo.Movie> mongoMovies;
        public Dictionary<string, TicketTemplate> mongoActiveMovies = new Dictionary<string, TicketTemplate>();
        public IQueryable<mongo.Ticket> mongoTickets;
        public IQueryable<mongo.Screening> mongoScreenings;

        public IQueryable<sql.Movie> sqlMovies;
        public IQueryable<sql.Ticket> sqlTickets;
        public IQueryable<sql.Screening> sqlScreenings;

        public static void ShowWarning(string message)
        {
            MessageBox.Show(message, "Kinoman 3000", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        // private LoadingWindow loadingW=new LoadingWindow("Loading...");

        public void ShowLoading()
        {
            //ProgressBar loadingBar = new ProgressBar() { IsIndeterminate = true ,Width=60,Height=15};

            //this.Loading_Bar_Progress.Children.Add(loadingBar);
            //this.loadingW.Title = title;
            //this.loadingW.Show();           
        }

        public void HideLoading()
        {
            //this.Loading_Bar_Progress.Children.Clear();
        }

        public MainWindow()
        {
            this.InitializeComponent();

            System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            this.ShowLoading();

            this.ticketsInList = new Dictionary<string, Controls.Ticket>();

            //load mongo db stuff
            this.mongoData = new CinemaMongoData();
            this.mongoMovies = this.mongoData.Movies;
            this.mongoTickets = this.mongoData.Tickets;
            this.mongoScreenings = this.mongoData.Screenings;            

            //CinemaSystemDbContext context=new CinemaSystemDbContext();
            //this.sqlData = new CinemaSystemData();
            //this.sqlTickets=this.sqlData.

            IEnumerable<string> screeningTitles = this.mongoScreenings.Select<mongo.Screening, string>(s => s.MovieTitle);

            //select active movies manually
            //join does not work with mongo provider!
            foreach (string title in screeningTitles)
            {
                foreach (mongo.Movie movie in this.mongoMovies.AsEnumerable())
                {
                    if (movie.Title == title)
                    {
                        if (!this.mongoActiveMovies.ContainsKey(title))
                        {
                            Dictionary<string, ScreeningInfo> screenings = new Dictionary<string, ScreeningInfo>();
                            IEnumerable<mongo.Screening> screeningsForThisMovie = this.mongoScreenings.Where(s => s.MovieTitle == title);

                            foreach (mongo.Screening screen in screeningsForThisMovie.AsEnumerable())
                            {
                                ScreeningInfo screenInfo = new ScreeningInfo() { Screening = screen };

                                //FOR PERFORMANCE...
                                SqlConnection dbCon = new SqlConnection("Server=" + MainWindow.SQL_DB + "; " + "Database=CinemaSystem; Integrated Security=true");
                                //SqlConnection dbCon = new SqlConnection("Server=.; " + "Database=CinemaSystem; Integrated Security=true");

                                //
                                dbCon.Open();
                                //
                                SqlCommand screeningTicks = new SqlCommand(
                                    @"SELECT * FROM Tickets t WHERE t.ScreeningId=" + screen.ScreeningId + ";", dbCon);
                                //
                                SqlDataReader reader = screeningTicks.ExecuteReader();
                                //      
                                using (reader)
                                {
                                    while (reader.Read())
                                    {
                                        screenInfo.TakenSeats.Add(int.Parse(reader["SeatNumber"].ToString()));
                                    }
                                }

                                dbCon.Close();

                                CultureInfo provider = CultureInfo.InvariantCulture;
                                string scrKey = screen.Date.ToString() + "_" + screen.CinemaHallName.ToString();
                                //
                                if (!screenings.ContainsKey(scrKey))
                                {
                                    screenings.Add(scrKey, screenInfo);
                                }
                            }

                            TicketTemplate tTemplate = new TicketTemplate()
                            {
                                Movie = movie,
                                Screenings = screenings,
                                //later add ticket seats
                            };

                            this.mongoActiveMovies.Add(title, tTemplate);
                        }
                    }
                }
            }

            //
            //this.activeMovies=from movie in 

            //this.sqlData = new CinemaSystemData();
            // sqlData.Movies;
            // sqlData.Screenings;
            // sqlData.Tickets;      
            // in this manner you can go to the SQL DB collections

            this.HideLoading();
        }

        private void MouseOver(object sender, MouseEventArgs e)
        {
            Control uielement = sender as Control;
            if (uielement != null)
            {
                this.ToolTip_Bar.Content = uielement.ToolTip.ToString();
            }
        }

        private void MouseOut(object sender, MouseEventArgs e)
        {
            this.ToolTip_Bar.Content = String.Empty;
        }

        public void ShowNewTicketControl()
        {
            Controls.NewTicket newTicketControl = new Controls.NewTicket(this);
            this.NewTicket_Container.Children.Clear();
            this.NewTicket_Container.Children.Add(newTicketControl);
        }

        public void HideNewTicketControl()
        {
            this.NewTicket_Container.Children.Clear();
        }

        public void AddTicketToList(sql.Ticket ticket)
        {
            string newKey = "ticket" + DateTime.Now.ToFileTime();
            Controls.Ticket newTicket = new Controls.Ticket(ticket, this, newKey);
            this.ticketsInList.Add(newKey, newTicket);
            this.Tickets_List.Children.Add(newTicket);
        }



        public void RemoveTicketFromList(string key)
        {
            string searchKey=this.ticketsInList[key].ticket.Screening.Movie.Title;
            string projKey=this.ticketsInList[key].ticket.Screening.Date+"_"+this.ticketsInList[key].ticket.Screening.CinemaHall.Name;
            if(this.mongoActiveMovies.ContainsKey(searchKey))
            {
                this.mongoActiveMovies[searchKey].Screenings[projKey].TakenSeats.Add(this.ticketsInList[key].ticket.SeatNumber);
            }
            this.Tickets_List.Children.Remove(this.ticketsInList[key]);
            this.ticketsInList.Remove(key);
        }

        private void NewTicked_Button_Click(object sender, RoutedEventArgs e)
        {
            ShowNewTicketControl();
        }

        private void DoReports_Button_Click(object sender, RoutedEventArgs e)
        {
            this.DoReports();
        }

        private void DoReports()
        {
            string sqliteReport = @"..\..\..\Excels\Expences.xls";

            var ew = new ExcelWriter();
            var table = ew.ReadFromSQLite(@"..\..\..\cinema_expenses", "day_expenses", @"..\..\..\Excels\file.xlsx");
            ExcelWriter.Save(sqliteReport, table);


            string mySqlReport = @"..\..\..\Excels\Incomes.xls";

            var tableMySql = ew.ReadFromMySql(@"cinema_income", "screenings_income");
            ExcelWriter.Save(mySqlReport, tableMySql);

            Process.Start(sqliteReport);
            Process.Start(mySqlReport);
        }


        public static MessageBoxResult AskForExtendedConfirmation(string message)
        {
            MessageBoxResult confirm = MessageBox.Show(message, "Confirm", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            return confirm;
        }

        public static MessageBoxResult AskForConfirmation(string message)
        {
            MessageBoxResult confirm = MessageBox.Show(message, "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
            return confirm;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //bool hasChanges = !CheckForDefaultState();
            if (true)//hasChanges)
            {
                MessageBoxResult confirm = AskForExtendedConfirmation("Dont you need to submit the daily reports, before you leave?");
                if (confirm == MessageBoxResult.Yes)
                {
                    this.Cursor = Cursors.Wait;
                    this.DoReports();
                    this.Cursor = Cursors.Arrow;
                }
                else if (confirm != MessageBoxResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MoviesShowing_Button_Click(object sender, RoutedEventArgs e)
        {
            MoviesWindow moviesWindow = new MoviesWindow(this);
            moviesWindow.Show();
        }

    }
}
