using Projekt.Models.Trucks;
using Projekt.Models.Users;

namespace Projekt.Models.AssignmentTruck
{
    public class AssignmentViewModel
    {
        public AssignmentViewModel() 
        { 

        }

        public List<AssignmentModel> AssignmentTrucks { get; set; }
        public List<TrucksModel> Trucks { get; internal set; }
        public List<UserModel> Users { get; internal set; }
    }
}
