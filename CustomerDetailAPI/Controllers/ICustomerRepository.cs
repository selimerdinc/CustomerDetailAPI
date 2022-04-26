using CustomerDetailAPI;

namespace customerApi.Controllers
{
    public interface ICustomerRepository
    {

        IList<Customer> GetAll();
        Customer GetById(int customerId);
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(int Id);
        Task ListAsync();
        Task GetByIdAsync(int id);
    }
}