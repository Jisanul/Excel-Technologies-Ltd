﻿using LibraryManagementSystem.Models;
using LibraryWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LibraryWebApi.Controllers
{
    public class BorrowedBookController : Controller
    {
        Uri baseurl = new Uri("https://localhost:7041/APIs");

        private readonly HttpClient _httpClient;

        public BorrowedBookController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseurl;

        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            List<BorrowedBook> members = new List<BorrowedBook>();
            //List<Member> authors = new List<Member>();
            //List<Book> books = new List<Book>();

            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri("https://localhost:7041/");

                    HttpResponseMessage response = await httpClient.GetAsync("GetBorrowedBooks");
                    // HttpResponseMessage responseAuthors = await httpClient.GetAsync("GetMembers");
                    // HttpResponseMessage responseBooks = await httpClient.GetAsync("GetBooks");
                   // responseAuthors.IsSuccessStatusCode && responseBooks.IsSuccessStatusCode &&
                    if (response.IsSuccessStatusCode)
                    {
                       // string dataAuthors = await responseAuthors.Content.ReadAsStringAsync();
                       // string dataBooks = await responseBooks.Content.ReadAsStringAsync();
                        string data = await response.Content.ReadAsStringAsync();

                       // authors = JsonConvert.DeserializeObject<List<Member>>(dataAuthors);
                      //  books = JsonConvert.DeserializeObject<List<Book>>(dataBooks);
                        members = JsonConvert.DeserializeObject<List<BorrowedBook>>(data);
                    }
                    else
                    {
                        // Handle unsuccessful responses (optional)

                    }
                    
                }
            }
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"An error occurred: {ex.Message}");
            //}

            //return View(members);
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return View(members);

        }

        [HttpGet]


        public async Task<IActionResult> CreateAsync()
        {

            List<Member> authors = new List<Member>();
            List<Book> books = new List<Book>();

            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri("https://localhost:7041/");

                    HttpResponseMessage responseAuthors = await httpClient.GetAsync("GetMembers");
                    HttpResponseMessage responseBooks = await httpClient.GetAsync("GetBooks");

                    if (responseAuthors.IsSuccessStatusCode && responseBooks.IsSuccessStatusCode)
                    {
                        string dataAuthors = await responseAuthors.Content.ReadAsStringAsync();
                        string dataBooks = await responseBooks.Content.ReadAsStringAsync();

                        authors = JsonConvert.DeserializeObject<List<Member>>(dataAuthors);
                        books = JsonConvert.DeserializeObject<List<Book>>(dataBooks);
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

            ViewBag.Authors = authors;
            ViewBag.Books = books;


            return View();

        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(BorrowedBook m)
        {
            try
            {
                string data = JsonConvert.SerializeObject(m);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync("InsertBorrowedBook", content);
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
            BorrowedBook borrowedBook = new BorrowedBook();
            List<Member> authors = new List<Member>();
            List<Book> books = new List<Book>();

            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri("https://localhost:7041/");
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));


                    HttpResponseMessage responseBorrowedBook = await httpClient.GetAsync($"GetBorrowedBookByID?id={id}");
                    HttpResponseMessage responseAuthors = await httpClient.GetAsync("GetMembers");
                    HttpResponseMessage responseBooks = await httpClient.GetAsync("GetBooks");

                    if (responseBorrowedBook.IsSuccessStatusCode && responseAuthors.IsSuccessStatusCode && responseBooks.IsSuccessStatusCode)
                    {
                        string dataBorrowedBook = await responseBorrowedBook.Content.ReadAsStringAsync();
                        string dataAuthors = await responseAuthors.Content.ReadAsStringAsync();
                        string dataBooks = await responseBooks.Content.ReadAsStringAsync();

                        borrowedBook = JsonConvert.DeserializeObject<BorrowedBook>(dataBorrowedBook);
                        authors = JsonConvert.DeserializeObject<List<Member>>(dataAuthors);
                        books = JsonConvert.DeserializeObject<List<Book>>(dataBooks);
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
            ViewBag.Authors = authors;
            ViewBag.Books = books;

            return View(borrowedBook);

        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(BorrowedBook model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PutAsync("UpdateBorrowedBook", content);

            if (response.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");

            }

            return View();
        }


        [HttpGet]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            BorrowedBook bk = new BorrowedBook();
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri("https://localhost:7041/");
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await httpClient.GetAsync($"GetBorrowedBookByID?id={id}");

                    if (response.IsSuccessStatusCode)
                    {
                        string data = await response.Content.ReadAsStringAsync();

                        bk = JsonConvert.DeserializeObject<BorrowedBook>(data);
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
                HttpResponseMessage response = await _httpClient.DeleteAsync($"/DeleteBorrowedBook/{id}");

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
