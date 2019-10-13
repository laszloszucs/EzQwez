using System;
using EzQwez.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace EzQwez.Services
{
    public class WindowService : IWindowService
    {
        private readonly IServiceProvider _serviceProvider;
        NewPhraseWindow _newPhraseWindow;
        PhraseEditorWindow _phraseEditorWindow;

        public WindowService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public NewPhraseWindow NewPhraseWindow
        {
            get
            {
                if (_newPhraseWindow != null)
                {
                    return _newPhraseWindow;
                }

                _newPhraseWindow = _serviceProvider.GetRequiredService<NewPhraseWindow>();
                _newPhraseWindow.Closed += (sender, args) => _newPhraseWindow = null;

                return _newPhraseWindow;
            }
        }

        public PhraseEditorWindow PhraseEditorWindow
        {
            get
            {
                if (_phraseEditorWindow != null)
                {
                    return _phraseEditorWindow;
                }

                _phraseEditorWindow = _serviceProvider.GetRequiredService<PhraseEditorWindow>();
                _phraseEditorWindow.Closed += (sender, args) => _phraseEditorWindow = null;

                return _phraseEditorWindow;
            }
        }
    }

    public interface IWindowService
    {
        NewPhraseWindow NewPhraseWindow { get; }
        PhraseEditorWindow PhraseEditorWindow { get; }
    }
}
