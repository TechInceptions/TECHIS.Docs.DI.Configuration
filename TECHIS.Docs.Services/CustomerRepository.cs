using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TECHIS.Docs.Services
{
    public class CustomerRepository : IRepository<long>
    {
        public CustomerRepository(Config.CustomerRepository customerRepositoryConfig)
        {
            customerRepositoryConfig.Validate(true);
        }
        private class Store
        {
            public static IEnumerable<Customer> Customers = new[] 
                                                    { 
                                                        new Customer { FirstName = "John", LastName = "Doe", Id = 1001 },
                                                        new Customer { FirstName = "Jane", LastName = "Doe", Id = 1010 },
                                                        new Customer { FirstName = "Joe",  LastName = "Doe", Id = 1020 },
                                                        new Customer { FirstName = "Jill", LastName = "Doe", Id = 1030 },
                                                        new Customer { FirstName = "Bad", LastName = "Joe", Id = 1040 , IsDeleted = true }
                                                    };
        }

        public Task<Customer> Get(long id)
        {
            return Task.FromResult( Store.Customers.Where(customer=> customer.Id==id).FirstOrDefault());
        }

        public Task<IEnumerable<Customer>> GetAll()
        {
            return Task.FromResult(Store.Customers);
        }
    }
}
