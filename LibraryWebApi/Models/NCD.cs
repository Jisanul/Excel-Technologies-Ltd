using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class NCD
    {
        [Key]
        public int NCDID { get; set; }
        public string NCDName { get; set; }
    }
}
