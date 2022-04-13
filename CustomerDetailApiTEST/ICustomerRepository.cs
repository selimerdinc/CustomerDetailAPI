using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerDetailApiTEST
{
    public interface ICustomerRepository
    {


        IList<Customer> GetAll();
        Customer GetById(int customerId);
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(int Id);
    }
}
