using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using ApplicationCore.Interfaces;
using EzQwez.Commands;
using EzQwez.Models;
using EzQwez.Services;
using EzQwez.Windows;
using Infrastructure;
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
            var proc = Process.GetCurrentProcess();

            if (Process.GetProcesses().Count(p => p.ProcessName == proc.ProcessName) > 1)
            {
                MessageBox.Show("Already an instance is running...");
                Shutdown(1);
                return;
            }

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

            ServiceProvider.GetRequiredService<MyNotifyIcon>();
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

            services.AddSingleton<IPhraseContextSeed, PhraseContextSeed>();

            services.AddTransient(typeof(MyNotifyIcon));
            services.AddTransient(typeof(NewPhraseWindow));
            services.AddTransient(typeof(PhraseEditorWindow));
            services.AddTransient(typeof(OpenPhraseEditorCommand));

            services.AddSingleton<IWindowService, WindowService>();

        }
    }
}
