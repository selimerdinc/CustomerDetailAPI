
using Microsoft.AspNetCore.Mvc;

namespace CustomerDetailAPI
{
    public class fromQuery
    {
        [FromQuery]
        public int Id { get; set; }

        [FromQuery]
        public string Name { get; set; } = string.Empty;

        [FromQuery]
        public string lastName { get; set; } = string.Empty;

        [FromQuery]

        public double? Phone { get; set; }

        [FromQuery]

        public DateTime? createdAt { get; set; }

        [FromQuery]

        public DateTime? updateAt { get; set; }

        [FromQuery]

        public byte? isEnabled { get; set; }


    }
}
