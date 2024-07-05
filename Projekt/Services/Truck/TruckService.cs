using Projekt.Context;
using Projekt.Models.Trucks;

namespace Projekt.Services.Truck
{
    public class TruckService : ITruckService
    {
        private readonly TruckContext _context;
        public TruckService(TruckContext context)
        {
            _context = context;
        }
        public TrucksModel GetTrucks(int id)
        {
            var truck = _context.Trucks.FirstOrDefault(x => x.Id == id);
            return truck ?? new TrucksModel();
        }

        public List<TrucksModel> GetTrucks()
        {
            return _context.Trucks.ToList();
        }

        public void InsertTruck(string Model, string Brand, int Power, int Distance, int YearOfProduction)
        {
            var lastID = _context.Trucks.OrderByDescending(x => x.Id).FirstOrDefault()?.Id;
            if (lastID != null)
            {
                _context.Trucks.Add(new TrucksModel()
                {
                    Id = (int)lastID + 1,
                    Model = Model,
                    Brand = Brand,
                    Power = Power,
                    Distance = Distance,
                    YearOfProduction = YearOfProduction
                });
                _context.SaveChanges();
            }
        }
        public void UpDateTruck(int id, string Model, string Brand, int Power, int Distance, int YearOfProduction)
        {
            var truck = _context.Trucks.FirstOrDefault(x => x.Id == id);
            if (truck != null)
            {
                truck.Model = Model;
                truck.Brand = Brand;
                truck.Power = Power;
                truck.Distance = Distance;
                truck.YearOfProduction = YearOfProduction;
                _context.SaveChanges();
            }
        }

        public void DeleteTruck(int id)
        {
            var truck = _context.Trucks.FirstOrDefault(_x => _x.Id == id);
            if (truck != null)
            {
                _context.Trucks.Remove(truck);
                _context.SaveChangesAsync();
            }
        }
    }
}
