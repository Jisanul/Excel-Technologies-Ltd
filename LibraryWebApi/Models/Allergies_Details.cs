using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PatientWebApi.Models;

namespace LibraryManagementSystem.Models
{
    public class Allergies_Details
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Patient")]
        public int PatientID { get; set; }
        public virtual Patient Patient { get; set; }

        [ForeignKey("Allergies")]
        public int AllergiesID { get; set; }
        public virtual Allergies Allergies { get; set; }
    }
}
