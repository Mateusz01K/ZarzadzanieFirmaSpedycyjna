using Projekt.Models.Users;

namespace Projekt.Services.User
{
    public interface IUserService
    {
        public List<UserModel> GetUsers();
        public UserModel GetUsers(int id);
        public void CreateUser(string FirstName, string LastName, string Email);
        public void UpDateUser(int id, string FirstName, string LastName, string Email);
        public void DeleteUser(int id);
    }
}