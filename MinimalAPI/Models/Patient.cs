using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class Patient
    {
        [Key]
        public int PatientID { get; set; }
        public string PatientName { get; set; }
        public bool IsEplepsy { get; set; }
        public int DiseaseInformationID { get; set; }
        public virtual DiseaseInformation DiseaseInformation { get; set; }
        public virtual ICollection<NCD_Details> NCD_Details { get; set; }
        public virtual ICollection<Allergies_Details> Allergies_Details { get; set; }
    }
}
