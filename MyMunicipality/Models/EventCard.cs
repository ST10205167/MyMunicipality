using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMunicipality.Models
{
    public class EventCard
    {
        // Properties
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }

        public EventCard(int id, string title, string category, string description, DateTime date, string location)
        {
            Id = id;
            Title = title;
            Category = category;
            Description = description;
            Date = date;
            Location = location;
        }

        // Default constructor
        public EventCard() { }
    }

}
