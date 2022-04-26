namespace CustomerDetailAPI.Controllers
{
    public class CustomerRepository
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public double Phone { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public byte isEnabled { get; set; }
    }
}
