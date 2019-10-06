using EzQwez.Domain.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace EzQwez.Application.Repositories
{
    public interface IPhraseRepository
    {
        ObservableCollection<Phrase> observablePhrases { get; }
        IEnumerable<Phrase> Get();
        Phrase Get(int id);
        Task<Phrase> GetAsync(int id);
        void Add(Phrase phrase);
        Task AddAsync(Phrase phrase);
        void Update(Phrase phrase);
        void Delete(Phrase phrase);
    }
}
