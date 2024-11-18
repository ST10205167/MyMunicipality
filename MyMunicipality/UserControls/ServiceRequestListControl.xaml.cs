using System.Collections.Generic; 
using System.Windows; 
using System.Windows.Controls;
using System.Windows.Media.Imaging; 
using System.Windows.Media; 
using MyMunicipality.Models; 

namespace MyMunicipality.UserControls
{
    /// <summary>
    /// Custom UserControl for displaying a list of service requests.
    /// </summary>
    public partial class ServiceRequestListControl : UserControl
    {
        /// <summary>
        /// DependencyProperty to hold a list of ServiceRequests.
        /// This allows for data binding in XAML.
        /// </summary>
        public List<ServiceRequests> Requests
        {
            get => (List<ServiceRequests>)GetValue(RequestsProperty);

            set => SetValue(RequestsProperty, value);
        }

        /// <summary>
        /// Registers the Requests dependency property to enable XAML data binding.
        /// </summary>
        public static readonly DependencyProperty RequestsProperty =
            DependencyProperty.Register(
                "Requests", 
                typeof(List<ServiceRequests>),
                typeof(ServiceRequestListControl),
                new PropertyMetadata(null) 
            );

        /// <summary>
        /// Constructor for the ServiceRequestListControl.
        /// Initializes the components defined in the XAML.
        /// </summary>
        public ServiceRequestListControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Loads a list of service requests and sets their image previews.
        /// Binds the processed list to a ListView for display.
        /// </summary>
        /// <param name="requests">List of service requests to be displayed.</param>
        public void LoadRequests(List<ServiceRequests> requests)
        {
            foreach (var request in requests)
            {
                request.AttachmentPreview = ConvertToImageSource(request.AttachmentData);
            }

            Requests = requests;

            ServiceRequestsListView.ItemsSource = Requests;
        }

        /// <summary>
        /// Converts a byte array to an ImageSource for display in the UI.
        /// </summary>
        /// <param name="imageData">The image data in byte array format.</param>
        /// <returns>An ImageSource that can be used in WPF Image controls.</returns>
        private ImageSource ConvertToImageSource(byte[] imageData)
        {
            if (imageData == null) return null;

            var bitmap = new BitmapImage();

            using (var stream = new System.IO.MemoryStream(imageData))
            {
                bitmap.BeginInit();

                bitmap.StreamSource = stream;

                bitmap.CacheOption = BitmapCacheOption.OnLoad;

                bitmap.EndInit();
            }

            return bitmap;
        }
    }
}
