using System;
using System.Windows;
using System.Windows.Input;
using EzQwez.Commands;
using EzQwez.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EzQwez
{
    public partial class MyNotifyIcon
    {
        public readonly IServiceProvider ServiceProvider;
        public MyNotifyIconViewModel MyNotifyIconViewModel;

        public MyNotifyIcon(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
            InitializeComponent();
            MyNotifyIconViewModel = new MyNotifyIconViewModel
            {
                OpenNewPhraseCommand = new OpenNewPhraseCommand(serviceProvider),
                OpenPhraseEditorCommand = new OpenPhraseEditorCommand(serviceProvider)
            };
            DataContext = MyNotifyIconViewModel;
        }
        private void NewPhraseMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var windowService = ServiceProvider.GetRequiredService<IWindowService>();
            var newPhraseWindow = windowService.NewPhraseWindow;
        }

        private void PhraseEditortMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var windowService = ServiceProvider.GetRequiredService<IWindowService>();
            var phraseEditorWindow = windowService.PhraseEditorWindow;
        }

        private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
            Application.Current.Shutdown(0);
        }
    }

    public class MyNotifyIconViewModel
    {
        public ICommand OpenNewPhraseCommand { get; set; }
        public ICommand OpenPhraseEditorCommand { get; set; }

    }
}
