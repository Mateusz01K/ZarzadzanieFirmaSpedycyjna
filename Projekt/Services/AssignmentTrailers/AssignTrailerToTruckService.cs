using Projekt.Context;
using Projekt.Models.AssignTrailerToTruck;

namespace Projekt.Services.AssignTrailerToTruck
{
    public class AssignTrailerToTruckService : IAssignTrailerToTruckService
    {

        private readonly TruckContext _context;
        public AssignTrailerToTruckService(TruckContext context)
        {
            _context = context;
        }
        public void AssignTrailerToTruck(int truckId, int trailerId)
        {
            var truck = _context.Trucks.FirstOrDefault(x => x.Id == truckId);
            var trailer = _context.Trailers.FirstOrDefault(x => x.Id == trailerId);
            if (truck != null && trailer != null && !trailer.IsAssigned && !truck.IsAssignedTrailer)
            {
                trailer.IsAssigned = true;
                truck.IsAssignedTrailer = true;
                _context.AssignmentTrailers.Add(new AssignTrailerToTruckModel
                {
                    Truck = truck,
                    Trailer = trailer,
                    AssignmentDate = DateTime.Now,
                    ReturnDate = DateTime.Now.AddDays(365),
                    IsReturned = false
                });
                _context.SaveChanges();
            }
        }

        public void DeleteAssignTrailer(int id)
        {
            var assignmentTrailers = _context.AssignmentTrailers.FirstOrDefault(x => x.Id == id);

            if (assignmentTrailers != null)
            {
                var trailer = _context.Trailers.FirstOrDefault(x => x.Id == assignmentTrailers.TrailerId);
                var truck = _context.Trucks.FirstOrDefault(x => x.Id == assignmentTrailers.TruckId);
                if (trailer != null)
                {
                    trailer.IsAssigned = false;
                    truck.IsAssignedTrailer = false;
                }
                _context.AssignmentTrailers.Remove(assignmentTrailers);
                _context.SaveChanges();
            }
        }

        public AssignTrailerToTruckModel GetAssignTrailers(int id)
        {
            var assignmentTruck = _context.AssignmentTrailers.FirstOrDefault(x => x.Id == id);
            return assignmentTruck ?? new AssignTrailerToTruckModel();
        }

        public List<AssignTrailerToTruckModel> GetAssignTrailers()
        {
            return _context.AssignmentTrailers.ToList();
        }

        public void ReturnAssignTrailer(int id)
        {
            var assignmentTrailers = _context.AssignmentTrailers.FirstOrDefault(x => x.Id == id);

            if (assignmentTrailers != null)
            {
                assignmentTrailers.IsReturned = true;
                assignmentTrailers.ReturnDate = DateTime.Now;
                var trailer = _context.Trailers.FirstOrDefault(x => x.Id == assignmentTrailers.TrailerId);
                var truck = _context.Trucks.FirstOrDefault(x => x.Id == assignmentTrailers.TruckId);
                if (trailer != null)
                {
                    trailer.IsAssigned = false;
                    truck.IsAssignedTrailer = false;
                }
                _context.SaveChanges();
            }
        }
    }
}
