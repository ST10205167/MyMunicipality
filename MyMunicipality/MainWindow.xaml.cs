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
using System.Windows.Threading;
using System.IO;
using MyMunicipality.Repository;
using MyMunicipality.DataStructures;

namespace MyMunicipality
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Timer for managing slideshow and datetime display.
        /// </summary>
        private DispatcherTimer _timer;

        /// <summary>
        /// Queue to store image file paths for the slideshow.
        /// </summary>
        private Queue<string> _imageQueue;

        /// <summary>
        /// Repository and tree instance for managing event and request data.
        /// </summary>
        private EventRepository eventRepository = new EventRepository();
        private readonly ServiceRequestTree requestTree = ServiceRequestTree.Instance;


        /// <summary>
        /// Main window constructor. Initializes components, datetime display, and slideshow.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            InitializeDateTime();
            InitializeSlideshow();
        }

        /// <summary>
        /// Initializes the slideshow by setting up the image queue and timer.
        /// </summary>
        private void InitializeSlideshow()
        {
            // Initialize the image queue with file paths
            _imageQueue = new Queue<string>();

            // Add image paths to the queue (Ensure these images are added to your project)
            _imageQueue.Enqueue("pack://application:,,,/Resources/backgroundImg1.png");
            _imageQueue.Enqueue("pack://application:,,,/Resources/backgroundImg2.png");
            _imageQueue.Enqueue("pack://application:,,,/Resources/backgroundImg3.png");
            _imageQueue.Enqueue("pack://application:,,,/Resources/backgroundImg4.png");
            _imageQueue.Enqueue("pack://application:,,,/Resources/backgroundImg5.png");
            _imageQueue.Enqueue("pack://application:,,,/Resources/backgroundImg6.png");
            _imageQueue.Enqueue("pack://application:,,,/Resources/backgroundImg7.png");

            // Set up the timer for slideshow transitions
            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(3)
            };
            _timer.Tick += SlideshowTimer_Tick;
            _timer.Start();

            // Display the first image
            slideshowImage.Source = new BitmapImage(new Uri(_imageQueue.Peek()));
        }

        /// <summary>
        /// Handles the slideshow timer tick event. Updates the image being displayed.
        /// </summary>
        private void SlideshowTimer_Tick(object sender, EventArgs e)
        {
            string currentImage = _imageQueue.Dequeue();
            _imageQueue.Enqueue(currentImage);

            slideshowImage.Source = new BitmapImage(new Uri(_imageQueue.Peek()));
        }

        /// <summary>
        /// Initializes the datetime display by setting up the timer.
        /// </summary>
        private void InitializeDateTime()
        {
            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        /// <summary>
        /// Handles the timer tick event. Updates the datetime display.
        /// </summary>
        private void Timer_Tick(object sender, EventArgs e)
        {
            dateTimeBlock.Text = DateTime.Now.ToString("dddd, MMM dd, yyyy HH:mm:ss");
        }

        /// <summary>
        /// Handles the click event for the report button. Navigates to the Submissions window.
        /// </summary>
        private void reportButton_Click(object sender, RoutedEventArgs e)
        {
            Submissions reportPage = new Submissions(SubmissionsRepository.Instance.SubmissionsData);
            reportPage.Show();
            this.Close();
        }

        /// <summary>
        /// Handles the click event for the Events button. Navigates to the EventsAnnouncements window.
        /// </summary>
        private void accessButton_Click(object sender, RoutedEventArgs e)
        {
            EventsAnnouncements eventsWindow = new EventsAnnouncements(eventRepository);
            eventsWindow.Show();
            this.Close();
        }

        /// <summary>
        /// Handles the click event for the receive button. Navigates to the ServiceRequest window.
        /// </summary>
        private void receiveButton_Click(object sender, RoutedEventArgs e)
        {
            var allRequests = requestTree.GetAllRequests();
            ServiceRequestStatus serviceRequest = new ServiceRequestStatus(requestTree);
            serviceRequest.Show();
            this.Close();
        }

        /// <summary>
        /// Handles the click event for the exit button. Shuts down the application.
        /// </summary>
        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
