namespace CinemaSystem.Data
{
    using System.Data.Entity;
    using CinemaSystem.Models;
    using System.Data.Entity.Infrastructure;

    public interface ICinemaSystemDbContext
    {
        IDbSet<Movie> Movies { get; set; }

        IDbSet<Screening> Screenings { get; set; }

        IDbSet<CinemaHall> CinemaHalls { get; set; }

        IDbSet<Ticket> Tickets { get; set; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        void SaveChanges();
    }
}