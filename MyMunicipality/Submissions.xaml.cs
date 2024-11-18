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

namespace MyMunicipality
{
    /// <summary>
    /// Interaction logic for Submissions.xaml
    /// </summary>
    public partial class Submissions : Window
    {
        /// <summary>
        /// Instance of the SubmissionsRepository to handle data operations.
        /// </summary>
        private SubmissionsRepository repository = SubmissionsRepository.Instance;

        /// <summary>
        /// Constructor for the Submissions window.
        /// Initializes the window and populates the ListView with data.
        /// </summary>
        /// <param name="data">Dictionary containing the submission data.</param>
        public Submissions(Dictionary<int, SubmissionData> data)
        {
            InitializeComponent();
            PopulateListView();
        }

        /// <summary>
        /// Populates the ListView with submission data from the repository.
        /// Converts the attachment data into a BitmapImage if it is an image.
        /// </summary>
        private void PopulateListView()
        {
            submissionsListView.Items.Clear();
            foreach (var submission in repository.SubmissionsData.Values)
            {
                BitmapImage attachmentImage = null;
                if (submission.AttachmentType == "image" && submission.AttachmentData != null)
                {
                    attachmentImage = new BitmapImage();
                    attachmentImage.BeginInit();
                    attachmentImage.StreamSource = new System.IO.MemoryStream(submission.AttachmentData);
                    attachmentImage.EndInit();
                }

                submissionsListView.Items.Add(new
                {
                    Key = submission.Id,
                    Location = submission.Location,
                    Category = submission.Category,
                    Description = submission.Description,
                    AttachmentName = submission.AttachmentName,
                    AttachmentPreview = attachmentImage
                });
            }
        }

        /// <summary>
        /// Handles the Edit button click event.
        /// Opens the AddIssue window for editing an existing submission.
        /// </summary>
        /// <param name="sender">The button that triggered the event.</param>
        /// <param name="e">Event arguments.</param>
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            int submissionId = (int)((Button)sender).Tag;
            AddIssue addIssuePage = new AddIssue(submissionId); // Pass the ID for editing
            addIssuePage.Show();
            this.Close();
        }

        /// <summary>
        /// Handles the Delete button click event.
        /// Deletes the selected submission and updates the ListView.
        /// </summary>
        /// <param name="sender">The button that triggered the event.</param>
        /// <param name="e">Event arguments.</param>
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button deleteButton && deleteButton.Tag is int submissionId)
            {
                bool isDeleted = SubmissionsRepository.Instance.DeleteSubmission(submissionId);

                if (isDeleted)
                {
                    MessageBox.Show("Issue deleted successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                    PopulateListView();
                }
                else
                {
                    MessageBox.Show("Issue not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Failed to delete Issue.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Handles the Add Issue button click event.
        /// Opens the AddIssue window for creating a new submission.
        /// </summary>
        /// <param name="sender">The button that triggered the event.</param>
        /// <param name="e">Event arguments.</param>
        private void AddIssueButton_Click(object sender, RoutedEventArgs e)
        {
            AddIssue addIssue = new AddIssue();
            addIssue.Show();
            this.Close();
        }
    }
}
