using Projekt.Models.Trailer;
using Projekt.Models.Trucks;

namespace Projekt.Models.AssignTrailerToTruck
{
    public class AssignTrailerToTruckModel
    {
        public AssignTrailerToTruckModel() { }
        public int Id { get; set; }
        public int TruckId { get; set; }
        public TrucksModel Truck { get; set; }
        public int TrailerId { get; set; }
        public TrailerModel Trailer { get; set; }
        public DateTime AssignmentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool IsReturned { get; set; }
    }
}
