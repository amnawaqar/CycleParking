namespace CycleParking.Models
{
    public class CycleParkingService: ICycleParking
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public string Type { get; set; }
        public string Secure { get; set; }
        public int Capacity { get; set; }
        public string Availability { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
    }
}
