using EzQwez.Application.Repositories;
using EzQwez.Infrastructure.EntityFrameworkDataAccess;
using EzQwez.Infrastructure.EntityFrameworkDataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using Unity;

namespace EzQwez.Phrases
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        private ServiceProvider _serviceProvider;

        protected override void OnStartup(StartupEventArgs e)
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IPhraseRepository, PhraseRepository>();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            _serviceProvider = serviceCollection.BuildServiceProvider();

            MainWindow mainWindow = container.Resolve<MainWindow>();
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFrameworkNpgsql().AddDbContext<ApplicationContext>(opt =>
                opt.UseNpgsql("Server=localhost;User Id=postgres;Password=o9gtBXIPvH8e8jMz7BTaowD8BskHqipjp3YcfkWzSSrc9AC5V7hYo26GMiTpSd0;Database=EzQwez"));
            services.AddScoped<IPhraseRepository, PhraseRepository>();
            services.AddSingleton<MainWindow>();
        }
    }
}
