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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using MyMunicipality.Models;
using MyMunicipality.Repository;

namespace MyMunicipality
{
    /// <summary>
    /// Interaction logic for AddEvent.xaml
    /// This class manages the window for adding and editing events.
    /// </summary>
    public partial class AddEvent : Window
    {
        private readonly EventRepository eventRepository; // Repository for interacting with the event data
        private bool isEditMode; // Flag to indicate if the window is in edit mode
        private EventCard myEventCard; // The event being edited, if any

        /// <summary>
        /// Constructor that initializes the AddEvent window.
        /// If an event is passed in, it switches to edit mode and loads the event data.
        /// </summary>
        public AddEvent(EventRepository repository, EventCard eventToEdit = null)
        {
            InitializeComponent();
            eventRepository = repository;

            // If an event is passed, set up edit mode and load the event for editing
            if (eventToEdit != null)
            {
                isEditMode = true;
                myEventCard = eventToEdit;
                LoadEventForEditing(eventToEdit);
            }
        }

        /// <summary>
        /// Loads the event data into the input fields for editing.
        /// </summary>
        private void LoadEventForEditing(EventCard eventToEdit)
        {
            // Populate text fields with the event data
            nameTextBox.Text = eventToEdit.Title;
            descriptionTextBox.Text = eventToEdit.Description;
            datePicker.SelectedDate = eventToEdit.Date;
            locationTextBox.Text = eventToEdit.Location;

            // Set the correct category in the combo box
            foreach (ComboBoxItem item in categoryComboBox.Items)
            {
                if (item.Content.ToString() == eventToEdit.Category)
                {
                    categoryComboBox.SelectedItem = item;
                    break;
                }
            }
        }

        /// <summary>
        /// Event handler for when the Done button is clicked.
        /// Navigates back to the EventsAnnouncements window.
        /// </summary>
        private void DoneButton_Click(object sender, RoutedEventArgs e)
        {
            // Open the EventsAnnouncements window and close the current window
            EventsAnnouncements eventsAnnouncements = new EventsAnnouncements(eventRepository);
            eventsAnnouncements.Show();
            this.Close();
        }

        /// <summary>
        /// Validates and adds or updates an event.
        /// </summary>
        private void AddingEvent()
        {
            // Retrieve the values entered by the user
            string title = nameTextBox.Text;
            string category = (categoryComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            DateTime? date = datePicker.SelectedDate;
            string description = descriptionTextBox.Text;
            string location = locationTextBox.Text;

            // Pattern for validating names (only letters and spaces)
            string namePattern = @"^[A-Za-z\s]+$";

            // Validate the event data
            if (string.IsNullOrWhiteSpace(title) || !Regex.IsMatch(title, namePattern))
                throw new Exception("Invalid event title.");
            if (string.IsNullOrWhiteSpace(description) || !Regex.IsMatch(description, namePattern))
                throw new Exception("Invalid description.");
            if (!date.HasValue)
                throw new Exception("Please select a date.");
            if (string.IsNullOrWhiteSpace(location))
                throw new Exception("Please enter a location.");

            // If editing an existing event, update it
            if (isEditMode && myEventCard != null)
            {
                myEventCard.Title = title;
                myEventCard.Category = category;
                myEventCard.Date = date.Value;
                myEventCard.Description = description;
                myEventCard.Location = location;
                eventRepository.UpdateEvent(myEventCard);
            }
            else
            {
                // If adding a new event, create a new event and save it
                var newEvent = new EventCard
                {
                    Title = title,
                    Category = category,
                    Date = date.Value,
                    Description = description,
                    Location = location
                };
                eventRepository.SaveEvent(newEvent);
            }
        }

        /// <summary>
        /// Event handler for when the Save button is clicked.
        /// Attempts to save the event and shows a success or error message.
        /// </summary>
        private void SaveEventButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Try to add or update the event
                AddingEvent();
                MessageBox.Show("Event saved successfully.");
            }
            catch (Exception ex)
            {
                // Display any errors that occur during event validation or saving
                MessageBox.Show(ex.Message);
            }
        }
    }
}
