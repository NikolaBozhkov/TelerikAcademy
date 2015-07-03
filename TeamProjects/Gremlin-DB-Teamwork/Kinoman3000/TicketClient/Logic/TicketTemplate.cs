using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mongo = CinemaSystem.Mongo.Models;

namespace TicketClient.Logic
{
    public class ScreeningInfo
    {
        public ScreeningInfo()
        {
            this.TakenSeats = new List<int>();
        }
        
        public mongo.Screening Screening {get;set;}
        public List<int> TakenSeats { get; set; }
    }
    
    public class TicketTemplate
    {
        public TicketTemplate()
        {
            this.Screenings = new Dictionary<string, ScreeningInfo>();            
        }

        public mongo.Movie Movie { get; set; }

        public Dictionary<string, ScreeningInfo> Screenings { get; set; }        
    }
}
