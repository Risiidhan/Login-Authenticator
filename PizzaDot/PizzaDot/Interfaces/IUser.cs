using PizzaDot.Dtos;
using PizzaDot.Models;

namespace PizzaDot.Interfaces
{
    public interface IUser
    {
        string VerifyUser(User user);
        User RegisterUser(User user);
        IEnumerable<UserDto> GetAllUser();
        UserDto GetUserByID(int id);

    }
}
