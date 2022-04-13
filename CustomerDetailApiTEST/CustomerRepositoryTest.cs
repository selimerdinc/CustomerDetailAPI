using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomerDetailApiTEST
{
    [TestClass]
    public class CustomerRepositoryTest
    {
        public readonly ICustomerRepository MockUserRepository;

        public CustomerRepositoryTest()
        {
            // Test metotları genelinde kullanacağımız User listesi
            var userList = new List<Customer>
            {
                new Customer {Id=1,Name="User1",LastName="User1LastName" },
                new Customer {Id=2,Name="User2",LastName="User2LastName" },
                new Customer {Id=3,Name="User3",LastName="User3LastName" }
            };

            // Mock the Products Repository using Moq
            var mockUserRepository = new Mock<ICustomerRepository>();

            // GetAll metodu için setup işlemi
            mockUserRepository.Setup(mr => mr.GetAll()).Returns(userList);

            // GetById metodu için setup işlemi
            mockUserRepository.Setup(mr => mr.GetById(It.IsAny<int>())).Returns((int i) => userList.Single(x => x.Id == i));

            // Insert için setup işlemi
            mockUserRepository.Setup(mr => mr.AddCustomer(It.IsAny<Customer>())).Callback(
                (Customer target) =>
                {
                    userList.Add(target);
                });

            // Update için setup işlemi
            mockUserRepository.Setup(mr => mr.UpdateCustomer(It.IsAny<Customer>())).Callback(
                (Customer target) =>
                {
                    var original = userList.Where(q => q.Id == target.Id).Single();

                    if (original == null)
                    {
                        throw new InvalidOperationException();
                    }

                    original.Name = target.Name;
                    original.LastName = target.LastName;

                });

            // Test metotlarından erişilebilmesi için global olarak tanımladığımız MockUserRepository'e yukarıdaki setup işlemlerini atıyoruz
            this.MockUserRepository = mockUserRepository.Object;
        }


        [TestMethod]
        public void GetAll_Than_Check_Count_Test()
        {
            var expected = this.MockUserRepository.GetAll().Count;

            Assert.IsNotNull(expected);// Test not null
            Assert.IsTrue(expected > 0);// Test GetAll returns user objects
        }
        [TestMethod]
        public void GetById_Than_Check_Correct_Object_Test()
        {
            var actual = new Customer { Id = 2, Name = "User2", LastName = "User2LastName" };

            var expected = this.MockUserRepository.GetById(2);

            Assert.IsNotNull(expected); // Test is not null
            Assert.IsInstanceOfType(expected, typeof(Customer)); // Test type
            Assert.AreEqual(actual.Id, expected.Id); // test correct object found
        }
        [TestMethod]
        public void Insert_User_Than_Check_GetAll_Count_Test()
        {
            var actual = this.MockUserRepository.GetAll().Count + 1;

            var user = new Customer { Id = 4, Name = "User4", LastName = "User4LastName" };

            this.MockUserRepository.AddCustomer(user);

            var expected = this.MockUserRepository.GetAll().Count;

            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]//Eğer beklediğimiz bir exception var ise bu şekilde tanımlayabiliriz
        public void GetyId_With_Undefined_Id_Than_Exception_Occurred_Test()
        {
            var expected = this.MockUserRepository.GetById(It.IsAny<int>());
        }

        [TestMethod]
        public void Update_User_Than_Check_It_Is_Updated_Test()
        {
            var actual = new Customer { Id = 2, Name = "User2_Updated", LastName = "User2LastName_Updated" };

            this.MockUserRepository.UpdateCustomer(actual);

            var expected = this.MockUserRepository.GetById(actual.Id);

            Assert.IsNotNull(expected);
            Assert.AreEqual(actual.Name, expected.Name);
            Assert.AreEqual(actual.LastName, expected.LastName);
        }


    }
}