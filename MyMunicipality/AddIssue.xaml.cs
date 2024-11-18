using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for AddIssue.xaml
    /// </summary>
    public partial class AddIssue : Window
    {
        private SubmissionsRepository repository = SubmissionsRepository.Instance;
        private bool isEditMode = false;
        private int currentEditId;

        /// <summary>
        /// Initializes a new instance of the AddIssue class.
        /// Checks if editing an existing issue.
        /// </summary>
        /// <param name="issueId">The ID of the issue to edit, -1 for new issue.</param>
        public AddIssue(int issueId = -1)
        {
            InitializeComponent();

            // Check if we're editing an existing issue
            if (issueId != -1 && repository.SubmissionsData.ContainsKey(issueId))
            {
                isEditMode = true;
                currentEditId = issueId;
                PopulateFieldsForEditing(repository.SubmissionsData[issueId]);
            }
        }

        /// <summary>
        /// Populates the fields with the data of the issue to be edited.
        /// </summary>
        /// <param name="editData">The data of the issue to be edited.</param>
        private void PopulateFieldsForEditing(SubmissionData editData)
        {
            LocationTextBox.Text = editData.Location;
            CategoryComboBox.SelectedItem = editData.Category;
            DescriptionTextBox.Text = editData.Description;
            AttachmentName.Text = editData.AttachmentName;

            if (editData.AttachmentType == "image")
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.StreamSource = new System.IO.MemoryStream(editData.AttachmentData);
                bitmap.EndInit();
                AttachmentPreview.Source = bitmap;
                AttachmentPreview.Visibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// Handles the AddIssue button click event.
        /// Adds a new issue or updates an existing one based on the input fields.
        /// </summary>
        private void AddIssueButton_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve input values
            string location = LocationTextBox.Text;
            string category = (CategoryComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            string description = DescriptionTextBox.Text;

            // Validate input fields
            if (string.IsNullOrWhiteSpace(location) || string.IsNullOrWhiteSpace(category) || string.IsNullOrWhiteSpace(description))
            {
                MessageBox.Show("Please fill all fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Initialize attachment data
            string attachmentName = AttachmentName.Text;
            byte[] attachmentData = null;
            string attachmentType = null;

            if (AttachmentPreview.Source != null)
            {
                // Retrieve existing attachment data if any
                attachmentData = repository.SubmissionsData.ContainsKey(currentEditId) ? repository.SubmissionsData[currentEditId].AttachmentData : null;
                attachmentType = repository.SubmissionsData.ContainsKey(currentEditId) ? repository.SubmissionsData[currentEditId].AttachmentType : null;
            }

            // Create a new SubmissionData object
            SubmissionData newIssue = new SubmissionData
            {
                Id = isEditMode ? currentEditId : repository.NextIssueId,
                Location = location,
                Category = category,
                Description = description,
                AttachmentName = attachmentName,
                AttachmentData = attachmentData,
                AttachmentType = attachmentType
            };

            // Update or add the new issue
            if (isEditMode)
            {
                SubmissionsRepository.Instance.UpdateSubmission(newIssue);
                MessageBox.Show("Issue Edited successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                SubmissionsRepository.Instance.AddSubmission(newIssue);
                currentEditId++;
                MessageBox.Show("Issue added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            // Clear input fields for the next submission
            ClearInputFields();
        }

        /// <summary>
        /// Clears all the input fields and resets controls.
        /// </summary>
        private void ClearInputFields()
        {
            // Reset text boxes
            LocationTextBox.Text = string.Empty;
            DescriptionTextBox.Text = string.Empty;

            // Reset ComboBox
            CategoryComboBox.SelectedIndex = -1;

            // Clear attachment preview and name
            AttachmentName.Text = string.Empty;
            AttachmentPreview.Source = null;

            // Reset any additional flags or data (like edit mode)
            isEditMode = false;
            currentEditId = 0;
        }

        /// <summary>
        /// Navigates back to the Submissions window.
        /// </summary>
        private void NavigateBackToWindow()
        {
            Submissions reportPage = new Submissions(SubmissionsRepository.Instance.SubmissionsData);
            reportPage.Show();
            this.Close();
        }

        /// <summary>
        /// Handles the Back button click event.
        /// </summary>
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigateBackToWindow();
        }

        /// <summary>
        /// Handles the Attach button click event.
        /// Opens a file dialog to select an attachment.
        /// </summary>
        private void AttachButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All Files|*.*|Images|*.jpg;*.jpeg;*.png;*.gif|Videos|*.mp4;*.avi;*.mov";
            if (openFileDialog.ShowDialog() == true)
            {
                string attachedFilePath = openFileDialog.FileName;
                AttachmentName.Text = System.IO.Path.GetFileName(attachedFilePath);

                // Read the file data
                byte[] fileData = System.IO.File.ReadAllBytes(attachedFilePath);

                // Determine the file type based on the extension
                string fileType = System.IO.Path.GetExtension(attachedFilePath).ToLower();
                string attachmentType;
                switch (fileType)
                {
                    case ".jpg":
                    case ".jpeg":
                    case ".png":
                    case ".gif":
                        attachmentType = "image";
                        // Display the image
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

                // Store the file data in the new issue
                if (repository.SubmissionsData.ContainsKey(currentEditId))
                {
                    repository.SubmissionsData[currentEditId].AttachmentName = AttachmentName.Text;
                    repository.SubmissionsData[currentEditId].AttachmentData = fileData;
                    repository.SubmissionsData[currentEditId].AttachmentType = attachmentType;
                }
                else
                {
                    // Adding new submission with attachment details
                    SubmissionData newIssue = new SubmissionData
                    {
                        Id = isEditMode ? currentEditId : repository.NextIssueId,
                        Location = LocationTextBox.Text,
                        Category = (CategoryComboBox.SelectedItem as ComboBoxItem)?.Content.ToString(),
                        Description = DescriptionTextBox.Text,
                        AttachmentName = AttachmentName.Text,
                        AttachmentData = fileData,
                        AttachmentType = attachmentType
                    };
                    repository.SubmissionsData.Add(currentEditId, newIssue);
                }
            }
        }
    }
}
