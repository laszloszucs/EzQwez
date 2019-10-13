using System;
using System.Windows.Input;
using EzQwez.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EzQwez.Commands
{
    public class OpenPhraseEditorCommand : ICommand
    {
        private readonly IServiceProvider _serviceProvider;

        public OpenPhraseEditorCommand(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void Execute(object parameter)
        {
            var windowService = _serviceProvider.GetRequiredService<IWindowService>();
            var phraseEditorWindow = windowService.PhraseEditorWindow;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;
    }
}
