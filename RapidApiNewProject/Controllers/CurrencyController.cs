using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiNewProject.Models;

namespace RapidApiNewProject.Controllers
{
    public class CurrencyController : Controller
    {
        public async Task<IActionResult> Index()
        {
      
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com15.p.rapidapi.com/api/v1/meta/getExchangeRates?base_currency=TRY"),
                Headers =
    {
        { "x-rapidapi-key", "72cbb4ac4emsh3afb8a14be06363p13e816jsn74e082590fd8" },
        { "x-rapidapi-host", "booking-com15.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<ExchangeModelView>(body); 
                return View(values.data.exchange_rates.ToList());
            }

            
        }
    }
}
