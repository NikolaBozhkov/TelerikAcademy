namespace CinemaSystem.Reporters
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class JsonReporter
    {
        private const string DefaultJsonReportPath = @"..\..\..\Reports\{0}.json";

        //public void Report(ICinemaSystemData data, string reportFileLocation)
        //{
        //var movieData = data.Movies.All();
        //var screeningDaa = data.Screenings.All();
        //var tickets = data.Tickets.All();
        //var reportData =
        //                from m in movieData
        //                join s in screeningDaa on m.Id equals s.MovieId
        //                join t in tickets on s.Id equals t.ScreeningId
        //                group m by new
        //                {
        //                    Title = m.Title,
        //                    Director = m.Director,
        //                    Cast = m.Cast,
        //                    Year = m.Year,
        //                    Duration = m.Duration,
        //                    TicketsSold = t.ScreeningId
        //                }
        //                into tsm select tsm;
        //}

        public void Report(IEnumerable<IDictionary<string, string>> data, string title)
        {
            StringBuilder json = new StringBuilder();

            json.AppendLine("[");

            foreach (var element in data)
            {
                json.AppendLine("\t{");
                foreach (var item in element)
                {
                    json.AppendLine(string.Format("\t\t\"{0}\" : \"{1}\",", item.Key, item.Value));
                    
                }
                json.AppendLine("\t},");
            }

            json.Length-=3; // delete last comma /','

            json.AppendLine();
            json.AppendLine("]");

            json.Replace(",\r\n\t}", "\r\n\t}");

            //json.Length -= 3;

            this.SaveJsonToFileSystem(json, title);
        }

        private void SaveJsonToFileSystem(StringBuilder json, string title)
        {
            var writer = new StreamWriter(string.Format(DefaultJsonReportPath, title), false, Encoding.UTF8);
            using (writer)
            {
                writer.Write(json.ToString());
            }
        }
    }
}