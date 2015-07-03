namespace CinemaSystem.Mongo.Models
{
    using System;
    using System.Linq;

    using MongoRepository;

    /// <summary>
    /// Acts as a template for the Movie database stored in MongoDB 
    /// </summary>
    public class Movie : Entity
    {
        //[BsonConstructor] This shits makes problems
        public Movie(string movieTitle, string movieDescription, string movieCast,
            string movieDirectorsName, double movieRating, int movieDuration, int yearOfRelease)
        {
            this.Title = movieTitle;
            this.Description = movieDescription;
            this.Cast = movieCast;
            this.Director = movieDirectorsName;
            this.Rating = movieRating;
            this.Duration = movieDuration;
            this.Year = yearOfRelease;
        }

        public Movie()
        {
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Cast { get; set; }

        public string Director { get; set; }

        public double Rating { get; set; }

        public int Duration { get; set; }

        public int Year { get; set; }
    }
}