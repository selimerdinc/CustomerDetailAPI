using Microsoft.EntityFrameworkCore;

namespace CustomerDetailAPI.DB
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Customer> customersdb { get; set; }
    }
}