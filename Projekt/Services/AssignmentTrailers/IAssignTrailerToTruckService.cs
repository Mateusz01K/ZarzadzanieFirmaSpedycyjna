using Projekt.Models.AssignmentTruck;
using Projekt.Models.AssignTrailerToTruck;

namespace Projekt.Services.AssignTrailerToTruck
{
    public interface IAssignTrailerToTruckService
    {
        public void AssignTrailerToTruck(int truckId, int trailerId);
        public AssignTrailerToTruckModel GetAssignTrailers(int id);
        public List<AssignTrailerToTruckModel> GetAssignTrailers();

        public void DeleteAssignTrailer(int id);
        public void ReturnAssignTrailer(int id);
    }
}
