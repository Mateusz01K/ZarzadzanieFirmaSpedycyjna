using Projekt.Context;
using Projekt.Models.Trucks;
using Projekt.Models.AssignmentTruck;

namespace Projekt.Services.AssignmentTruck
{
    public class AssignmentService : IAssignmentService
    {
        private readonly TruckContext _context;
        public AssignmentService(TruckContext context)
        {
            _context = context;
        }
        public AssignmentModel GetAssignments(int id)
        {
            var assignment = _context.Assignments.FirstOrDefault(x => x.Id == id);
            return assignment ?? new AssignmentModel();
        }

        public List<AssignmentModel> GetAssignments()
        {
            return _context.Assignments.ToList();
        }

        public void AssignmentTruck(int truckId, int userId)
        {
            var truck = _context.Trucks.FirstOrDefault(x => x.Id == truckId);
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);
            if (truck != null && user != null && !truck.IsAssignedUser && !user.IsAssignedTruck)
            {
                truck.IsAssignedUser = true;
                user.IsAssignedTruck = true;
                _context.Assignments.Add(new AssignmentModel
                {
                    Truck = truck,
                    User = user,
                    AssignmentDate = DateTime.Now,
                    ReturnDate = DateTime.Now.AddDays(365)
                });
                _context.SaveChanges();
            }
        }

        public void DeleteAssignment(int id)
        {
            var assignment = _context.Assignments.FirstOrDefault(x => x.Id == id);

            if (assignment != null)
            {
                var truck = _context.Trucks.FirstOrDefault(x => x.Id == assignment.TruckId);
                var user = _context.Users.FirstOrDefault(x => x.Id == assignment.UserId);
                if(truck != null)
                {
                    truck.IsAssignedUser = false;
                    user.IsAssignedTruck = false;
                }
                _context.Assignments.Remove(assignment);
                _context.SaveChanges();
            }
        }

        public void ReturnAssignment(int id)
        {
            var assignment = _context.Assignments.FirstOrDefault(x => x.Id == id);

            if (assignment != null)
            {
                assignment.IsReturned = true;
                assignment.ReturnDate = DateTime.Now;
                var truck = _context.Trucks.FirstOrDefault(x => x.Id == assignment.TruckId);
                var user = _context.Users.FirstOrDefault(x => x.Id == assignment.UserId);
                if(truck != null)
                {
                    truck.IsAssignedUser = false;
                    user.IsAssignedTruck = false;
                }
                _context.SaveChanges();
            }

        }
    }
}
