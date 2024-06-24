namespace RapidApiNewProject.Models
{
    public class BookingSearchViewModel
    {
        public string destID { get; set; }
        public string cityName { get; set; } 
        public DateTime arrivalDate { get; set; }
        public DateTime departureDate { get; set; }  
        public int adultCount { get; set; }
        public int roomCount { get; set; }  

    }


}

