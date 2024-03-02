using PizzaDot.Models;

namespace PizzaDot.Interfaces
{
    public interface IJwtAuth
    {
        string GenerateJwtToken(User user);
    }
}
