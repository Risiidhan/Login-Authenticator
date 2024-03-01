using PizzaDot.Models;

namespace PizzaDot.Interfaces
{
    public interface IUser
    {
        User VerifyUser(User user);
        User RegisterUser(User user);
    }
}
