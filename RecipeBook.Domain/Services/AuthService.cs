using System;
using System.Threading.Tasks;
using RecipeBook.Domain.Models;

namespace RecipeBook.Domain.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;

        public AuthService(IUserService userService)
        {
            this._userService = userService;
        }

        public async Task<User> Login(string username, string password)
        {
            User user = await this._userService.FindByUsername(username);

            if (user == null)
            {
                throw new ArgumentException("User not found!");
            }

            //TODO hash password!
            if (user.Password != password)
            {
                throw new ArgumentException("Wrong password!");
            }

            return user;
        }

        public async Task<User> Register(string username, string password)
        {
            return await this._userService.CreateUser(username, password);
        }
    }
}
