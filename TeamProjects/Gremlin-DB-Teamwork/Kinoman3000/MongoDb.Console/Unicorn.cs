namespace MongoDb.Console
{
    using CinemaSystem.Mongo.Data;
    using CinemaSystem.Mongo.Models;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Used to create the main data in the cinema DB, mongoDB
    /// </summary>
    class Unicorn
    {
        static void Main()
        {
            var repo = new CinemaMongoData();
            //MovieRepository moviesData = new MovieRepository();
            //CinemaHallRepository cinemaHallsData = new CinemaHallRepository();

            //foreach (var movie in Zamunda.Films)
            //{
            //    repo.Movies.Add(movie);
            //}

            var cinemaHalls = new List<CinemaHall>
            {
                new CinemaHall(200,"Deluxe"),
                new CinemaHall(50,"Light"),
                new CinemaHall(300,"Ultimate")
            };

            foreach (var cl in cinemaHalls)
            {
                repo.CinemaHalls.Add(cl);
            }
            repo.Screenings.Add(
                new Screening
                {
                    Date = DateTime.Now,
                    MovieTitle = "Lord of the rings",
                    Price = 15
                });

            var tickets = new List<Ticket>()
            {
                new Ticket
                {
                    SeatNumber = 10,
                    Price = 20
                },
                new Ticket
                {
                    SeatNumber = 100,
                    Price = 20,
                    IsDiscounted =true
                },
            };

            foreach (var t in tickets)
            {
                repo.Tickets.Add(t);
            }

        }
    }
}