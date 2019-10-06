using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
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

            Phrases = new ObservableCollection<Phrase>(_context.Phrases);

            AppDataGrid.DataContext = Phrases;
        }

        private void SaveButton_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (var phrase in Phrases)
                {
                    var first = _context.Phrases.Find(phrase.Id);

                    if (first != null)
                    {
                        first = phrase;
                        _context.Entry(first).State = EntityState.Modified;
                    }
                    else
                    {
                        _context.Phrases.Add(phrase);
                        _context.Entry(phrase).State = EntityState.Added;
                    }
                }

                var removes = _context.Phrases.ToList().Except(Phrases);

                _context.RemoveRange(removes);

                if (_context.ChangeTracker.HasChanges())
                {
                    _context.SaveChanges();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
    }
}
