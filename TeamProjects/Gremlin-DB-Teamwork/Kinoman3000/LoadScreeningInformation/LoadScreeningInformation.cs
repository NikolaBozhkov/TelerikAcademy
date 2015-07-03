namespace LoadScreeningInformation
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Xml;

    using CinemaSystem.Mongo.Data;
    using CinemaSystem.Mongo.Models;

    public class LoadScreeningInformation
    {
        public static void Main()
        {
            Console.WriteLine("Parsing XML screening reports...");
            
            XmlTextReader reader = new XmlTextReader("../../../ProjectionStorage.xml");
            List<Screening> newListScreeningColection = new List<Screening>();

            string title = string.Empty;
            string hallName = string.Empty;
            int hallSeats = 0;
            int screeningId = 0;
            decimal price = 0;
            var date = new DateTime();
            bool readOpened = false;

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        readOpened = true;
                        while (reader.MoveToNextAttribute())
                        {
                            if (reader.Name == "Title")
                            {
                                title = reader.Value;
                            }
                            else if (reader.Name == "CinemaHallName")
                            {
                                hallName = reader.Value;
                            }
                            else if (reader.Name == "CinemaHallSeats")
                            {
                                hallSeats = int.Parse(reader.Value);
                            }
                            else if (reader.Name == "ScreeningId")
                            {
                                screeningId = int.Parse(reader.Value);
                            }
                            else if (reader.Name == "Price")
                            {
                                price = decimal.Parse(reader.Value);
                            }
                            else
                            {
                                CultureInfo provider = CultureInfo.InvariantCulture;
                                date = DateTime.Parse(reader.Value, provider);
                            }
                        }

                        break;
                    case XmlNodeType.EndElement:
                        if (readOpened)
                        {
                            Screening newScreening = new Screening();
                            newScreening.MovieTitle = title;
                            newScreening.Date = date;
                            newScreening.CinemaHallName = hallName;
                            newScreening.SeatsCount = hallSeats;
                            newScreening.ScreeningId = screeningId;
                            newScreening.Price = price;

                            newListScreeningColection.Add(newScreening);
                        }
                        readOpened = false;
                        break;
                }
            }

            var mango = new CinemaMongoData();
            mango.Screenings.DeleteAll();

            foreach (var screening in newListScreeningColection)
            {
                mango.Screenings.Add(screening);
            }
        }
    }
}