/// <summary> 
/// Interaction logic for AddEvent.xaml 
/// </summary>

using MyMunicipality.Models;
using MyMunicipality.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MyMunicipality
{
    public partial class EventsAnnouncements : Window
    {
        private EventRepository eventRepository; 
        private Dictionary<string, int> userSearchings = new Dictionary<string, int>(); 

        /// <summary>
        /// Constructor for initializing the EventsAnnouncements window.
        /// </summary>
        public EventsAnnouncements(EventRepository repository)
        {
            InitializeComponent();
            eventRepository = repository;
            DisplayEvents(); 
            DisplayAnnouncements(); 
        }

        /// <summary>
        /// Displays the list of events in the UI.
        /// </summary>
        private void DisplayEvents()
        {
            eventsPanel.Children.Clear(); 
            var allEvents = eventRepository.GetAllEvents(); 
            if (allEvents.Count == 0)
            {
                eventsPanel.Children.Add(new TextBlock { Text = "No events available.", Foreground = Brushes.Gray });
                return;
            }

            foreach (var ev in allEvents)
            {
                EventCardControl card = new EventCardControl(ev); 
                card.EditEvent += EditEvent; 
                card.DeleteEvent += DeleteEvent;
                eventsPanel.Children.Add(card); 
            }
        }

        /// <summary>
        /// Displays a list of announcements in the UI.
        /// </summary>
        private void DisplayAnnouncements()
        {
            announcementsPanel.Children.Clear(); 
            List<string> announcements = new List<string>
            {
                "Water outage on Main Road, 18th Oct.",
                "Road repair on 5th Avenue, 20th Oct.",
                "Utilities update on electricity, 25th Oct."
            };

            foreach (var announcement in announcements)
            {
                TextBlock announcementText = new TextBlock
                {
                    Text = announcement,
                    FontSize = 16,
                    Foreground = new SolidColorBrush(Color.FromRgb(100, 100, 100)),
                    Margin = new Thickness(0, 5, 0, 5)
                };
                announcementsPanel.Children.Add(announcementText); 
            }
        }

        /// <summary>
        /// Handles editing of an event.
        /// </summary>
        private void EditEvent(EventCard eventToEdit)
        {
            AddEvent addEventWindow = new AddEvent(eventRepository, eventToEdit); 
            addEventWindow.Show();
            this.Close();
        }

        /// <summary>
        /// Handles deletion of an event.
        /// </summary>
        private void DeleteEvent(EventCard eventToDelete)
        {
            eventRepository.DeleteEvent(eventToDelete.Id);
            DisplayEvents();
        }

        /// <summary>
        /// Opens the AddEvent window to add a new event.
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddEvent addEventWindow = new AddEvent(eventRepository); 
            addEventWindow.Show();
            this.Close(); 
        }

        /// <summary>
        /// Handles the search functionality for events.
        /// </summary>
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchTerm = searchTextBox.Text.ToLower(); 
            string selectedCategory = (categoryComboBox.SelectedItem as ComboBoxItem)?.Content.ToString().ToLower(); 

            var allEvents = eventRepository.GetAllEvents(); 
            var filteredEvents = allEvents.Where(ev =>
                (string.IsNullOrEmpty(searchTerm) || ev.Title.ToLower().Contains(searchTerm) || ev.Description.ToLower().Contains(searchTerm)) &&
                (string.IsNullOrEmpty(selectedCategory) || ev.Category.ToLower() == selectedCategory)
            ).ToList();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                RecordSearch(searchTerm);
            }
            DisplayFilteredEvents(filteredEvents); 
        }

        /// <summary>
        /// Displays filtered events in the UI.
        /// </summary>
        private void DisplayFilteredEvents(List<EventCard> filteredEvents)
        {
            eventsPanel.Children.Clear();
            if (!filteredEvents.Any())
            {
                eventsPanel.Children.Add(new TextBlock { Text = "No matching events found.", Foreground = Brushes.Gray });
                return;
            }
            foreach (var ev in filteredEvents)
            {
                EventCardControl card = new EventCardControl(ev); 
                eventsPanel.Children.Add(card); 
            }
        }

        /// <summary>
        /// Records the search term in the user's search history.
        /// </summary>
        private void RecordSearch(string searchTerm)
        {
            if (userSearchings.ContainsKey(searchTerm))
                userSearchings[searchTerm]++;
            else
                userSearchings[searchTerm] = 1; 
        }

        /// <summary>
        /// Gets recommended events based on the user's search history.
        /// </summary>
        private List<EventCard> GetRecommendedEvents()
        {
            var userPreferences = userSearchings.OrderByDescending(kvp => kvp.Value).Take(3).Select(kvp => kvp.Key).ToList(); 
            if (userPreferences.Count == 0)
            {
                return new List<EventCard>(); 
            }

            return eventRepository.GetAllEvents()
                .Where(ev => userPreferences.Any(pref => ev.Title.ToLower().Contains(pref) || ev.Category.ToLower().Contains(pref)))
                .Distinct()
                .ToList();
        }

        /// <summary>
        /// Refreshes the event list by calling DisplayEvents again.
        /// </summary>
        private void Events(object sender, RoutedEventArgs e)
        {
            DisplayEvents();

        }
        /// <summary>
        /// Displays recommended events in the UI.
        /// </summary>
        private void DisplayRecommendedEvents_Click(object sender, RoutedEventArgs e)
        {

            var recommendedEvents = GetRecommendedEvents();
            if (recommendedEvents.Count == 0)
            {
                eventsPanel.Children.Clear();
                eventsPanel.Children.Add(new TextBlock { Text = "No recommended events found.", Foreground = Brushes.Gray });
                return;
            }
            eventsPanel.Children.Clear();
            foreach (var ev in recommendedEvents)
            {
                EventCardControl card = new EventCardControl(ev);
                card.EditEvent += EditEvent;
                card.DeleteEvent += DeleteEvent;
                eventsPanel.Children.Add(card);
            }
        }
    }
}
