namespace CinemaSystem.Data
{
    using CinemaSystem.Data.Repositories;
    using CinemaSystem.Models;

    public interface ICinemaSystemData
    {
        IGenericRepository<Movie> Movies { get; }

        IGenericRepository<Screening> Screenings { get; }

        IGenericRepository<Ticket> Tickets { get; }

        IGenericRepository<CinemaHall> CinemaHalls { get; }
    }
}