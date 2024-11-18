using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Media.Imaging;
using MyMunicipality.Models;
using MyMunicipality.Repository;
using System.Windows.Controls;
using MyMunicipality.DataStructures;

namespace MyMunicipality
{
    public partial class ServiceRequest : Window
    {
        private readonly ServiceRequestTree requestTree = ServiceRequestTree.Instance;
        private byte[] attachmentData;
        private string attachmentType;

        /// <summary>
        /// Constructor for the ServiceRequest window. Initializes the components of the window.
        /// </summary>
        public ServiceRequest()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event handler for clicking the AttachButton. Opens a file dialog to select a file and displays the selected file.
        /// </summary>
        private void AttachButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All Files|*.*|Images|*.jpg;*.jpeg;*.png;*.gif|Videos|*.mp4;*.avi;*.mov";

            if (openFileDialog.ShowDialog() == true)
            {
                string attachedFilePath = openFileDialog.FileName;
                AttachmentName.Text = System.IO.Path.GetFileName(attachedFilePath); 

                attachmentData = System.IO.File.ReadAllBytes(attachedFilePath);

                string fileType = System.IO.Path.GetExtension(attachedFilePath).ToLower();
                switch (fileType)
                {
                    case ".jpg":
                    case ".jpeg":
                    case ".png":
                    case ".gif":
                        attachmentType = "image"; 
                        BitmapImage bitmap = new BitmapImage(new Uri(attachedFilePath));
                        AttachmentPreview.Source = bitmap;
                        AttachmentPreview.Visibility = Visibility.Visible;
                        break;

                    case ".mp4":
                    case ".avi":
                    case ".mov":
                        attachmentType = "video"; 
                        AttachmentPreview.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/video_icon.png"));
                        AttachmentPreview.Visibility = Visibility.Visible;
                        break;

                    default:
                        attachmentType = "file"; 
                        AttachmentPreview.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/file_icon.png"));
                        AttachmentPreview.Visibility = Visibility.Visible;
                        break;
                }
            }
        }

        /// <summary>
        /// Event handler for clicking the SubmitRequest button. Validates the form inputs and creates a new service request.
        /// </summary>
        private void SubmitRequest_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtLocation == null || txtCategory == null || txtDescription == null)
                {
                    MessageBox.Show("All fields must be initialized.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                string location = txtLocation.Text;
                string category = (txtCategory.SelectedItem as ComboBoxItem)?.Content?.ToString();
                string description = txtDescription.Text;

                if (string.IsNullOrWhiteSpace(location) || string.IsNullOrWhiteSpace(category) || string.IsNullOrWhiteSpace(description))
                {
                    MessageBox.Show("Please fill all required fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (attachmentData == null)
                {
                    attachmentData = Array.Empty<byte>(); 
                    AttachmentName.Text = "No attachment";
                    attachmentType = "none";
                }

                int newId = ServiceRequestTree.Instance.GetAllRequests().Count + 1;

                var newRequest = new ServiceRequests(
                    newId,
                    "Pending", 
                    category,
                    description,
                    DateTime.Now,
                    location,
                    AttachmentName.Text,
                    attachmentData,
                    attachmentType
                );

                requestTree.AddRequest(newRequest);

                MessageBox.Show($"Request ID {newRequest.Id} has been successfully submitted.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                ServiceRequestUpdated?.Invoke(this, EventArgs.Empty);

                ClearInputFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Clears all input fields and resets the state of the form.
        /// </summary>
        private void ClearInputFields()
        {
            txtLocation.Text = string.Empty;
            txtCategory.SelectedIndex = -1;
            txtDescription.Text = string.Empty;
            AttachmentPreview.Visibility = Visibility.Collapsed;
            AttachmentName.Text = string.Empty;
            attachmentData = null;
            attachmentType = null;
        }

        /// <summary>
        /// Event handler for clicking the Done button. Navigates to the ServiceRequestStatus page.
        /// </summary>
        private void Done_Click(object sender, RoutedEventArgs e)
        {
            var allRequests = requestTree.GetAllRequests();
            var mainWindow = new ServiceRequestStatus(requestTree); 
            mainWindow.Show();
            this.Close();
        }

        public static event EventHandler ServiceRequestUpdated;
    }
}
