using CustomerDetailAPI;
using CustomerDetailAPI.Controllers;
using CustomerDetailAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CustomerDetailApiTest
{
    public class CustomerControllerTest
    {
       

        [Fact]
        public async Task AddCustomer_ShouldCall_ICustomerRepository_AddCustomer_AtleastOnce()
        {
            /// Arrange
            var customerRepo = new Mock<ICustomerRepository>();
            var newCustomer = CustomerMockData.Three_Different_Customer();
            var sut = new CustomerController(customerRepo.Object);

            /// Act
            var result = await sut.AddCustomer(newCustomer);

            /// Assert
            customerRepo.Verify(x => x.AddCustomer(newCustomer), Times.Exactly(1));
           
        }

        [Fact]
        public async Task GetById_ShouldCall_ICustomerRepository_GetById_AtleastOnce()
        {
            /// Arrange
            var customerRepo = new Mock<ICustomerRepository>();
            var newCustomer = CustomerMockData.GetCustomer().Id;
            var sut = new CustomerController(customerRepo.Object);

            /// Act
            var result = await sut.GetById(newCustomer);

            /// Assert
            customerRepo.Verify(x => x.GetById(newCustomer), Times.Exactly(1));
        }

        [Fact]
        public async Task UpdateCustomer_ShouldCall_ICustomerRepository_UpdateCustomer_AtleastOnce()
        {
            /// Arrange
            var customerRepo = new Mock<ICustomerRepository>();
            int id = CustomerMockData.NewCustomer().Id;
            var newCustomer = CustomerMockData.Three_Different_Customer();
            var sut = new CustomerController(customerRepo.Object);
            

            /// Act
            var result = await sut.UpdateCustomer(id,newCustomer);

            /// Assert
            customerRepo.Verify(x => x.UpdateCustomer(id, newCustomer), Times.Exactly(1));
        }
        [Fact]
        public async Task DeleteCustomer_ShouldCall_ICustomerRepository_DeleteCustomer_AtleastOnce()
        {
            /// Arrange
            var customerRepo = new Mock<ICustomerRepository>();
            var newCustomer = CustomerMockData.Three_Different_Customer().Id;
            var sut = new CustomerController(customerRepo.Object);

            /// Act
            var result = await sut.DeleteCustomer(newCustomer);

            /// Assert
            customerRepo.Verify(x => x.DeleteCustomer(newCustomer), Times.Exactly(1));
        }
    }
}


    

