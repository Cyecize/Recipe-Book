using System.Threading.Tasks;
using RecipeBook.Domain.Models;

namespace RecipeBook.Domain.Services
{
    public interface IAuthService
    {
        Task<User> Login(string username, string password);

        Task<User> Register(string username, string password);
    }
}
