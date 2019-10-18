using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
            Visibility = Visibility.Hidden;
            Closing += OnClosing;
            MoveToLowerRightCorner();
        }

        private void OnClosing(object sender, CancelEventArgs e)
        {
            Visibility = Visibility.Hidden;
            e.Cancel = true;
        }

        private async void SaveButton_OnClick(object sender, RoutedEventArgs e)
        {
            await Task.Run(() => SaveChanges(LoadingIndicatorPanel));
            CurrentPhrase = new PhraseViewModel();
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

        private void MoveToLowerRightCorner()
        {
            var workingArea = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;

            Top = workingArea.Height - Height;
            Left = workingArea.Width - Width;
        }
    }
}
