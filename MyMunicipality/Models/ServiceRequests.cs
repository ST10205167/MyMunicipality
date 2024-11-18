using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MyMunicipality.Models
{
    public class ServiceRequests
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public DateTime RequestDate { get; set; }
        public string Location { get; set; }
        public string AttachmentName { get; set; }
        public byte[] AttachmentData { get; set; }
        public string AttachmentType { get; set; }
        public ImageSource AttachmentPreview { get; set; }

        public ServiceRequests(int id, string status, string category, string description, DateTime requestDate, string location, string attachmentName, byte[] attachmentData, string attachmentType)
        {
            Id = id;
            Status = status;
            Category = category;
            Description = description;
            RequestDate = requestDate;
            Location = location;
            AttachmentName = attachmentName;
            AttachmentData = attachmentData;
            AttachmentType = attachmentType;

            if (attachmentData != null && attachmentType == "image")
            {
                AttachmentPreview = ConvertToImageSource(attachmentData);
            }
        }

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
