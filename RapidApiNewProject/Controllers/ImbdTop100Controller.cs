using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiNewProject.Models;

namespace RapidApiNewProject.Controllers
{
    public class ImbdTop100Controller : Controller
    {
        public async Task<IActionResult> Index()
        {

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
                Headers =
    {
        { "x-rapidapi-key", "72cbb4ac4emsh3afb8a14be06363p13e816jsn74e082590fd8" }, //kendi api keyim 
        { "x-rapidapi-host", "imdb-top-100-movies.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<MovieViewModel>>(body);
                return View(values);
            }
        }
    }
}
