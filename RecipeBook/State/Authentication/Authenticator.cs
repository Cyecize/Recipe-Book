using System;
using System.Threading.Tasks;
using RecipeBook.Domain.Models;
using RecipeBook.Domain.Services;
using RecipeBook.Models;

namespace RecipeBook.State.Authentication
{
    public class Authenticator : ObservableObject, IAuthenticator
    {
        private readonly IAuthService _authService;

        private User _currentUser;

        public User CurrentUser
        {
            get => this._currentUser;
            private set
            {
                this._currentUser = value;
                base.OnPropertyChanged(nameof(CurrentUser));
                base.OnPropertyChanged(nameof(IsLoggedIn));
            }
        }

        public bool IsLoggedIn => CurrentUser != null;

        public Authenticator(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<User> Register(string username, string password, string passwordConfirm)
        {
            if (password != passwordConfirm) throw new ArgumentException("Passwords do not match!");

            User registeredUser = await this._authService.Register(username, password);

            return registeredUser;
        }

        public string Login(string username, string password)
        {
            string message = string.Empty;

            try
            {
                User user = this._authService.Login(username, password).Result;
                this.CurrentUser = user;
            }
            catch (Exception ex)
            {
                this.CurrentUser = null;
                message = ex.Message; ;
            }

            return message;
        }

        public void Logout()
        {
            this.CurrentUser = null;
        }
    }
}
