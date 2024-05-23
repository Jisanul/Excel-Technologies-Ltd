using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PatientWebApi.Models;
using System.Text;

namespace PatientWebApi.Controllers
{
    public class Allergies_DetailsController : Controller
    {
        Uri baseurl = new Uri("https://localhost:7041/APIs");

        private readonly HttpClient _httpClient;

        public Allergies_DetailsController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseurl;

        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            List<Allergies_Details> members = new List<Allergies_Details>();

            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri("https://localhost:7041/");

                    HttpResponseMessage response = await httpClient.GetAsync("GetAllergies_Details");
                    if (response.IsSuccessStatusCode)
                    {
                        string data = await response.Content.ReadAsStringAsync();

                        members = JsonConvert.DeserializeObject<List<Allergies_Details>>(data);
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

            List<Allergies> allergies = new List<Allergies>();
            List<Patient> patient = new List<Patient>();

            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri("https://localhost:7041/");

                    HttpResponseMessage responseAllergies = await httpClient.GetAsync("GetAllergies");
                    HttpResponseMessage responsePatient = await httpClient.GetAsync("GetPatient");

                    if (responseAllergies.IsSuccessStatusCode && responsePatient.IsSuccessStatusCode)
                    {
                        string dataresponseAllergies = await responseAllergies.Content.ReadAsStringAsync();
                        string dataPatient = await responsePatient.Content.ReadAsStringAsync();


                        allergies = JsonConvert.DeserializeObject<List<Allergies>>(dataresponseAllergies);
                        patient = JsonConvert.DeserializeObject<List<Patient>>(dataPatient);

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

            ViewBag.Allergies = allergies;
            ViewBag.Patient = patient;



            return View();

        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(Allergies_Details m)
        {
            try
            {
                string data = JsonConvert.SerializeObject(m);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync("InsertAllergies_Details", content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }


            }
            catch (Exception ex)
            {
                throw;
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditAsync(int id)
        {
            Allergies_Details allergies_Details = new Allergies_Details();
            List<Allergies> allergies = new List<Allergies>();
            List<Patient> patient = new List<Patient>();

            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri("https://localhost:7041/");
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));


                    HttpResponseMessage responseAllergies_Details = await httpClient.GetAsync($"GetAllergies_DetailsByID?id={id}");
                    HttpResponseMessage responseAllergies = await httpClient.GetAsync("GetAllergies");
                    HttpResponseMessage responsePatient = await httpClient.GetAsync("GetPatient");


                    if (responseAllergies_Details.IsSuccessStatusCode && responseAllergies.IsSuccessStatusCode && responsePatient.IsSuccessStatusCode)
                    {
                        string dataAllergies = await responseAllergies.Content.ReadAsStringAsync();
                        string dataAllergies_Details = await responseAllergies_Details.Content.ReadAsStringAsync();
                        string dataPatient = await responsePatient.Content.ReadAsStringAsync();



                        patient = JsonConvert.DeserializeObject<List<Patient>>(dataPatient);

                        allergies_Details = JsonConvert.DeserializeObject<Allergies_Details>(dataAllergies_Details);
                        allergies = JsonConvert.DeserializeObject<List<Allergies>>(dataAllergies);

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

            //ViewBag.BorrowedBook = borrowedBook;
            ViewBag.Allergies = allergies;
            ViewBag.Patient = patient;


            return View(allergies_Details);

        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(Allergies_Details model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PutAsync("UpdateAllergies_Details", content);

            if (response.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");

            }

            return View();
        }


        [HttpGet]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            Allergies_Details bk = new Allergies_Details();
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri("https://localhost:7041/");
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await httpClient.GetAsync($"GetAllergies_DetailsByID?id={id}");

                    if (response.IsSuccessStatusCode)
                    {
                        string data = await response.Content.ReadAsStringAsync();

                        bk = JsonConvert.DeserializeObject<Allergies_Details>(data);
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
                HttpResponseMessage response = await _httpClient.DeleteAsync($"/DeleteAllergies_Details/{id}");

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
