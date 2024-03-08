using PizzaDot.Interfaces;
using PizzaDot.Models;
using PizzaDot.Mapper;
using PizzaDot.Dtos;
using System.Linq;

namespace PizzaDot.Services
{
    public class UserService : IUser
    {
        private readonly ApplicationDBContext _context;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtAuth _jwtAuth;

        public UserService(ApplicationDBContext dBContext, IPasswordHasher passwordHasher, IJwtAuth jwt)
        {
            _context = dBContext;
            _passwordHasher = passwordHasher;
            _jwtAuth = jwt; 
        }

        public User RegisterUser(User user)
        {
            if (user == null)
                return null;

            var passwordHash = _passwordHasher.Hash(user.password);
            user.password = passwordHash;

            _context.User.Add(user);
            _context.SaveChanges();
            return user;
        }

        public string VerifyUser(User user)
        {
            var foundUser = _context.User.FirstOrDefault(u => u.username == user.username);
            if (foundUser == null)
                return null;

            if(!_passwordHasher.Verify(foundUser.password, user.password))
                return null;

            var token = _jwtAuth.GenerateJwtToken(foundUser);
            return token;
        }

        public IEnumerable<UserDto> GetAllUser()
        {
            return _context.User.ToList()
                .Select(s => UserMapper.MapToUserDto(s));
        }

        public UserDto GetUserByID(int id)
        {
            var foundUser = _context.User.Where(x => x.id == id).FirstOrDefault() ?? null;
            return UserMapper.MapToUserDto(foundUser);
        }
    }
}
