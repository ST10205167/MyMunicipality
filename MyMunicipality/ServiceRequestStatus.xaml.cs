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
using MyMunicipality.DataStructures;
using MyMunicipality.Models;
using MyMunicipality.Pages;
using MyMunicipality.Repository;

namespace MyMunicipality
{
    /// <summary>
    /// Interaction logic for ServiceRequestStatus.xaml
    /// </summary>
    public partial class ServiceRequestStatus : Window
    {
        private readonly ServiceRequestTree _requestTree = ServiceRequestTree.Instance;

        /// <summary>
        /// Constructor for ServiceRequestStatus. Initializes the window and sets the initial navigation.
        /// </summary>
        /// <param name="requestTree">The instance of ServiceRequestTree to be used.</param>
        public ServiceRequestStatus(ServiceRequestTree requestTree)
        {
            InitializeComponent();
            _requestTree = requestTree;
            MainFrame.Navigate(new ServiceRequestCard());
        }

        /// <summary>
        /// Event handler for clicking the SearchForRequest button. Navigates to the SearchRequestPage.
        /// </summary>
        private void SearchForRequest_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new MyMunicipality.Pages.SearchRequestPage());
        }

        /// <summary>
        /// Event handler for clicking the CardView button. Navigates to the ServiceRequestCard view.
        /// </summary>
        private void CardView_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ServiceRequestCard());
        }

        /// <summary>
        /// Event handler for clicking the RequestService button. Opens a new window to request a service and closes the current window.
        /// </summary>
        private void RequestService_Click(object sender, RoutedEventArgs e)
        {
            var requestWindow = new ServiceRequest();
            requestWindow.Show();
            this.Close();
        }

        /// <summary>
        /// Event handler for clicking the ListView button. Navigates to the ServiceRequestList page.
        /// </summary>
        private void ListView_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new MyMunicipality.Pages.ServiceRequestList());
        }
    }
}
