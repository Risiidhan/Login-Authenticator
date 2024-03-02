using PizzaDot.Models;

namespace PizzaDot.Interfaces
{
    public interface IUser
    {
        string VerifyUser(User user);
        User RegisterUser(User user);
    }
}
