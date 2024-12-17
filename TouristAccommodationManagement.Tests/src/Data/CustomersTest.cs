using JetBrains.Annotations;
using TouristAccommodationManagement.Data;
using TouristAccommodationManagement.Models;
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
    public void AddCustomer()
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
    public void GetCustomer()
    {
        // Act
        var result = Customers.GetCustomer(_customer.GetId);

        // Assert
        Assert.Equal(_customer, result);
    }

    [Fact]
    public void RemoveCustomer()
    {
        // Act
        Customers.RemoveCustomer(_customer.GetId);

        // Assert
        Assert.DoesNotContain(_customer, Customers.GetAllCustomers());
    }

    [Fact]
    public void GetAllCustomers()
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
    public void GetNextId()
    {
        // Arrange
        var currentCount = Customers.GetAllCustomers().Count;

        // Act
        var nextId = Customers.GetNextId();

        // Assert
        Assert.Equal(currentCount + 1, nextId);
    }
}