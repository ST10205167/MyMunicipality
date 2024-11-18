// Importing necessary namespaces for the WPF application
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
using MyMunicipality.DataStructures; 
using MyMunicipality.Models; 

namespace MyMunicipality.Pages
{
    /// <summary>
    /// Interaction logic for the SearchRequestPage.xaml.cs
    /// This page allows users to search for service requests by category or ID.
    /// </summary>
    public partial class SearchRequestPage : Page
    {
        private readonly ServiceRequestTree _requestTree = ServiceRequestTree.Instance;

        /// <summary>
        /// Constructor for SearchRequestPage. Initializes components and sets up event handlers.
        /// </summary>
        public SearchRequestPage()
        {
            InitializeComponent();

            SearchTextBox.TextChanged += SearchTextBox_TextChanged;
        }

        /// <summary>
        /// Event handler for the Search button click event.
        /// It performs a search based on the user input in the search box.
        /// </summary>
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchText = SearchTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                MessageBox.Show("Please enter a category to search.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            List<ServiceRequests> results;
            int id;

            if (int.TryParse(searchText, out id))
            {
                results = _requestTree.GetAllRequests().Where(r => r.Id == id).ToList();
            }
            else
            {
                var heap = new Heap(GetRelevance);

                var allRequests = _requestTree.GetAllRequests();

                foreach (var request in allRequests)
                {
                    if (request.Category != null && request.Category.ToLower().Contains(searchText.ToLower()))
                    {
                        heap.Insert(request);
                    }
                }

                results = new List<ServiceRequests>();
                while (heap.Count > 0)
                {
                    results.Add(heap.ExtractMin());
                }

                if (results.Any())
                {
                    SearchResultsListView.ItemsSource = results;
                    NoResultsText.Visibility = Visibility.Collapsed; 
                }
                else
                {
                    SearchResultsListView.ItemsSource = null;
                    NoResultsText.Visibility = Visibility.Visible;
                }
            }
        }

        /// <summary>
        /// Event handler for changes in the search text box.
        /// Displays a placeholder text if the search box is empty.
        /// </summary>
        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SearchTextBox.Text))
            {
                SearchTextBlock.Visibility = Visibility.Visible; 
            }
            else
            {
                SearchTextBlock.Visibility = Visibility.Collapsed; 
            }
        }

        /// <summary>
        /// Method to determine the relevance of a service request.
        /// Currently, relevance is determined by the length of the category string.
        /// </summary>
        /// <param name="request">The service request to evaluate.</param>
        /// <returns>An integer representing the relevance score.</returns>
        private int GetRelevance(ServiceRequests request)
        {
            return request.Category.Length;
        }
    }
}
