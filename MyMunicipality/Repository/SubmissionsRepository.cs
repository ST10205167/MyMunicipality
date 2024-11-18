using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMunicipality
{
    public class SubmissionsRepository
    {
        /// <summary>
        /// Singleton instance of SubmissionsRepository.
        /// Ensures only one instance of the repository exists.
        /// </summary>
        private static SubmissionsRepository _instance;

        /// <summary>
        /// Property to access the singleton instance.
        /// If the instance does not exist, it creates a new one.
        /// </summary>
        public static SubmissionsRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SubmissionsRepository();
                }
                return _instance;
            }
        }

        /// <summary>
        /// Dictionary to store submission data.
        /// Uses a unique integer ID as the key.
        /// </summary>
        public Dictionary<int, SubmissionData> SubmissionsData { get; private set; }

        /// <summary>
        /// Property to generate the next unique issue ID.
        /// </summary>
        public int NextIssueId 
        { 
            get; 
            private set;
        }

        /// <summary>
        /// Private constructor to prevent direct instantiation.
        /// Initializes the submissions dictionary and sets the starting issue ID.
        /// </summary>
        private SubmissionsRepository()
        {
            SubmissionsData = new Dictionary<int, SubmissionData>();
            NextIssueId = 1;
        }

        /// <summary>
        /// Method to add a new submission.
        /// If the submission already exists, it updates the existing entry.
        /// Otherwise, it assigns a new unique ID to the submission.
        /// </summary>
        /// <param name="submission">The submission data to add or update.</param>
        public void AddSubmission(SubmissionData submission)
        {
            if (SubmissionsData.ContainsKey(submission.Id))
            {
                SubmissionsData[submission.Id] = submission;
            }
            else
            {
                submission.Id = NextIssueId;
                SubmissionsData[NextIssueId] = submission;
                NextIssueId++;
            }
        }

        /// <summary>
        /// Method to delete a submission by ID.
        /// Removes the submission data from the dictionary.
        /// </summary>
        /// <param name="id">The unique ID of the submission to delete.</param>
        /// <returns>True if the submission was successfully deleted, false otherwise.</returns>
        public bool DeleteSubmission(int id)
        {
            if (SubmissionsData.ContainsKey(id))
            {
                SubmissionsData.Remove(id);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Method to update an existing submission.
        /// Replaces the old submission data with the updated data.
        /// </summary>
        /// <param name="updatedSubmission">The updated submission data.</param>
        public void UpdateSubmission(SubmissionData updatedSubmission)
        {
            if (SubmissionsData.ContainsKey(updatedSubmission.Id))
            {
                SubmissionsData[updatedSubmission.Id] = updatedSubmission;
            }
        }
    }
}
