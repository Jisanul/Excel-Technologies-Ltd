using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace PatientWebApi.Controllers
{
    public class DiseaseInformationController : Controller
    {
        Uri baseurl = new Uri("https://localhost:7041/APIs");

        private readonly HttpClient _httpClient;

        public DiseaseInformationController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseurl;

        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            List<DiseaseInformation> members = new List<DiseaseInformation>();

            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri("https://localhost:7041/");

                    HttpResponseMessage response = await httpClient.GetAsync("GetDiseaseInformation");

                    if (response.IsSuccessStatusCode)
                    {
                        string data = await response.Content.ReadAsStringAsync();

                        members = JsonConvert.DeserializeObject<List<DiseaseInformation>>(data);
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

            return View(members);

        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();

        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(DiseaseInformation m)
        {
            try
            {
                string data = JsonConvert.SerializeObject(m);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync("InsertDiseaseInformation", content);
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
            DiseaseInformation bk = new DiseaseInformation();
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri("https://localhost:7041/");
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await httpClient.GetAsync($"GetDiseaseInformationByID?id={id}");

                    if (response.IsSuccessStatusCode)
                    {
                        string data = await response.Content.ReadAsStringAsync();
                        bk = JsonConvert.DeserializeObject<DiseaseInformation>(data);
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

        [HttpPost]
        public async Task<IActionResult> EditAsync(DiseaseInformation model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PutAsync("UpdateDiseaseInformation", content);

            if (response.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");

            }

            return View();
        }


        [HttpGet]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            DiseaseInformation bk = new DiseaseInformation();
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri("https://localhost:7041/");
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await httpClient.GetAsync($"GetDiseaseInformationByID?id={id}");

                    if (response.IsSuccessStatusCode)
                    {
                        string data = await response.Content.ReadAsStringAsync();

                        bk = JsonConvert.DeserializeObject<DiseaseInformation>(data);
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
                HttpResponseMessage response = await _httpClient.DeleteAsync($"/DeleteDiseaseInformation/{id}");

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
