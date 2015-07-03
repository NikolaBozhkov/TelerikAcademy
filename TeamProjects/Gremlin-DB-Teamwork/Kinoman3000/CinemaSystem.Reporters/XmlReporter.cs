namespace CinemaSystem.Reporters
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    using CinemaSystem.Data;

    public class XmlReporter : IReporter
    {
        public void Report(ICinemaSystemData data, string reportFileLocation)
        {
            var movieData = data.Movies.All();
            var screeningDaa = data.Screenings.All();
            var cinemaHalls = data.CinemaHalls.All();

            var reportData = from m in movieData
                             join s in screeningDaa on m.Id equals s.MovieId
                             join c in cinemaHalls on s.CinemaHallId equals c.Id
                             select new
                             {
                                 Title = m.Title,
                                 ScreeningId = s.Id,
                                 ScreeningDate = s.Date,
                                 Price = s.TicketPrice,
                                 CinemaHallName = c.Name,
                                 CinemaHallSeats = c.Seats
                             };

            XElement root = new XElement("Projections");

            foreach (var item in reportData)
            {
                XElement projection = new XElement("Projection",string.Empty);
                projection.SetAttributeValue("Title", item.Title);
                projection.SetAttributeValue("ScreeningId", item.ScreeningId);
                projection.SetAttributeValue("ScreeningDate", item.ScreeningDate);
                projection.SetAttributeValue("CinemaHallName", item.CinemaHallName);
                projection.SetAttributeValue("CinemaHallSeats", item.CinemaHallSeats);
                projection.SetAttributeValue("Price", item.Price); 

                root.Add(projection);
            }

            root.Save(reportFileLocation);
        }
    }
}