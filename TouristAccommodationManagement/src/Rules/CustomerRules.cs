using TouristAccommodationManagement.Data;

namespace TouristAccommodationManagement.Models;

public class CustomerRules
{
    public static void AddCustomer(Customer customer)
    {
        Customers.AddCustomer(customer);
    }
    
    public Customer GetCustomer(int id)
    {
        return Customers.GetCustomer(id);
    }
    
    public void RemoveCustomer(int id)
    {
        Customers.RemoveCustomer(id);
    }
    
    public static int GetNextId()
    {
        return Customers.GetNextId();
    }

    public List<Customer> GetAllCustomers()
    {
        return Customers.GetAllCustomers();
    }
    
}