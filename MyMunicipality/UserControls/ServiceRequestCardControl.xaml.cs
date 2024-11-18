using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging; 
using MyMunicipality.Models; 

namespace MyMunicipality.UserControls
{
    /// <summary>
    /// A custom user control for displaying individual service request details.
    /// </summary>
    public partial class ServiceRequestCardControl : UserControl
    {
        /// <summary>
        /// Constructor for the ServiceRequestCardControl.
        /// Initializes the UI components defined in the XAML file.
        /// </summary>
        public ServiceRequestCardControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Populates the control with data from a given service request.
        /// </summary>
        /// <param name="request">An instance of the ServiceRequests model containing request details.</param>
        public void SetServiceRequest(ServiceRequests request)
        {
            RequestIdTextBlock.Text = $"Request ID: {request.Id}";

            RequestCategoryTextBlock.Text = $"Category: {request.Category}";

            RequestDateTextBlock.Text = $"Date: {request.RequestDate}";

            RequestLocationTextBlock.Text = $"Location: {request.Location}";

            RequestDescriptionTextBlock.Text = $"Description: {request.Description}";

            if (request.AttachmentData != null && request.AttachmentType == "image")
            {
                RequestAttachmentImage.Source = LoadImage(request.AttachmentData);
                RequestAttachmentImage.Visibility = Visibility.Visible; 
            }
            else
            {
                RequestAttachmentImage.Visibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        /// Converts a byte array into a BitmapImage for display.
        /// </summary>
        /// <param name="imageData">The image data in byte array format.</param>
        /// <returns>A BitmapImage object to be used as the source for an Image control.</returns>
        private BitmapImage LoadImage(byte[] imageData)
        {
            using (var stream = new MemoryStream(imageData))
            {
                BitmapImage bitmap = new BitmapImage();

                bitmap.BeginInit();

                bitmap.StreamSource = stream;

                bitmap.CacheOption = BitmapCacheOption.OnLoad;

                bitmap.EndInit();

                return bitmap;
            }
        }
    }
}
