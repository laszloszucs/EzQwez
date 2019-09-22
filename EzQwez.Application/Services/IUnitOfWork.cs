using System.Threading.Tasks;

namespace EzQwez.Application.Services
{
    public interface IUnitOfWork
    {
        Task<int> Save();
    }
}
