using Projekt.Models.Trucks;
using Projekt.Models.Users;

namespace Projekt.Models.AssignmentTruck
{
    public class AssignmentModel
    {
        public AssignmentModel() { }
        public int Id { get; set; }
        public int TruckId { get; set; }
        public TrucksModel Truck { get; set; }
        public int UserId { get; set; }
        public UserModel User { get; set; }
        public DateTime AssignmentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool IsReturned { get; set; }
        

    }
}
