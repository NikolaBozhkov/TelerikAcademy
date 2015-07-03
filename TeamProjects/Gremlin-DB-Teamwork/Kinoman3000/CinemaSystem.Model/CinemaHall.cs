namespace CinemaSystem.Models
{
    using System;
    using System.Collections.Generic;

    public class CinemaHall
    {
        private ICollection<Screening> screenings;
        private int seats;

        public CinemaHall()
        {
            this.screenings = new HashSet<Screening>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Seats
        {
            get
            {
                return this.seats;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The number of cinema hall seats should be a positive number.");
                }

                this.seats = value;
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