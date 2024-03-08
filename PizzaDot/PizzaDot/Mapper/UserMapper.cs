using PizzaDot.Dtos;
using PizzaDot.Models;

namespace PizzaDot.Mapper
{
    public class UserMapper
    {
        public static UserDto MapToUserDto(User user)
        {
            return new UserDto
            {
                id = user.id,
                fullName = user.fullName,
                email = user.email,
                username = user.username,
                role = user.role
            };
        }
    }
}
