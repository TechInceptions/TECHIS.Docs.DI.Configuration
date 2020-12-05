using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TECHIS.Docs.Services
{
    public interface ICustomerService
    {
        Task<Customer> GetCustomer(long id);
        Task<IEnumerable<Customer>> GetAll();
    }
}
