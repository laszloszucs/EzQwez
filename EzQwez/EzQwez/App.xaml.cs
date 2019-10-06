using System;
using System.IO;
using System.Windows;
using ApplicationCore;
using ApplicationCore.Interfaces;
using EzQwez.Models;
using EzQwez.Services;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace EzQwez
{
    public partial class App
    {
        public IServiceProvider ServiceProvider { get; private set; }
        public IConfiguration Configuration { get; private set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true);
            
            Configuration = builder.Build();

            // Create a service collection and configure our dependencies
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection, Configuration);

            // Build the our IServiceProvider and set our static reference to it
            ServiceProvider = serviceCollection.BuildServiceProvider();
            
            var runner = ServiceProvider.GetRequiredService<ILogger<App>>();
            runner.LogInformation("OnStartup");

            SeedDatabase(ServiceProvider);

            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private static void SeedDatabase(IServiceProvider serviceProvider)
        {
            try
            {
                var databaseInitializer = serviceProvider.GetRequiredService<IPhraseContextSeed>();
                databaseInitializer.SeedAsync().Wait();
            }
            catch (Exception ex)
            {
                var logger = serviceProvider.GetRequiredService<ILogger<App>>();
                logger.LogCritical(ex, ex.Message);

                throw;
            }
        }

        private void ConfigureServices(IServiceCollection services, IConfiguration config)
        {
            services.Configure<AppSettings>(Configuration.GetSection(nameof(AppSettings)));

            services
                .AddLogging(loggingBuilder =>
                {
                    // configure Logging with NLog
                    loggingBuilder.ClearProviders();
                    loggingBuilder.SetMinimumLevel(LogLevel.Trace);
                    loggingBuilder.AddNLog(config);
                });

            services
                .AddEntityFrameworkSqlite()
                .AddDbContext<PhraseContext>();

            services.AddTransient<IPhraseContextSeed, PhraseContextSeed>();

            services.AddScoped<ISampleService, SampleService>();

            services.AddTransient(typeof(MainWindow));
        }
    }
}
