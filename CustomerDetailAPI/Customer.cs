namespace CustomerDetailAPI
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string lastName { get; set; } = string.Empty;

        public double Phone { get; set; }

        public DateTime createdAt { get; set; }

        public DateTime updateAt { get; set; }

        public byte isEnabled { get; set; }
    }
}