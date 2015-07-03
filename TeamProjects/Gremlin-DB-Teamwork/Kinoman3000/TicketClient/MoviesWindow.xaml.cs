using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using models = CinemaSystem.Mongo.Models;


namespace TicketClient
{
    /// <summary>
    /// Interaction logic for MoviesWindow.xaml
    /// </summary>
    public partial class MoviesWindow : Window
    {
        private MainWindow parentWindow;
        public MoviesWindow(MainWindow parentWindow)
        {
            InitializeComponent();
            this.parentWindow = parentWindow;
            this.FeedMovieTabs();
        }

        public void AddMovieTab(models.Movie movie)
        {
            /*            <TabItem Header="TabItem">
                <Grid Background="#FFE5E5E5"/>
            </TabItem>
            <TabItem Header="TabItem">
                <Grid Background="#FFE5E5E5"/>
            </TabItem>*/

            TabItem newMovieTab = new TabItem();
            newMovieTab.Header = movie.Title;
            newMovieTab.VerticalContentAlignment = VerticalAlignment.Top;
            newMovieTab.Content = new Controls.Movie(movie);

            this.Movie_Tabs.Items.Add(newMovieTab);
        }

        private void Close_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void FeedMovieTabs()
        {
            this.Movie_Tabs.Items.Clear();
            foreach (var movie in this.parentWindow.mongoActiveMovies.Values)
            {                
                AddMovieTab(movie.Movie);
            }
        }
    }
}
