using MyMunicipality.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyMunicipality
{
    /// <summary>
    /// Interaction logic for EventCardControl.xaml
    /// This UserControl is used to display details of an event card, 
    /// including options to edit or delete the event.
    /// </summary>
    public partial class EventCardControl : UserControl
    {
        private EventCard eventCard;

        public event Action<EventCard> EditEvent;
        public event Action<EventCard> DeleteEvent;

        /// <summary>
        /// Constructor for the EventCardControl.
        /// Initializes the control with a specific EventCard object.
        /// </summary>
        /// <param name="ev">The EventCard instance to display</param>
        public EventCardControl(EventCard ev)
        {
            InitializeComponent();

            eventCard = ev;

            LoadEventData();

            EditButton.Click += (s, e) => EditEvent?.Invoke(eventCard);

            DeleteButton.Click += (s, e) => DeleteEvent?.Invoke(eventCard);
        }

        /// <summary>
        /// Loads the event details into the corresponding UI elements.
        /// </summary>
        private void LoadEventData()
        {
            EventNameTextBlock.Text = eventCard.Title;

            EventCategoryTextBlock.Text = eventCard.Category;

            EventDateTextBlock.Text = eventCard.Date.ToString("MMMM dd, yyyy");

            EventLocationTextBlock.Text = eventCard.Location;

            EventDescriptionTextBlock.Text = eventCard.Description;
        }
    }
}
