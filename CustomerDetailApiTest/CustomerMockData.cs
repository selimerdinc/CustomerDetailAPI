using CustomerDetailAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerDetailApiTest
{
    public class CustomerMockData
    {
        public static Customer Three_Different_Customer()
        {
            return new Customer
            {
                Id = 10,
                Name = "selimselim",
                LastName = "deneme123",
                Phone = 11111111111,
                isEnabled = 0
            };
        }


            // existing code hidden for display purpose
            public static Customer NewCustomer()
            {
                return new Customer
                {
                    Id = 1,
                    Name = "erdincerdinc",
                    LastName = "testtesttest",
                    Phone = 5315313131,
                    isEnabled=1
                };
            }
             public static Customer GetCustomer()
             {
                return new Customer
                {
                    Id = 1,
                    Name = "selimtest",
                    LastName="erdinctest"
                };
             }
    }
    }


