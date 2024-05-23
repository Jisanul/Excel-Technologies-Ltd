using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PatientWebApi.Models;
using PatientWebApi.ViewModels;
using System.Reflection;
using System.Text;

namespace PatientWebApi.Controllers
{
    public class PatientsController : Controller
    {
        Uri baseurl = new Uri("https://localhost:7041/APIs");

        private readonly HttpClient _httpClient;

        public PatientsController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseurl;

        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            List<PatientViewModel> members = new List<PatientViewModel>();

            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri("https://localhost:7041/");

                    HttpResponseMessage response = await httpClient.GetAsync("GetPatient");
                    if (response.IsSuccessStatusCode)
                    {
                        string data = await response.Content.ReadAsStringAsync();

                       var patients = JsonConvert.DeserializeObject<List<Patient>>(data);
                        members = patients?.Select(p => new PatientViewModel { PatienId = p.PatientID, PatientName = p.PatientName, DiseaseID = p.DiseaseInformationID }).ToList();
                    }
                    else
                    {
                        // Handle unsuccessful responses (optional)

                    }

                }
            }

            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return View(members);

        }

        [HttpGet]
        public async Task<IActionResult> CreateAsync()
        {
            PatientViewModel patientViewModel = new PatientViewModel();

            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri("https://localhost:7041/");

                    HttpResponseMessage responseAllergies = await httpClient.GetAsync("GetAllergies");
                    HttpResponseMessage responseDiseaseInformation = await httpClient.GetAsync("GetDiseaseInformation");
                    HttpResponseMessage responseNCDs = await httpClient.GetAsync("GetNCDs");
                    HttpResponseMessage responsePatient = await httpClient.GetAsync("GetPatient");
                  //  HttpResponseMessage responseEpilepsy = await httpClient.GetAsync("GetEpilepsies");

                    if (responseAllergies.IsSuccessStatusCode && responsePatient.IsSuccessStatusCode && responseNCDs.IsSuccessStatusCode && responseDiseaseInformation.IsSuccessStatusCode)
                    {
                        string dataresponseAllergies = await responseAllergies.Content.ReadAsStringAsync();
                        string dataPatient = await responsePatient.Content.ReadAsStringAsync();
                        string dataresponseDiseaseInformation = await responseDiseaseInformation.Content.ReadAsStringAsync();
                        string dataNCDs = await responseNCDs.Content.ReadAsStringAsync();
                     //   string dataEpilepsy = await responseEpilepsy.Content.ReadAsStringAsync();


                        patientViewModel.Allergies = JsonConvert.DeserializeObject<List<Allergies>>(dataresponseAllergies);
                        patientViewModel.Patients = JsonConvert.DeserializeObject<List<Patient>>(dataPatient);
                        patientViewModel.DiseaseInformation = JsonConvert.DeserializeObject<List<DiseaseInformation>>(dataresponseDiseaseInformation);

                        patientViewModel.SelectedAllergies = new List<Allergies>();
                        patientViewModel.SelectedAllergiesIds = new List<int>();

                        patientViewModel.NCDs = JsonConvert.DeserializeObject<List<NCD>>(dataNCDs);
                        patientViewModel.SelectedNCDs = new List<NCD>();
                        patientViewModel.SelectedNcdIds = new List<int>();
                    }
                    else
                    {
                        // Handle unsuccessful responses (optional)

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return View(patientViewModel);

        }
        [HttpPost]
        public async Task<IActionResult> Create(PatientViewModel m)
        {
            try
            {
                var patient = new Patient
                {
                    PatientName = m.PatientName,
                    DiseaseInformationID = m.DiseaseID,
                    Allergies_Details = m.SelectedAllergiesIds?.Select(d => new Allergies_Details { AllergiesID = d }).ToList(),
                    NCD_Details = m.SelectedNcdIds?.Select(d => new NCD_Details { NCDID = d }).ToList()
                };

                string data = JsonConvert.SerializeObject(patient);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync("InsertPatient", content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }


            }
            catch (Exception ex)
            {
                throw;
            }
            return View(new PatientViewModel());
        }

        [HttpGet]
        public async Task<IActionResult> EditAsync(int id)
        {
            PatientViewModel patientViewModel = new PatientViewModel();

            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri("https://localhost:7041/");
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));


                    HttpResponseMessage responseAllergies = await httpClient.GetAsync("GetAllergies");
                    HttpResponseMessage responseDiseaseInformation = await httpClient.GetAsync("GetDiseaseInformation");
                    HttpResponseMessage responseNCDs = await httpClient.GetAsync("GetNCDs");
                    HttpResponseMessage responsePatient = await httpClient.GetAsync("GetPatient");
                    HttpResponseMessage responseEpilepsy = await httpClient.GetAsync("GetEpilepsies");


                    if (responsePatient.IsSuccessStatusCode && responseAllergies.IsSuccessStatusCode && responsePatient.IsSuccessStatusCode && responseNCDs.IsSuccessStatusCode)
                    {
                        string dataresponseAllergies = await responseAllergies.Content.ReadAsStringAsync();
                        string dataPatient = await responsePatient.Content.ReadAsStringAsync();
                        string dataresponseDiseaseInformation = await responseDiseaseInformation.Content.ReadAsStringAsync();
                        string dataNCDs = await responseNCDs.Content.ReadAsStringAsync();
                        string dataEpilepsy = await responseEpilepsy.Content.ReadAsStringAsync();





                        patientViewModel.Allergies = JsonConvert.DeserializeObject<List<Allergies>>(dataresponseAllergies);
                        patientViewModel.Patients = JsonConvert.DeserializeObject<List<Patient>>(dataPatient);
                        patientViewModel.DiseaseInformation = JsonConvert.DeserializeObject<List<DiseaseInformation>>(dataresponseDiseaseInformation);
                        patientViewModel.NCDs = JsonConvert.DeserializeObject<List<NCD>>(dataNCDs);

                    }
                    else
                    {
                        // Handle unsuccessful responses (optional)
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            


            return View(patientViewModel);

        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(Patient model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PutAsync("UpdatePatient", content);

            if (response.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");

            }

            return View();
        }


        [HttpGet]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            Patient bk = new Patient();
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri("https://localhost:7041/");
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await httpClient.GetAsync($"GetPatient?id={id}");

                    if (response.IsSuccessStatusCode)
                    {
                        string data = await response.Content.ReadAsStringAsync();

                        bk = JsonConvert.DeserializeObject<Patient>(data);
                    }
                    else
                    {
                        // Handle unsuccessful response (optional)
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            return View(bk);


        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmedAsync(int id)
        {


            try
            {
                HttpResponseMessage response = await _httpClient.DeleteAsync($"/DeletePatient/{id}");

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Error");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return View("Error");
            }


        }
    }

}
