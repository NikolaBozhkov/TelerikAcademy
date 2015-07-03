namespace CinemaSystem.Data
{
    using System;
    using System.Collections.Generic;

    using CinemaSystem.Data.Repositories;
    using CinemaSystem.Models;

    /// <summary>
    ///  This is the unit of work class. Here is proved that a single context is used and it is given to the client using
    ///  the GenericReposity properties
    /// </summary>
    public class CinemaSystemData : ICinemaSystemData
    {
        private readonly ICinemaSystemDbContext context;
        private readonly IDictionary<Type, object> repositories;

        // Poor man's DI to be easily used without the knowledge of the client to instantiate the ICinemaContext
        public CinemaSystemData()
            : this(new CinemaSystemDbContext())
        {
        }

        public CinemaSystemData(ICinemaSystemDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IGenericRepository<Movie> Movies
        {
            get
            {
                return this.GetRepository<Movie>();
            }
        }

        public IGenericRepository<Screening> Screenings
        {
            get
            {
                return this.GetRepository<Screening>();
            }
        }

        public IGenericRepository<Ticket> Tickets
        {
            get
            {
                return this.GetRepository<Ticket>();
            }
        }

        public IGenericRepository<CinemaHall> CinemaHalls
        {
            get
            {
                return this.GetRepository<CinemaHall>();
            }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        private IGenericRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(GenericRepository<T>);

                //if (typeOfModel.IsAssignableFrom(typeof(Movie)))
                //{
                //    type = typeof(MoviesRepository);
                //}

                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IGenericRepository<T>)this.repositories[typeOfModel];
        }
    }
}