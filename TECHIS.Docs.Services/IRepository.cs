using System.Collections.Generic;
using System.Threading.Tasks;

namespace TECHIS.Docs.Services
{
    public interface IRepository<TIdentifier>
    {
        Task<IEnumerable<Customer>> GetAll();
        Task<Customer> Get(TIdentifier id);
    }
}