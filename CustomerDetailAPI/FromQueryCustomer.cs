
using Microsoft.AspNetCore.Mvc;

namespace CustomerDetailAPI
{
    public class FromQueryCustomer
    {
        [FromQuery]
        public int Id { get; set; }

        [FromQuery]
        public string Name { get; set; } = string.Empty;

        [FromQuery]
        public string LastName { get; set; } = string.Empty;

        [FromQuery]

        public double? Phone { get; set; }  //? == null değer alabilir.

        [FromQuery]

        public DateTime? CreatedAt { get; set; }

        [FromQuery]

        public DateTime? UpdateAt { get; set; }

        [FromQuery]

        public byte? isEnabled { get; set; }


    }
}
