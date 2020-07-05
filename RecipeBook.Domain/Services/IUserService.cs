using System.Threading.Tasks;
using RecipeBook.Domain.Models;

namespace RecipeBook.Domain.Services
{
    public interface IUserService
    {
        Task<User> FindByUsername(string username);

        Task<User> FindById(long id);

        Task<User> CreateUser(string username, string password);
    }
}
