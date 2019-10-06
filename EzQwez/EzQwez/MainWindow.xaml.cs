using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ApplicationCore.Models;
using EzQwez.Models;
using EzQwez.Services;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace EzQwez
{
    public partial class MainWindow
    {
        private readonly ISampleService _sampleService;
        private readonly AppSettings _settings;
        private readonly PhraseContext _context;
        public ObservableCollection<Phrase> Phrases { get; set; }

        public MainWindow(ISampleService sampleService, IOptions<AppSettings> settings, PhraseContext context)
        {
            InitializeComponent();

            _sampleService = sampleService;
            _context = context;
            _settings = settings.Value;
            _context.Phrases.Load();
            AppDataGrid.DataContext = _context.Phrases.Local.ToObservableCollection();
        }

        private async void SaveButton_OnClick(object sender, RoutedEventArgs e)
        {
            await Task.Run(() => SaveChanges(LoadingIndicatorPanel));
        }

        internal void SaveChanges(Grid loadingIndicatorPanel)
        {
            Dispatcher.Invoke(() =>
            {
                loadingIndicatorPanel.Visibility = Visibility.Visible;
            });
            
            try
            {
                if (_context.ChangeTracker.HasChanges())
                {
                    _context.SaveChanges();
                    // Changes are done!
                }

                // Nothing to changed!
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                // Error!
                throw;
            }
            finally
            {
                Dispatcher.Invoke(() =>
                {
                    loadingIndicatorPanel.Visibility = Visibility.Hidden;
                });
            }
        }
    }
}
