using EzQwez.Application.Repositories;
using EzQwez.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace EzQwez.Infrastructure.EntityFrameworkDataAccess.Repositories
{
    public class PhraseRepository : IPhraseRepository
    {
        private readonly ApplicationContext _context;

        public PhraseRepository(ApplicationContext context)
        {
            _context = context ??
                throw new ArgumentNullException(nameof(context));
        }
        
        public ObservableCollection<Phrase> observablePhrases { get => new ObservableCollection<Phrase>(_context.Phrases); }

        public void Add(Phrase phrase)
        {
            _context.Phrases.Add(phrase);
        }

        public async Task AddAsync(Phrase phrase)
        {
            await _context.Phrases.AddAsync(phrase);
        }

        public void Delete(Phrase phrase)
        {
            _context.Phrases.Remove(phrase);
        }

        public IEnumerable<Phrase> Get()
        {
            return _context.Phrases.ToList();
        }

        public Phrase Get(int id)
        {
            return _context
               .Phrases
               .Where(a => a.Id == id)
               .FirstOrDefault();
        }

        public async Task<Phrase> GetAsync(int id)
        {
            return await _context
                .Phrases
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();
        }

        public void Update(Phrase phrase)
        {
            _context.Phrases.Update(phrase);
        }
    }
}
