
namespace CustomerDetailAPI.Services
{
    public interface ICustomerRepository
    {

        IQueryable<Customer> GetAll();
        Customer GetById(int customerId);
        void AddCustomer(Customer customer);
        void UpdateCustomer(int id, Customer b);
        void DeleteCustomer(int id);
  
    }   
     

    public class CustomerRepository : ICustomerRepository
        {
        private DataContext _context;
        public CustomerRepository(DataContext dataContext)
            {
            _context = dataContext;
            }

       

        public void AddCustomer(Customer b)
            {
            _context.CustomersDb.Add(b);
                int res = _context.SaveChanges();
               
            }

        public void DeleteCustomer(int id)
            {
                int res = 0;
                var customer = _context.CustomersDb.FirstOrDefault(b => b.Id == id);
                if (customer != null)
                {
                _context.CustomersDb.Remove(customer);
                    res = _context.SaveChanges();
                }
            }



        public  Customer GetById(int id)
            {
                var customerId = _context.CustomersDb.FirstOrDefault(b => b.Id == id);
                return customerId;
            }

        public IQueryable<Customer> GetAll()
            {
                var customerAll = _context.CustomersDb.ToList();
                return customerAll.AsQueryable();
            }

        public void UpdateCustomer(int id,Customer request)
            {
               
                var customer = _context.CustomersDb.Find(id);
                if (customer != null)
                {
                customer.Name = request.Name;
                customer.LastName = request.LastName;
                customer.Phone = request.Phone;
                customer.CreatedAt = request.CreatedAt;
                customer.UpdateAt = request.UpdateAt;
                customer.isEnabled = request.isEnabled;
                _context.CustomersDb.Update(customer);
                _context.SaveChanges();
                }
               
            }

      
    }
    }
