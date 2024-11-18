using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMunicipality
{
    public class SubmissionData
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string AttachmentName { get; set; }
        public byte[] AttachmentData { get; set; } 
        public string AttachmentType { get; set; } 
    }


}
