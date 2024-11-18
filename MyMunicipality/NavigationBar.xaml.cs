using MyMunicipality.DataStructures;
using MyMunicipality.Repository;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyMunicipality
{
    /// <summary>
    /// Interaction logic for NavigationBar.xaml
    /// </summary>
    public partial class NavigationBar : UserControl
    {
        /// <summary>
        /// Instance of the EventRepository to manage event data.
        /// </summary>
        private EventRepository eventRepository = new EventRepository();
        private readonly ServiceRequestTree requestTree = ServiceRequestTree.Instance;


        /// <summary>
        /// Delegate action to close the current window.
        /// </summary>
        public Action CloseCurrentWindow;

        /// <summary>
        /// Constructor for NavigationBar. Initializes the component.
        /// </summary>
        public NavigationBar()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the click event for the Home button.
        /// Navigates to the Home page and closes the current window.
        /// </summary>
        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to the Home page
            var mainWindow = new MainWindow();
            mainWindow.Show();

            // Close the current window
            Window.GetWindow(this)?.Close();
        }

        /// <summary>
        /// Handles the click event for the Report Issues button.
        /// Navigates to the Submissions window and closes the current window.
        /// </summary>
        private void ReportButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to the Submissions window
            var reportIssuesPage = new Submissions(SubmissionsRepository.Instance.SubmissionsData);
            reportIssuesPage.Show();

            // Close the current window
            Window.GetWindow(this)?.Close();
        }

        /// <summary>
        /// Handles the click event for the Events and Announcements button.
        /// Navigates to the EventsAnnouncements window and closes the current window.
        /// </summary>
        private void EventsButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to the EventsAnnouncements window
            var eventsWindow = new EventsAnnouncements(eventRepository);
            eventsWindow.Show();

            // Close the current window
            Window.GetWindow(this)?.Close();
        }

        /// <summary>
        /// Handles the click event for the Service Request button.
        /// Navigates to the ServiceRequest window and closes the current window.
        /// </summary>
        private void ServicesButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to the ServiceRequest window
            var allRequests = requestTree.GetAllRequests();
            ServiceRequestStatus serviceRequest = new ServiceRequestStatus(requestTree);
            serviceRequest.Show();
            // Close the current window
            Window.GetWindow(this)?.Close();
        }

        /// <summary>
        /// Handles the click event for the Exit button.
        /// Shuts down the application.
        /// </summary>
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
