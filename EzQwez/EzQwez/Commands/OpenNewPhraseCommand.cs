﻿using System;
using System.Windows.Input;
using EzQwez.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EzQwez.Commands
{
    public class OpenNewPhraseCommand : ICommand
    {
        private readonly IServiceProvider _serviceProvider;

        public OpenNewPhraseCommand(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void Execute(object parameter)
        {
            var windowService = _serviceProvider.GetRequiredService<IWindowService>();
            var newPhraseWindow = windowService.NewPhraseWindow;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;
    }
}
