namespace CinemaSystem.ConsoleClient
{
    using CinemaSystem.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CinemaSystem.Models;
    using CinemaSystem.Reporters;
    using ZipExcel;
    using ZipExcel.Client;

    class Program
    {
        static void Main()
        {
            var data = new CinemaSystemData();

            //#region Cinema Halls
            //var cinemaHalls = new List<CinemaHall>
            //{
            //    new CinemaHall()
            //    {
            //        Name = "Ultimate",
            //        Seats = 64
            //    },
            //    new CinemaHall()
            //    {
            //        Name = "Enterprice",
            //        Seats = 32
            //    },
            //    new CinemaHall()
            //    {
            //        Name = "Deluxe",
            //        Seats = 200
            //    }
            //};
            //#endregion

            //#region Movies
            //var movies = new List<Movie>
            //{

            //    new Movie
            //    {
            //        Title = "The Shawshank Redemption",
            //        Description = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency",
            //        Director = "Frank Darabont",
            //        Duration = 142,
            //        Year = 1994,
            //        Cast = "Tim Robbins, Morgan Freeman, Bob Gunton",
            //        Rating = 9.3
            //    },
            //    new Movie
            //    {
            //        Title = "The Godfather",
            //        Description = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.",
            //        Director = "Francis Ford Coppola",
            //        Duration = 175,
            //        Year = 1972,
            //        Cast = "Marlon Brando, Al Pacino, James Caan",
            //        Rating = 9.2
            //    },
            //    new Movie
            //    {
            //        Title = "The Dark Knight",
            //        Description = "When Batman, Gordon and Harvey Dent launch an assault on the mob, they let the clown out of the box, the Joker, bent on turning Gotham on itself and bringing any heroes down to his level.",
            //        Director = "Christopher Nolan",
            //        Duration = 152,
            //        Year = 2008,
            //        Cast = "Christian Bale, Heath Ledger, Aaron Eckhart",
            //        Rating = 9.0
            //    },
            //    new Movie
            //    {
            //        Title = "Inception ",
            //        Description = "A thief who steals corporate secrets through use of dream-sharing technology is given the inverse task of planting an idea into the mind of a CEO.",
            //        Director = "Christopher Nolan",
            //        Duration = 148,
            //        Year = 2010,
            //        Cast = "Leonardo DiCaprio, Joseph Gordon-Levitt, Ellen Page",
            //        Rating = 8.8
            //    },
            //    new Movie
            //    {
            //        Title = "The Silence of the Lambs",
            //        Description = "A young F.B.I. cadet must confide in an incarcerated and manipulative killer to receive his help on catching another serial killer who skins his victims.",
            //        Director = "Jonathan Demme",
            //        Duration = 118,
            //        Year = 1991,
            //        Cast = " Jodie Foster, Anthony Hopkins, Lawrence A. Bonney",
            //        Rating = 8.6
            //    },
            //    new Movie
            //    {
            //        Title = "Twixt",
            //        Description = "A writer with a declining career arrives in a small town as part of his book tour and gets caught up in a murder mystery involving a young girl. That night in a dream, he is approached by a mysterious young ghost named V. He's unsure of her connection to the murder in the town, but is grateful for the story being handed to him. Ultimately he is led to the truth of the story, surprised to find that the ending has more to do with his own life than he could ever have anticipated.",
            //        Director = "Francis Ford Coppola",
            //        Duration = 88,
            //        Year = 2011,
            //        Cast = "Val Kilmer, Bruce Dern, Elle Fanning ",
            //        Rating = 4.9
            //    },
            //    new Movie
            //    {
            //        Title = "Guardians of the Galaxy",
            //        Description = "Light years from Earth, 26 years after being abducted, Peter Quill finds himself the prime target of a manhunt after discovering an orb wanted by Ronan the Accuser.",
            //        Director = "James Gunn",
            //        Duration = 121,
            //        Year = 2014,
            //        Cast = "Chris Pratt, Vin Diesel, Bradley Cooper",
            //        Rating = 8.6
            //    },
            //    new Movie
            //    {
            //        Title = "The Expendables 3",
            //        Description = "Barney augments his team with new blood for a personal battle: to take down Conrad Stonebanks, the Expendables co-founder and notorious arms trader who is hell bent on wiping out Barney and every single one of his associates.",
            //        Director = "Patrick Hughes",
            //        Duration = 126,
            //        Year = 2014,
            //        Cast = "Chris Pratt, Vin Diesel, Bradley Cooper",
            //        Rating = 6.3
            //    },
            //    new Movie
            //    {
            //        Title = "X-Men: First Class",
            //        Description = "In 1962, the United States government enlists the help of Mutants with superhuman abilities to stop a malicious dictator who is determined to start world war III.",
            //        Director = "Matthew Vaughn",
            //        Duration = 132,
            //        Year = 2011,
            //        Cast = "James McAvoy, Michael Fassbender, Jennifer Lawrence",
            //        Rating = 7.8
            //    },
            //    new Movie
            //    {
            //        Title = "Kick-Ass",
            //        Description = "Dave Lizewski is an unnoticed high school student and comic book fan who one day decides to become a super-hero, even though he has no powers, training or meaningful reason to do so.",
            //        Director = "Matthew Vaughn",
            //        Duration = 117,
            //        Year = 2010,
            //        Cast = " Aaron Taylor-Johnson, Nicolas Cage, Chloë Grace Moretz",
            //        Rating = 7.8
            //    },
            //    new Movie
            //    {
            //        Title = "The Counselor",
            //        Description = "A lawyer finds himself in over his head when he gets involved in drug trafficking.",
            //        Director = "Ridley Scott",
            //        Duration = 117,
            //        Year = 2013,
            //        Cast = "Michael Fassbender, Penélope Cruz, Cameron Diaz",
            //        Rating = 5.4
            //    },
            //    new Movie
            //    {
            //        Title = "American Gangster",
            //        Description = "In 1970s America, a detective works to bring down the drug empire of Frank Lucas, a heroin kingpin from Manhattan, who is smuggling the drug into the country from the Far East.",
            //        Director = "Ridley Scott",
            //        Duration = 157,
            //        Year = 2007,
            //        Cast = "Denzel Washington, Russell Crowe, Chiwetel Ejiofor",
            //        Rating = 7.8
            //    },
            //    new Movie
            //    {
            //        Title = "Gladiator",
            //        Description = "When a Roman general is betrayed and his family murdered by an emperor's corrupt son, he comes to Rome as a gladiator to seek revenge.",
            //        Director = "Ridley Scott",
            //        Duration = 155,
            //        Year = 2000,
            //        Cast = " Russell Crowe, Joaquin Phoenix, Connie Nielsen",
            //        Rating = 8.5
            //    },
            //    new Movie
            //    {
            //        Title = "The Kingdom of Heaven",
            //        Description = "Balian of Ibelin travels to Jerusalem during the crusades of the 12th century, and there he finds himself as the defender of the city and its people.",
            //        Director = "Ridley Scott",
            //        Duration = 144,
            //        Year = 2005,
            //        Cast = " Russell Crowe, Joaquin Phoenix, Connie Nielsen",
            //        Rating = 7.2
            //    },
            //    new Movie
            //    {
            //        Title = "Get Rich or Die Tryin'",
            //        Description = "A tale of an inner city drug dealer who turns away from crime to pursue his passion, rap music.",
            //        Director = "Jim Sheridan",
            //        Duration = 117,
            //        Year = 2005,
            //        Cast = " Russell Crowe, Joaquin Phoenix, Connie Nielsen",
            //        Rating = 4.8
            //    },
            //    new Movie
            //    {
            //        Title = "Fear and Loathing in Las Vegas",
            //        Description = "An oddball journalist and his psychopathic lawyer travel to Las Vegas for a series of psychedelic escapades.",
            //        Director = "Terry Gilliam",
            //        Duration = 118,
            //        Year = 2005,
            //        Cast = " Johnny Depp, Benicio Del Toro, Tobey Maguire",
            //        Rating = 7.7
            //    },
            //    new Movie
            //    {
            //        Title = "From Hell",
            //        Description = "In Victorian Era London, a troubled clairvoyant police detective investigates the murders by Jack The Ripper.",
            //        Director = "Albert Hughes",
            //        Duration = 122,
            //        Year = 2005,
            //        Cast = "Johnny Depp, Heather Graham, Ian Holm",
            //        Rating = 6.8
            //    }
            //};
            //#endregion

            //#region Screenings
            //var screenings = new List<Screening> 
            //{
            //    new Screening()
            //{
            //        CinemaHall = cinemaHalls[0],
            //        Date = DateTime.Now,
            //        Movie = movies[0],
            //        TicketPrice = 213
            //    },
            //    new Screening()
            //    {
            //        CinemaHall = cinemaHalls[1],
            //        Date = DateTime.Now,
            //        Movie = movies[0],
            //        TicketPrice = 213
            //    },
            //    new Screening()
            //    {
            //        CinemaHall = cinemaHalls[0],
            //        Date = DateTime.Now,
            //        Movie = movies[2],
            //        TicketPrice = 213
            //    },
            //    new Screening()
            //    {
            //        CinemaHall = cinemaHalls[1],
            //        Date = DateTime.Now,
            //        Movie = movies[4],
            //        TicketPrice = 7.5m
            //    },
            //    new Screening()
            //    {
            //    Date = DateTime.Now,
            //    CinemaHall = cinemaHalls[2],
            //    Movie = movies[5],
            //    TicketPrice=7.5m
            //}                
            //};
            //#endregion

            //#region Tickets
            //var tickets = new List<Ticket>()
            //{
            //    new Ticket
            //    {
            //        Screening = screenings[0],
            //        SeatNumber = 21,
            //        Price = 10,
            //        IsDiscounted = true
            //    },
            //    new Ticket
            //    {
            //        Screening = screenings[1],
            //        SeatNumber = 23,
            //        Price = 11,
            //        IsDiscounted = false
            //    },
            //    new Ticket
            //    {
            //        Screening = screenings[2],
            //        SeatNumber = 12,
            //        Price = 7,
            //        IsDiscounted = true
            //    },
            //    new Ticket
            //    {
            //        Screening = screenings[3],
            //        SeatNumber = 8,
            //        Price = 21,
            //        IsDiscounted = false
            //    },
            //};
            //#endregion

            //foreach (var movie in movies)
            //{
            //    data.Movies.Add(movie);
            //}

            //foreach (var hall in cinemaHalls)
            //{
            //    data.CinemaHalls.Add(hall);
            //}

            //foreach (var screening in screenings)
            //{
            //    data.Screenings.Add(screening);
            //}

            //foreach (var t in tickets)
            //{
            //    data.Tickets.Add(t);
            //}

            //data.SaveChanges();


            //////XmlReporter reporter = new XmlReporter();
            //////reporter.Report(data, "../../../ProjectionStorage.xml");

            ////JsonReporter jsonReporter = new JsonReporter();
            ////Dictionary<string, string> d = new Dictionary<string, string>();

            ////d.Add("pesho", "peshev");
            ////d.Add("ivan", "ivanov");

            ////jsonReporter.Report(d,"dict");

            ////jsonReporter.Report(d, "dict");


            Console.WriteLine("Generating screening XML reports...");
            XmlReporter reporter = new XmlReporter();
            reporter.Report(data, "../../../ProjectionStorage.xml");

            /*var ew = new ExcelWriter();
            var table = ew.ReadFromSQLite(@"..\..\..\cinema_expenses", "day_expenses", @"..\..\..\Excels\file.xlsx");
            ExcelWriter.Save(@"..\..\..\Excels\file.xls", table);

            var tableMySql = ew.ReadFromMySql(@"cinema_income", "screenings_income");
            ExcelWriter.Save(@"..\..\..\Excels\file2.xls", tableMySql);*/
        }
    }
}

