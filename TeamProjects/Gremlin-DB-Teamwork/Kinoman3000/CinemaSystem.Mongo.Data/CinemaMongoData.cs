namespace CinemaSystem.Mongo.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CinemaSystem.Mongo.Models;
    using MongoRepository;

    public class CinemaMongoData
    {
        private readonly IDictionary<Type, object> repositories;

        public CinemaMongoData()
        {
            this.repositories = new Dictionary<Type, object>();
        }

        public MongoRepository<Movie> Movies
        {
            get
            {
                return this.GetRepository<Movie>();
            }
        }

        public MongoRepository<Screening> Screenings
        {
            get
            {
                return this.GetRepository<Screening>();
            }
        }

        public MongoRepository<Ticket> Tickets
        {
            get
            {
                return this.GetRepository<Ticket>();
            }
        }

        public MongoRepository<CinemaHall> CinemaHalls
        {
            get
            {
                return this.GetRepository<CinemaHall>();
            }
        }

        private MongoRepository<T> GetRepository<T>() where T : Entity
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(MongoRepository<T>);

                this.repositories.Add(typeOfModel, Activator.CreateInstance(type));
            }

            return (MongoRepository<T>)this.repositories[typeOfModel];
        }
    }
}