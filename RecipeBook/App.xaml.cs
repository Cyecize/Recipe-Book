using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using RecipeBook.Domain.Models;
using RecipeBook.Domain.Services;
using RecipeBook.EntityFramework;
using RecipeBook.EntityFramework.Services;
using RecipeBook.State.Authentication;
using RecipeBook.State.Navigation;
using RecipeBook.ViewModels;
using RecipeBook.ViewModels.Factories;

namespace RecipeBook
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IServiceProvider serviceProvider = this.GetServiceProvider();

            serviceProvider.GetRequiredService<MainWindow>().Show();

            base.OnStartup(e);
        }

        private IServiceProvider GetServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<RecipeBookDbContextFactory>();
            services.AddSingleton<IDataService<User, long>, DataService<User, long>>();

            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IAuthService, AuthService>();
            services.AddSingleton<IAuthenticator, Authenticator>();
            

            //View model factories
            services.AddSingleton<IViewModelAbstractFactory, ViewModelAbstractFactory>();
            services.AddSingleton<IViewModelFactory<AddRecipeViewModel>, AddRecipeViewModelFactory>();
            services.AddSingleton<IViewModelFactory<SearchViewModel>, SearchViewModelFactory>();
            services.AddSingleton<IViewModelFactory<MyRecipesViewModel>, MyRecipesViewModelFactory>();
            services.AddSingleton<IViewModelFactory<LoginViewModel>, LoginViewModelFactory>();

            services.AddScoped<INavigator, Navigator>();
            services.AddScoped<MainViewModel>();

            services.AddScoped<MainWindow>(sp => new MainWindow(sp.GetRequiredService<MainViewModel>()));
            return services.BuildServiceProvider();
        }
    }
}
