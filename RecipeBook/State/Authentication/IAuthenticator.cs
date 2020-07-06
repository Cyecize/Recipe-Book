using System.Threading.Tasks;
using RecipeBook.Domain.Models;

namespace RecipeBook.State.Authentication
{
    public interface IAuthenticator
    {
        User CurrentUser { get; }

        bool IsLoggedIn { get; }

        Task<User> Register(string username, string password, string passwordConfirm);

        string Login(string username, string password);

        void Logout();
    }
}
