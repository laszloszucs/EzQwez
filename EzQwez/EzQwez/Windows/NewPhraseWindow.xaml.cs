using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ApplicationCore.Models;
using EzQwez.Models;
using Infrastructure;

namespace EzQwez.Windows
{
    public partial class NewPhraseWindow
    {
        private readonly PhraseContext _context;
        public PhraseViewModel CurrentPhrase = new PhraseViewModel();

        public NewPhraseWindow(PhraseContext context)
        {
            InitializeComponent();

            _context = context;
            DataContext = CurrentPhrase;
        }
        
        private async void SaveButton_OnClick(object sender, RoutedEventArgs e)
        {
            await Task.Run(() => SaveChanges(LoadingIndicatorPanel));
            Close();
        }

        internal void SaveChanges(Grid loadingIndicatorPanel)
        {
            Dispatcher?.Invoke(() =>
            {
                loadingIndicatorPanel.Visibility = Visibility.Visible;
                try
                {
                    _context.Add(new Phrase
                    {
                        English = CurrentPhrase.English,
                        Hungarian = CurrentPhrase.Hungarian
                    });

                    if (_context.ChangeTracker.HasChanges())
                    {
                        _context.SaveChanges();
                        // TODO Notification Changes are done!
                    }

                    // TODO Notification Nothing to changed!
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    // TODO Notification Error!
                    throw;
                }

                loadingIndicatorPanel.Visibility = Visibility.Hidden;
            });
        }
    }
}
