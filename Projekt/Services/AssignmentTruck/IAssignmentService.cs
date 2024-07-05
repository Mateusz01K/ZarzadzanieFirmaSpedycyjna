using Projekt.Models.AssignmentTruck;

namespace Projekt.Services.AssignmentTruck
{
    public interface IAssignmentService
    {
        public void AssignmentTruck(int truckId, int userId);
        public AssignmentModel GetAssignments(int id);
        public List<AssignmentModel> GetAssignments();

        public void DeleteAssignment(int id);
        public void ReturnAssignment(int id);
        
    }
}