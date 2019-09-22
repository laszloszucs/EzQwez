using EzQwez.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EzQwez.Application.Repositories
{
    public interface IPhraseRepository
    {
        IEnumerable<Phrase> Get();
        Phrase Get(int id);
        Task<Phrase> GetAsync(int id);
        Task AddAsync(Phrase phrase);
        void Update(Phrase phrase);
        void Delete(Phrase phrase);
    }
}
