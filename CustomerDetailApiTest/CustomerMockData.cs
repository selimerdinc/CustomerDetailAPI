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
                Id = 1,
                Name = "selimselim",
                LastName = "deneme123"
            };
        }


            // existing code hidden for display purpose
            public static Customer NewCustomer()
            {
                return new Customer
                {
                    Id = 0,
                    Name = "erdincerdinc",
                    LastName = "melikoğlu"
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


