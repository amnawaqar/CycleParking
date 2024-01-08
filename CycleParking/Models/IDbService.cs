namespace CycleParking.Models
{
    public interface IDbService
    {
        List<CycleParkingService> GetCycleParkings();
        CycleParkingService GetCycleParkingDetails(int id);

    }
}