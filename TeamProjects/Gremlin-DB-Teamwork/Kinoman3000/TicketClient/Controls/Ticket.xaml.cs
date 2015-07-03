using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using logic = TicketClient.Logic;
using sql = CinemaSystem.Models;

namespace TicketClient.Controls
{
    /// <summary>
    /// Interaction logic for Ticket.xaml
    /// </summary>
    public partial class Ticket : UserControl
    {
        private MainWindow parentWindow;
        private string key;
        public sql.Ticket ticket {get;private set;}

        public Ticket(sql.Ticket ticket,MainWindow parentWindow,string key)
        {
            InitializeComponent();
            this.key = key;
            this.parentWindow = parentWindow;
            //
            string ticketString = ticket.Screening.Movie.Title + " " + ticket.Screening.CinemaHall.Name + " " + ticket.Screening.Date.ToString()+" Seat: "+ticket.SeatNumber;
            //
            this.ticket = ticket;
            //
            this.TicketLabel.Content = ticketString;
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

        private void TrashTicket_Button_Click(object sender, RoutedEventArgs e)
        {
             MessageBoxResult confirm = MainWindow.AskForConfirmation("Do you really want to delete this ticket record?");
             if (confirm == MessageBoxResult.Yes)
             {

                 //FOR PERFORMANCE...
                 SqlConnection dbCon = new SqlConnection("Server=" + MainWindow.SQL_DB + "; " + "Database=CinemaSystem; Integrated Security=true");
                 //SqlConnection dbCon = new SqlConnection("Server=.; " + "Database=CinemaSystem; Integrated Security=true");

                 //
                 dbCon.Open();
                 //
                 SqlCommand trashTicket = new SqlCommand(
                     @"DELETE FROM Tickets WHERE ScreeningId=" + this.ticket.ScreeningId + " AND SeatNumber=" + this.ticket.SeatNumber + ";", dbCon);
                 //
                 trashTicket.ExecuteNonQuery();
                 //                       
                 dbCon.Close();
                 //MessageBox.Show("Delete ticket from db...");
                 this.parentWindow.RemoveTicketFromList(this.key);
             }                         
        }
    }
}
