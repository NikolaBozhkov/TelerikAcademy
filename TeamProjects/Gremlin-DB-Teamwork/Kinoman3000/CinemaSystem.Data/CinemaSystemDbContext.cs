namespace CinemaSystem.Data
{
    using CinemaSystem.Data;
    using CinemaSystem.Data.Migrations;
    using CinemaSystem.Models;
    using System.Data.Entity;

    public class CinemaSystemDbContext : DbContext, ICinemaSystemDbContext
    {
        public CinemaSystemDbContext()
            : base("CinemaSystemConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CinemaSystemDbContext, Configuration>());
            //Database.SetInitializer(new DropCreateDatabaseAlways<CinemaSystemDbContext>());
        }

        public IDbSet<Movie> Movies { get; set; }

        public IDbSet<Screening> Screenings { get; set; }

        public IDbSet<CinemaHall> CinemaHalls { get; set; }

        public IDbSet<Ticket> Tickets { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}