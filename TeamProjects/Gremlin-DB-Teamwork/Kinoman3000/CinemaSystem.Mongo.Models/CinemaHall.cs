namespace CinemaSystem.Mongo.Models
{
    using System;
    using System.Linq;

    using MongoRepository;

    /// <summary>
    /// Acts as a template for the CinemaHall BSON documents
    /// </summary>
    public class CinemaHall : Entity
    {
        public CinemaHall(int seats, string hallName = null)
        {
            this.Name = hallName;
            this.Seats = seats;
        }

        public CinemaHall()
        {
        }

        public string Name { get; set; }

        public int Seats { get; set; }
    }
}