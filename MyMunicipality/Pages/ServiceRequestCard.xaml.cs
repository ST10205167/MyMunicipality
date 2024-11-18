using MyMunicipality.DataStructures;
using MyMunicipality.UserControls;
using System;
using System.Windows;
using System.Windows.Controls;

namespace MyMunicipality
{
    /// <summary>
    /// Interaction logic for the ServiceRequestCard.xaml.cs
    /// This page displays a list of service request cards, dynamically populated from a tree structure.
    /// </summary>
    public partial class ServiceRequestCard : Page
    {
        private readonly ServiceRequestTree _requestTree = ServiceRequestTree.Instance;

        /// <summary>
        /// Constructor for the ServiceRequestCard page.
        /// Initializes the components and sets up event handlers.
        /// </summary>
        public ServiceRequestCard()
        {
            InitializeComponent();

            ServiceRequest.ServiceRequestUpdated += OnServiceRequestUpdated;

            LoadServiceRequests();
        }

        /// <summary>
        /// Loads the service requests from the ServiceRequestTree and displays them.
        /// </summary>
        private void LoadServiceRequests()
        {
            if (_requestTree == null)
            {
                MessageBox.Show("ServiceRequestTree is not initialized.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var requests = _requestTree.GetAllRequests();

            if (requests == null || requests.Count == 0)
            {
                NoRequestsText.Visibility = Visibility.Visible;
                RequestCardsPanel.Children.Clear();
                return;
            }

            NoRequestsText.Visibility = Visibility.Collapsed;

            RequestCardsPanel.Children.Clear();

            foreach (var request in requests)
            {
                ServiceRequestCardControl cardControl = new ServiceRequestCardControl();

                cardControl.SetServiceRequest(request);

                RequestCardsPanel.Children.Add(cardControl);
            }
        }

        /// <summary>
        /// Event handler called when a service request is updated.
        /// Reloads the list of service requests to reflect the changes.
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
