using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiNewProject.Models;
using static RapidApiNewProject.Models.BookingHotelListViewModel;

namespace RapidApiNewProject.Controllers
{
    public class HotelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetSearch(BookingSearchViewModel bookingSearch)
        {

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com15.p.rapidapi.com/api/v1/hotels/searchDestination?query={bookingSearch.cityName}"),

                Headers =
            {
         {  "X-RapidAPI-Key",
                     "e3369bfcf8msh06568cc3ebca78bp192c2cjsn589757bb2c13" },
           { "X-RapidAPI-Host",
               "booking-com15.p.rapidapi.com" },

                }
            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<CityIdViewModel>(body);
                var cityID = values.data[0].dest_id;
                var search = new BookingSearchViewModel
                {
                    destID = cityID,
                    cityName = bookingSearch.cityName,
                    arrivalDate = bookingSearch.arrivalDate,
                    departureDate = bookingSearch.departureDate,
                    adultCount = bookingSearch.adultCount,
                    roomCount = bookingSearch.roomCount,

                };
                return RedirectToAction("HotelList", search);

            }
        }

        public async Task<IActionResult> HotelList(BookingSearchViewModel bookingSearch)
        {

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com15.p.rapidapi.com/api/v1/hotels/searchHotels?dest_id={bookingSearch.destID}&search_type=CITY&arrival_date={bookingSearch.arrivalDate.ToString("yyyy-MM-dd")}&departure_date={bookingSearch.departureDate.ToString("yyyy-MM-dd")}&adults=1&room_qty={bookingSearch.roomCount}&page_number=1&units=metric&temperature_unit=c&languagecode=en-us&currency_code=EUR"),
                Headers =
    {
        { "X-RapidAPI-Key",
                     "e3369bfcf8msh06568cc3ebca78bp192c2cjsn589757bb2c13" },
        { "X-RapidAPI-Host",
                     "booking-com15.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<BookingHotelListViewModel>(body);
                TempData["Photo"] = values.data.hotels[0].property.photoUrls[0].Replace("square60", "square480");
                return View(values.data.hotels.ToList());

            }

        }
        [HttpPost]
        public async Task<IActionResult> RoomDetail(string hotelID, string arrivalDate, string departureDate)
        {

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com15.p.rapidapi.com/api/v1/hotels/getHotelDetails?hotel_id={hotelID}&arrival_date={arrivalDate}&departure_date={departureDate}&adults=1&children_age=0&room_qty=1&units=metric&temperature_unit=c&languagecode=en-us&currency_code=EUR"),
                Headers =
    {
        { "x-rapidapi-key", "e3369bfcf8msh06568cc3ebca78bp192c2cjsn589757bb2c13" },
        { "x-rapidapi-host", "booking-com15.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<BookingDetailViewModel>(body);
                return View(values);
            }
        }
    }

}
