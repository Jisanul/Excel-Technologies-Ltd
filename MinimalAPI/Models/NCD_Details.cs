using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class NCD_Details
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Patient")]
        public int PatientID { get; set; }
        public virtual Patient Patient { get; set; }

        [ForeignKey("NCD")]
        public int NCDID { get; set; }
        public virtual NCD NCD { get; set; }
    }
}
