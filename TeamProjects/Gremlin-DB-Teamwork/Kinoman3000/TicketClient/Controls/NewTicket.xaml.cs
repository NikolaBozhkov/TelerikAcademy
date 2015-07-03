namespace TicketClient.Controls
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
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
    using models = CinemaSystem.Mongo.Models;
    using CinemaSystem.Reporters;
    using sql = CinemaSystem.Models;
    using Logic;
    using System.Diagnostics;
    using CinemaSystem.Data;
    using System.Data.SqlClient;


    /// <summary>
    /// Interaction logic for NewTicket.xaml
    /// </summary>
    public partial class NewTicket : UserControl
    {
        private MainWindow parentWindow;

        public NewTicket(MainWindow parentWindow)
        {
            InitializeComponent();
            this.parentWindow = parentWindow;
            this.FillData();
        }

        private void CancelTicketCreation_Button_Click(object sender, RoutedEventArgs e)
        {
            this.parentWindow.HideNewTicketControl();
        }

        private void CreateTicket_Button_Click(object sender, RoutedEventArgs e)
        {

            bool valid=true;
            foreach (UIElement grid in this.NewTicket_Grid.Children)
            {
                if (grid is Grid)
                {
                    Grid gridControl = grid as Grid;
                    foreach (UIElement childControl in gridControl.Children)
                    {
                        if (childControl is ComboBox)
                        {
                            ComboBox comboChild = childControl as ComboBox;
                            if (comboChild.SelectedIndex == -1)
                            {
                                valid = false;
                            }
                        }
                    }
                }
            }

            if (valid == false)
            {
                MainWindow.ShowWarning("You must fill all the fields to create a new ticket.");
                return;
            }

            this.parentWindow.ShowLoading();

            ComboBoxItem selectedItem = this.Movie_Selector.SelectedItem as ComboBoxItem;
            TicketTemplate tTemplate = selectedItem.Tag as TicketTemplate;

            ComboBoxItem timeItem = this.ScreeningTime_Selector.SelectedItem as ComboBoxItem;

            string time = timeItem.Tag.ToString();
            string hall = this.ScreeningHall_Selector.SelectedItem.ToString();
            string key = time + "_" + hall;
             
            sql.Ticket ticket = new sql.Ticket();
            ticket.ScreeningId = tTemplate.Screenings[key].Screening.ScreeningId;
            ComboBoxItem seatNumber = this.Seat_Selector.SelectedItem as ComboBoxItem;
            ticket.SeatNumber = int.Parse(seatNumber.Content.ToString());
            ticket.Price = tTemplate.Screenings[key].Screening.Price;
            ticket.IsDiscounted = this.HasDiscount_Checkbox.IsChecked.Value;                       
            //
            //FOR PERFORMANCE...
            SqlConnection dbCon = new SqlConnection("Server=" + MainWindow.SQL_DB + "; " + "Database=CinemaSystem; Integrated Security=true");
            //SqlConnection dbCon = new SqlConnection("Server=.; " + "Database=CinemaSystem; Integrated Security=true");

            //
            dbCon.Open();
            //
            SqlCommand insertNewTicket = new SqlCommand(string.Format(@"INSERT INTO Tickets(ScreeningId, SeatNumber, Price)VALUES({0},{1},{2})",ticket.ScreeningId,ticket.SeatNumber,ticket.Price), dbCon);            
            //
            insertNewTicket.ExecuteNonQuery();

            //Do seat removal
            //...

            sql.Movie movieee = new sql.Movie() {
                Title = tTemplate.Movie.Title
            };

            sql.Screening screaming = new sql.Screening();
            //
            screaming.CinemaHall = new sql.CinemaHall() { Name = hall };
            screaming.Date = DateTime.Parse(time);
            screaming.Movie = movieee;

            ticket.Screening = screaming;

            string keyo = @"" + int.Parse(seatNumber.Content.ToString()) + "_" + tTemplate.Screenings[key].Screening.ScreeningId;

            PdfReporter pdfka = new PdfReporter();
            string pdfTicketName = MainWindow.PDF_REPORTS_DIR +keyo+".pdf";
            //MessageBox.Show(pdfTicketName);
            pdfka.GenerateTicketPdf(ticket, pdfTicketName);            
            Process.Start(pdfTicketName);
            //
            this.parentWindow.AddTicketToList(ticket);
            this.parentWindow.HideNewTicketControl();

            tTemplate.Screenings[key].TakenSeats.Add(ticket.SeatNumber);
            selectedItem.Tag=tTemplate;

            //
            dbCon.Close();
            //
            this.parentWindow.HideLoading();
        }

        private void MouseOver(object sender, MouseEventArgs e)
        {
            Control uielement = sender as Control;
            if (uielement != null)
            {
                this.parentWindow.ToolTip_Bar.Content = uielement.ToolTip.ToString();
            }
        }

        private void MouseOut(object sender, MouseEventArgs e)
        {
            this.parentWindow.ToolTip_Bar.Content = String.Empty;
        }

        private void FillData()
        {
            this.Movie_Selector.Items.Clear();

            foreach (TicketTemplate tTemplate in this.parentWindow.mongoActiveMovies.Values)
            {
                ComboBoxItem movieItem = new ComboBoxItem()
                {
                    Content = tTemplate.Movie.Title,
                    Tag = tTemplate
                };                              

                this.Movie_Selector.Items.Add(movieItem);
            }

            this.ScreeningTime_Selector.Items.Clear();
            this.ScreeningHall_Selector.Items.Clear();
            this.Seat_Selector.Items.Clear();
        }

        private void UpdateTicketPrice()
        { 
            ComboBoxItem selectedItem = this.Movie_Selector.SelectedItem as ComboBoxItem;
            TicketTemplate tTemplate = selectedItem.Tag as TicketTemplate;
            //
            ComboBoxItem timeCItem = this.ScreeningTime_Selector.SelectedItem as ComboBoxItem;
            string hallCItem = this.ScreeningHall_Selector.SelectedItem as string;

            if (hallCItem != null && timeCItem != null)
            {
                string key = timeCItem.Tag + "_" + hallCItem;

                sql.Ticket ticket = new sql.Ticket();
                ticket.Price=tTemplate.Screenings[key].Screening.Price;

                ticket.IsDiscounted=this.HasDiscount_Checkbox.IsChecked.Value;

                this.TicketPrice.Content = String.Format("{0:f2}",ticket.Price);
            }
        }

        private void Movie_Selector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FillTimeSelector();
            //FillHallSelector();

            FillSeats();

        }

        private void FillSeats()
        {           
            ComboBoxItem selectedItem = this.Movie_Selector.SelectedItem as ComboBoxItem;
            TicketTemplate tTemplate = selectedItem.Tag as TicketTemplate;

            this.Seat_Selector.Items.Clear();

            ComboBoxItem timeCItem = this.ScreeningTime_Selector.SelectedItem as ComboBoxItem;
            string hallCItem = this.ScreeningHall_Selector.SelectedItem as string;

            if (hallCItem != null && timeCItem != null)
            {
                string key = timeCItem.Tag + "_" + hallCItem;

                for (int u = 1; u <= tTemplate.Screenings[key].Screening.SeatsCount; u++)
                {
                    //
                    if (tTemplate.Screenings[key].TakenSeats.Contains(u) == false)
                    {
                        ComboBoxItem seatN = new ComboBoxItem();
                        seatN.Content = u;
                        this.Seat_Selector.Items.Add(seatN);
                    }
                }
            }
        }


        private void FillHallSelector(string timeFilter = null)
        {
            ComboBoxItem selectedItem = this.Movie_Selector.SelectedItem as ComboBoxItem;
            TicketTemplate tTemplate = selectedItem.Tag as TicketTemplate;

            this.ScreeningHall_Selector.Items.Clear();
            //
            foreach (var hall in tTemplate.Screenings)
            {
                if (timeFilter == null || hall.Key == timeFilter + "_" + hall.Value.Screening.CinemaHallName)
                {
                    if (!this.ScreeningHall_Selector.Items.Contains(hall.Value.Screening.CinemaHallName))
                    {
                        this.ScreeningHall_Selector.Items.Add(hall.Value.Screening.CinemaHallName);
                    }
                }
            }
            CancelsHIT = true;
            this.ScreeningHall_Selector.SelectedIndex = 0;
        }

        private void FillTimeSelector(string hallFilter = null)
        {
            ComboBoxItem selectedItem = this.Movie_Selector.SelectedItem as ComboBoxItem;
            TicketTemplate tTemplate = selectedItem.Tag as TicketTemplate;

            this.ScreeningTime_Selector.Items.Clear();
            //
            List<string> added = new List<string>();
            foreach (ScreeningInfo scr in tTemplate.Screenings.Values)
            {

                if (hallFilter != null)
                {
                    if (scr.Screening.CinemaHallName != hallFilter)
                    {
                        continue;
                    }
                }

                ComboBoxItem scrTime = new ComboBoxItem()
                {
                    Content = scr.Screening.Date.ToString(),
                    Tag = scr.Screening.Date.ToString()
                };


                if (!added.Contains(scr.Screening.Date.ToString()))
                {
                    this.ScreeningTime_Selector.Items.Add(scrTime);//dd.mm.yyyy
                }

                added.Add(scr.Screening.Date.ToString());
            }

            this.ScreeningTime_Selector.SelectedIndex = 0;
        }

        private void ScreeningTime_Selector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem timeCItem = this.ScreeningTime_Selector.SelectedItem as ComboBoxItem;
            if (timeCItem != null)
            {
                this.FillHallSelector((timeCItem.Tag as string));
                this.FillSeats();
                this.UpdateTicketPrice();
            }
        }

        private bool CancelsHIT = false;

        private void ScreeningHall_Selector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.FillSeats();
            if (CancelsHIT == true)
            {
                return;
            }

            string hallCItem = this.ScreeningHall_Selector.SelectedItem as string;
            if (hallCItem != null)
            {
                this.FillHallSelector(hallCItem);
                this.UpdateTicketPrice();
            }
            CancelsHIT = false;
        }

        private void HasDiscount_Checkbox_Checked(object sender, RoutedEventArgs e)
        {
            this.UpdateTicketPrice();
        }

        private void HasDiscount_Checkbox_Unchecked(object sender, RoutedEventArgs e)
        {
            this.UpdateTicketPrice();
        }

    }
}
