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
using System.Windows.Navigation;
using System.Windows.Shapes;
using models = CinemaSystem.Mongo.Models;


namespace TicketClient.Controls
{
    /// <summary>
    /// Interaction logic for Movie.xaml
    /// </summary>
    public partial class Movie : UserControl
    {
        private models.Movie movieData;

        public Movie(models.Movie movieData)
        {
            InitializeComponent();
            this.movieData = movieData;

            this.FillMovieTab();
        }

        private void FillMovieTab()
        {
            this.Movie_Cast.Text = "Cast: " + movieData.Cast;
            this.Movie_Description.Text = "Description: " + movieData.Description;
            this.Movie_Director.Content = "Director: " + movieData.Director;
            this.Movie_Duration.Content = "Duration: " + movieData.Duration;
            this.Movie_Rating.Content = "Rating: " + movieData.Rating;
            this.Movie_Title.Content = movieData.Title;
            this.Movie_Year.Content = "Year: " + movieData.Year;
        }
    }
}