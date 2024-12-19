using JetBrains.Annotations;
using TouristAccommodationManagement.Data;
using TouristAccommodationManagement.Exceptions;
using TouristAccommodationManagement.Models;
using TouristAccommodationManagement.Services;
using Xunit;

namespace TouristAccommodationManagement.Tests.Data;

[TestSubject(typeof(Customers))]
    public class CustomersTest
    {
        private Customer _customer;

        public CustomersTest()
        {
            // Clear customers before each test
            Customers.ClearCustomers();
            
            // Common setup
            var id = Customers.GetNextId();
            _customer = new Customer(id, "Jane Doe", "jane.doe@email.com", "555-6789");
            Customers.AddCustomer(_customer);
        }

        [Fact]
        public void AddCustomer_ShouldAddCustomer()
        {
            // Arrange
            var newId = Customers.GetNextId();
            var newCustomerJohn = new Customer(newId, "John Smith", "john.smith@email.com", "555-1234");

            // Act
            Customers.AddCustomer(newCustomerJohn);

            // Assert
            Assert.Contains(newCustomerJohn, Customers.GetAllCustomers());
        }

        [Fact]
        public void AddCustomer_ShouldThrowCustomerAlreadyExistsException_WhenCustomerAlreadyExists()
        {
            // Arrange
            var duplicateCustomer = new Customer(_customer.GetId, "Jane Doe", "jane.doe@email.com", "555-6789");

            // Act & Assert
            var exception = Assert.Throws<CustomerAlreadyExistsException>(() =>
                Customers.AddCustomer(duplicateCustomer));
            Assert.Equal($"Customer with ID {_customer.GetId} already exists.", exception.Message);
        }

        [Fact]
        public void GetCustomer_ShouldReturnCorrectCustomer()
        {
            // Act
            var result = CustomerService.GetCustomer(_customer.GetId);

            // Assert
            Assert.Equal(_customer, result);
        }

        [Fact]
        public void GetCustomer_ShouldThrowCustomerNotFoundException_WhenCustomerNotFound()
        {
            // Act & Assert
            var exception = Assert.Throws<CustomerNotFoundException>(() =>
                Customers.GetCustomer(999));  // ID that doesn't exist
            Assert.Equal("Customer with ID 999 not found.", exception.Message);
        }

        [Fact]
        public void RemoveCustomer_ShouldRemoveCorrectCustomer()
        {
            // Act
            Customers.RemoveCustomer(_customer.GetId);

            // Assert
            Assert.DoesNotContain(_customer, Customers.GetAllCustomers());
        }

        [Fact]
        public void RemoveCustomer_ShouldThrowCustomerNotFoundException_WhenCustomerToRemoveNotFound()
        {
            // Act & Assert
            var exception = Assert.Throws<CustomerNotFoundException>(() =>
                Customers.RemoveCustomer(999));  // ID that doesn't exist
            Assert.Equal("Customer with ID 999 not found.", exception.Message);
        }

        [Fact]
        public void GetAllCustomers_ShouldReturnAllCustomers()
        {
            // Arrange
            var newId = Customers.GetNextId();
            var newCustomer = new Customer(newId, "John Smith", "john.smith@email.com", "555-1234");
            Customers.AddCustomer(newCustomer);

            // Act
            var allCustomers = Customers.GetAllCustomers();

            // Assert
            Assert.Contains(_customer, allCustomers);
            Assert.Contains(newCustomer, allCustomers);
        }

        [Fact]
        public void GetNextId_ShouldReturnCorrectId()
        {
            // Arrange
            var currentCount = Customers.GetAllCustomers().Count;

            // Act
            var nextId = Customers.GetNextId();

            // Assert
            Assert.Equal(currentCount + 1, nextId);
        }
    }