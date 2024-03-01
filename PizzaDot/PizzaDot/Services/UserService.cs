using PizzaDot.Interfaces;
using PizzaDot.Models;

namespace PizzaDot.Services
{
    public class UserService : IUser
    {
        private readonly ApplicationDBContext _context;

        public UserService(ApplicationDBContext dBContext)
        {
            _context = dBContext;
        }

        public User RegisterUser(User user)
        {
            if (user == null)
                return null;

            _context.User.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User VerifyUser(User user)
        {
            var foundUser = _context.User.FirstOrDefault(u => u.username == user.username && u.password == user.password);
            if (foundUser == null)
                return null;

            return foundUser;
        }
    }
}
