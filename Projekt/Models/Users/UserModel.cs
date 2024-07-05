using Projekt.Models.AssignmentTruck;

namespace Projekt.Models.Users
{
    public class UserModel
    {
        public UserModel() { }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsAssignedTruck { get; set; }
        public ICollection<AssignmentModel> Assignments { get; set; }
    }
}
