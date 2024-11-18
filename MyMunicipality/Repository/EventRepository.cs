using MyMunicipality.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMunicipality.Repository
{
    public class EventRepository
    {
        private Dictionary<int, EventCard> events;
        private int currentId;

        public EventRepository()
        {
            events = new Dictionary<int, EventCard>();
            currentId = 1;

            PreloadDummyData();
        }

        private void PreloadDummyData()
        {
            events.Add(currentId, new EventCard
            {
                Id = currentId++,
                Title = "Water Outage",
                Category = "Utilities",
                Description = "Scheduled maintenance for water supply",
                Date = new DateTime(2024, 12, 01),
                Location = "Cape Town"
            });

            events.Add(currentId, new EventCard
            {
                Id = currentId++,
                Title = "Community Cleanup",
                Category = "Sanitation",
                Description = "Neighborhood cleanup event",
                Date = new DateTime(2024, 12, 05),
                Location = "Durban Central Park"
            });

            events.Add(currentId, new EventCard
            {
                Id = currentId++,
                Title = "Electricity Shutdown",
                Category = "Utilities",
                Description = "Electricity will be down for 4 hours",
                Date = new DateTime(2024, 11, 20),
                Location = "Johannesburg North"
            });

            events.Add(currentId, new EventCard
            {
                Id = currentId++,
                Title = "Public Hearing",
                Category = "Other",
                Description = "Discussing municipal budget for 2025",
                Date = new DateTime(2024, 11, 28),
                Location = "Pretoria City Hall"
            });

            events.Add(currentId, new EventCard
            {
                Id = currentId++,
                Title = "Fire Safety Workshop",
                Category = "Other",
                Description = "Fire safety measures and training",
                Date = new DateTime(2024, 12, 10),
                Location = "Port Elizabeth Fire Department"
            });
        }

        public void SaveEvent(EventCard eventCard)
        {
            if (eventCard.Id == 0)
            {
                eventCard.Id = currentId++;
                events[eventCard.Id] = eventCard;

            }
            else
            {
                events[eventCard.Id] = eventCard;
            }

        }

        // Delete event
        public void DeleteEvent(int eventId)
        {
            if (events.ContainsKey(eventId))
            {
                events.Remove(eventId);
            }
        }

        // Get all events
        public List<EventCard> GetAllEvents()
        {
            return events.Values.ToList();
        }

        // Get events by date
        public List<EventCard> GetEventsByDate(DateTime date)
        {
            return events.Values.Where(e => e.Date.Date == date.Date).ToList();
        }

        // Get event by ID
        public EventCard GetEventById(int id)
        {
            return events.ContainsKey(id) ? events[id] : null;
        }

        public void UpdateEvent(EventCard eventCard)
        {
            if (events.ContainsKey(eventCard.Id))
            {
                events[eventCard.Id] = eventCard;
            }
        }

    }
}
