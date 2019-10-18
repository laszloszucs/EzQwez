using System;
using System.Windows;
using System.Windows.Input;
using EzQwez.Commands;
using EzQwez.Services;
using EzQwez.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace EzQwez
{
    public partial class MyNotifyIcon
    {
        public readonly IServiceProvider ServiceProvider;
        public MyNotifyIconViewModel MyNotifyIconViewModel;
        public NewPhraseWindow NewPhraseWindow;
        public PhraseEditorWindow PhraseEditorWindow;

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
            var windowService = ServiceProvider.GetRequiredService<IWindowService>();
            NewPhraseWindow = windowService.NewPhraseWindow;
            PhraseEditorWindow = windowService.PhraseEditorWindow;
        }
        private void NewPhraseMenuItem_Click(object sender, RoutedEventArgs e)
        {
            NewPhraseWindow.Visibility = Visibility.Visible;
            NewPhraseWindow.Activate();
        }

        private void PhraseEditortMenuItem_Click(object sender, RoutedEventArgs e)
        {
            PhraseEditorWindow.Visibility = Visibility.Visible;
            PhraseEditorWindow.Activate();
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
