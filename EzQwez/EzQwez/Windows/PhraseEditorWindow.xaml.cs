using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace EzQwez.Windows
{
    public partial class PhraseEditorWindow
    {
        private readonly PhraseContext _context;

        public PhraseEditorWindow(PhraseContext context)
        {
            InitializeComponent();

            _context = context;
            _context.Phrases.Load();
            AppDataGrid.DataContext = _context.Phrases.Local.ToObservableCollection();
        }

        private async void SaveButton_OnClick(object sender, RoutedEventArgs e)
        {
            await Task.Run(() => SaveChanges(LoadingIndicatorPanel));
        }

        internal async void SaveChanges(Grid loadingIndicatorPanel)
        {
            Dispatcher?.Invoke(() =>
            {
                loadingIndicatorPanel.Visibility = Visibility.Visible;
            });
            
            try
            {
                if (_context.ChangeTracker.HasChanges())
                {
                    await _context.SaveChangesAsync();
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
            finally
            {
                Dispatcher?.Invoke(() =>
                {
                    loadingIndicatorPanel.Visibility = Visibility.Hidden;
                });
            }
        }
    }
}
