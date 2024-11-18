using MyMunicipality.DataStructures; 
using MyMunicipality.Models; 
using MyMunicipality.UserControls;
using System;
using System.Windows;
using System.Windows.Controls;

namespace MyMunicipality.Pages
{
    /// <summary>
    /// Interaction logic for ServiceRequestList.xaml.cs
    /// This page displays a list of all service requests in a structured format.
    /// </summary>
    public partial class ServiceRequestList : Page
    {
        private readonly ServiceRequestTree requestTree = ServiceRequestTree.Instance;

        /// <summary>
        /// Constructor for the ServiceRequestList page.
        /// Initializes components and subscribes to the ServiceRequestUpdated event.
        /// </summary>
        public ServiceRequestList()
        {
            InitializeComponent();

            ServiceRequest.ServiceRequestUpdated += OnServiceRequestUpdated;

            LoadServiceRequests();
        }

        /// <summary>
        /// Loads service requests from the ServiceRequestTree and displays them using a custom control.
        /// </summary>
        private void LoadServiceRequests()
        {
            if (requestTree == null)
            {
                MessageBox.Show("ServiceRequestTree is not initialized.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var requests = requestTree.GetAllRequests();

            if (requests == null || requests.Count == 0)
            {
                NoRequestsText.Visibility = Visibility.Visible;
                RequestListsPanel.Children.Clear();
                return;
            }

            NoRequestsText.Visibility = Visibility.Collapsed;

            RequestListsPanel.Children.Clear();

            var listControl = new ServiceRequestListControl();

            listControl.LoadRequests(requests);

            RequestListsPanel.Children.Add(listControl);
        }

        /// <summary>
        /// Event handler triggered when a service request is updated.
        /// Reloads the service requests to reflect the latest changes.
        /// </summary>
        private void OnServiceRequestUpdated(object sender, EventArgs e)
        {
            LoadServiceRequests();
        }

        /// <summary>
        /// Event handler for when the page is unloaded.
        /// Unsubscribes from the ServiceRequestUpdated event to prevent memory leaks.
        /// </summary>
        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            ServiceRequest.ServiceRequestUpdated -= OnServiceRequestUpdated;
        }
    }
}
