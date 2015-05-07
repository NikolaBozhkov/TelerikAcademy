namespace Events
{
    using System;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class EventHolder
    {
        private MultiDictionary<string, Events> byTitle = new MultiDictionary<string, Events>(true);
        private OrderedBag<Events> byDate = new OrderedBag<Events>();

        public void AddEvent(DateTime date, string title, string location)
        {
            Events newEvent = new Events(date, title, location);
            this.byTitle.Add(title.ToLower(), newEvent);
            this.byDate.Add(newEvent);
            Messages.EventAdded();
        }

        public void DeleteEvents(string titleToDelete)
        {
            string title = titleToDelete.ToLower();

            int removed = 0;
            foreach (var eventToRemove in this.byTitle[title])
            {
                removed++;
                this.byDate.Remove(eventToRemove);
            }

            this.byTitle.Remove(title);
            Messages.EventDeleted(removed);
        }

        public void ListEvents(DateTime date, int count)
        {
            OrderedBag<Events>.View eventsToShow =
                this.byDate.RangeFrom(new Events(date, string.Empty, string.Empty), true);

            int showed = 0;
            foreach (var eventToShow in eventsToShow)
            {
                if (showed == count)
                {
                    break;
                }

                Messages.PrintEvent(eventToShow);
                showed++;
            }

            if (showed == 0)
            {
                Messages.NoEventsFound();
            }
        }
    }
}