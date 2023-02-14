using BookingAPI.IService;
using BookingAPI.Models;
using BookingAPI.Common;


namespace BookingAPI.Service
{
    public class UserService : IUserService
    {
        public List<UserLogin> GetAllUsers()
        {
            return Global.ul;
        }

        public UserLogin Login(UserLogin OUser)
        {
            var user = Global.ul.SingleOrDefault(x=>x.UserName == OUser.UserName);


            bool isValidPassword = BCrypt.Net.BCrypt.Verify(OUser.Password, user.Password);

            if (isValidPassword)
            {
                return user;
            }
            return null;
        }

        public UserLogin Signup(UserLogin OUser)
        {
            OUser.Password = BCrypt.Net.BCrypt.HashPassword(OUser.Password);
            Global.ul.Add(OUser);

            return OUser;
        }
    }
}
