namespace CinemaSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class Ticket
    {
        private const decimal DiscountFactor = 0.75M;

        private decimal price;

        public int Id { get; set; }

        public virtual int ScreeningId { get; set; }

        public virtual Screening Screening { get; set; }

        public int SeatNumber { get; set; }

        public decimal Price
        {
            get
            {
                if (this.IsDiscounted)
                {
                    return this.price * DiscountFactor;
                }
                else
                {
                    return this.price;
                }
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Ticket price cannot be negative.");
                }

                this.price = value;
            }
        }

        [NotMapped]
        public bool IsDiscounted { get; set; }
    }
}