using System;
using System.Threading.Tasks;
using RecipeBook.Domain.Models;

namespace RecipeBook.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IDataService<User, long> _userDataService;

        public UserService(IDataService<User, long> userDataService)
        {
            _userDataService = userDataService;
        }

        public async Task<User> FindByUsername(string username)
        {
            return await this._userDataService.FindOneBy(user => user.Username == username);
        }

        public async Task<User> FindById(long id)
        {
            return await this._userDataService.Find(id);
        }

        public async Task<User> CreateUser(string username, string password)
        {
            User existingUser = await this.FindByUsername(username);

            if (existingUser != null) throw new ArgumentException("Username taken!");

            User user = new User()
            {
                Username = username,
                Password = password,
                DateRegistered = DateTime.Now
            };

            return await this._userDataService.Create(user);
        }
    }
}
