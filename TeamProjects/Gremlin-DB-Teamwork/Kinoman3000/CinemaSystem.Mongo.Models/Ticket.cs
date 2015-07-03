namespace CinemaSystem.Mongo.Models
{
    using System;
    using System.Linq;

    using MongoRepository;
    using MongoDB.Bson.Serialization.Attributes;

    /// <summary>
    /// Acts as a template for the TicketType object
    /// </summary>
    public class Ticket : Entity
    {
        private const decimal DiscountFactor = 0.75M;

        private decimal price;

        public Ticket(decimal price, int seatNumber, bool isDiscounted = false)
        {
            this.Price = price;
            this.SeatNumber = seatNumber;
            this.IsDiscounted = isDiscounted;
        }

        public Ticket()
        {
        }

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

        [BsonIgnore]
        public bool IsDiscounted { get; set; }
    }
}