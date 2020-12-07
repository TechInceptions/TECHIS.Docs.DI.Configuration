using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TECHIS.Docs.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly bool _isSupportMode;
        private readonly IRepository<long> _repository;

        public CustomerService(IRepository<long> repository, Config.CustomerService customerServiceConfig)
        {
            _isSupportMode = customerServiceConfig.IsSupportMode;
            _repository = repository;
        }
        public async Task<IEnumerable<Customer>> GetAll()
        {
            return (await _repository.GetAll()).Where(customer=> !customer.IsDeleted || _isSupportMode) ;
        }

        public async Task<Customer> GetCustomer(long id)
        {
            var customer = await _repository.Get(id);

            if ( customer.IsDeleted && !_isSupportMode)
            {
                return null;
            }

            return customer;
        }
    }
}
