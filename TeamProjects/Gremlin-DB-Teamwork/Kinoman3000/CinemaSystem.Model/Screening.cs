namespace CinemaSystem.Models
{
    using System;
    using System.Linq;

    public class Screening
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public decimal TicketPrice { get; set; }

        public virtual int CinemaHallId { get; set; }

        public virtual CinemaHall CinemaHall { get; set; }

        public virtual int MovieId { get; set; }

        public virtual Movie Movie { get; set; }
    }
}