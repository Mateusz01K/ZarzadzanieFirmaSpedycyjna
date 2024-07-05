using Projekt.Models.Trucks;

namespace Projekt.Services.Truck
{
    public interface ITruckService
    {
        public List<TrucksModel> GetTrucks();
        public TrucksModel GetTrucks(int id);
        public void InsertTruck(string Model, string Brand, int Power, int Distance, int YearOfProduction);
        public void UpDateTruck(int id, string Model, string Brand, int Power, int Distance, int YearOfProduction);
        public void DeleteTruck(int id);
    }
}
