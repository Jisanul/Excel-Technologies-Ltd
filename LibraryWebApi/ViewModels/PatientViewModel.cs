using LibraryManagementSystem.Models;
using PatientWebApi.Models;

namespace PatientWebApi.ViewModels
{
    public class PatientViewModel
    {
        public int PatienId { get; set; }
        public string PatientName { get; set; }
        public int AllergieId { get; set; }

        public IEnumerable<Allergies> Allergies { get; set; }
        public IEnumerable<Allergies> SelectedAllergies { get; set; }
        public List<int> SelectedAllergiesIds { get; set; }
        public IEnumerable<Patient> Patients { get; set; }
        public int DiseaseID { get; set; }
        public IEnumerable<DiseaseInformation> DiseaseInformation { get; set; }

        public int NcdId { get; set; }
        public IEnumerable<NCD> NCDs { get; set; }
        public IEnumerable<NCD> SelectedNCDs { get; set; }
        public List<int> SelectedNcdIds { get; set; }

        //public int EpilepsyStatusesID { get; set; }
        //public IEnumerable<string> EpilepsyStatuses { get; set; }
    }
}
