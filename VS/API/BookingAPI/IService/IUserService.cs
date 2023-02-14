using BookingAPI.Models;
namespace BookingAPI.IService
{
    public interface IUserService
    {
        UserLogin Signup(UserLogin OUser);

        UserLogin Login(UserLogin OUser);

        List<UserLogin> GetAllUsers();
    }
}
