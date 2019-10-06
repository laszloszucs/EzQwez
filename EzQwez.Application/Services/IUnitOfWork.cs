using EzQwez.Application.Repositories;
using System.Threading.Tasks;

namespace EzQwez.Application.Services
{
    public interface IUnitOfWork
    {
        IPhraseRepository PhraseRepository { get; }
        int SaveChanges();
        Task<int> Save();
    }
}
