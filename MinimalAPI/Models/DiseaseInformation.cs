using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class DiseaseInformation
    {
        [Key]
        public int DiseaseID { get; set; }
        public string DiseaseName { get; set; }
    }
}
