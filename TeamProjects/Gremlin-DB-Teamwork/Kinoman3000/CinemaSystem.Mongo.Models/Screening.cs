namespace CinemaSystem.Mongo.Models
{
    using System;
    using System.Linq;
    using MongoRepository;

    /// <summary>
    /// Acts as a Screening tamplate in generating MongoDB
    /// </summary>
    public class Screening : Entity
    {
        public Screening(DateTime screeningDate, string filmTitle)
        {
            this.Date = screeningDate;
            this.MovieTitle = filmTitle;
        }

        public Screening()
        {
        }

        public DateTime Date { get; set; }

        public string MovieTitle { get; set; }

        public string CinemaHallName { get; set; }

        public int SeatsCount { get; set; }

        public int ScreeningId { get; set; }

        public decimal Price { get; set; }
    }
}