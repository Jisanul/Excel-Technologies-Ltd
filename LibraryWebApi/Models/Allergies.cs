using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class Allergies
    {
        [Key]
        public int AllergiesID { get; set; }
        public string AllergiesName { get; set; }
    }
}
