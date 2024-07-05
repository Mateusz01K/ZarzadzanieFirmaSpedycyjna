using Projekt.Context;
using Projekt.Models.Users;

namespace Projekt.Services.User
{
    public class UserService : IUserService
    {
        private readonly TruckContext _context;
        public UserService(TruckContext context)
        {
            _context = context;
        }

        public UserModel GetUsers(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            return user ?? new UserModel();
        }

        public List<UserModel> GetUsers()
        {
            return _context.Users.ToList();
        }

        public void CreateUser(string FirstName, string LastName, string Email)
        {
            var lastID = _context.Users.OrderByDescending(x => x.Id).FirstOrDefault()?.Id;
            if (lastID != null)
            {
                _context.Users.Add(new UserModel()
                {
                    Id = (int)lastID + 1,
                    FirstName = FirstName,
                    LastName = LastName,
                    Email = Email
                });
                _context.SaveChanges();
            }
        }

        public void UpDateUser(int id, string FirstName, string LastName, string Email)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                user.FirstName = FirstName;
                user.LastName = LastName;
                user.Email = Email;
            }
            _context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
    }
}