using Microsoft.AspNetCore.Mvc;

namespace CustomerDetailAPI
{
    public class Customer
    {
      
        public int Id { get; set; }
     
        public string Name { get; set; } = string.Empty;
      
        public string LastName { get; set; } = string.Empty;
        
        public double Phone { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public byte IsEnabled { get; set; }
    }
}