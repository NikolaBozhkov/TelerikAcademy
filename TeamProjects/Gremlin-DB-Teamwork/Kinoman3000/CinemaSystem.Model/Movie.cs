namespace CinemaSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class Movie
    {
        private int duration;
        private double rating;
        private int year;

        private ICollection<Screening> screenings;

        public Movie()
        {
            this.screenings = new HashSet<Screening>();
        }

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public string Cast { get; set; }

        public string Director { get; set; }

        public int Duration
        {
            get
            {
                return this.duration;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Movie duration should a positive number standing for the movie duration in minutes.");
                }

                this.duration = value;
            }
        }

        public double Rating
        {
            get
            {
                return this.rating;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Movie's rating should a positive number standing for the IMDB movie rating.");
                }

                this.rating = value;
            }
        }

        public int Year
        {
            get
            {
                return this.year;
            }

            set
            {
                if (value < 1900)
                {
                    throw new ArgumentException("Movie's year should be a 4-digit number bigger than 1900.");
                }

                this.year = value;
            }
        }

        public virtual ICollection<Screening> Screenings
        {
            get
            {
                return this.screenings;
            }

            set
            {
                this.screenings = value;
            }
        }
    }
}