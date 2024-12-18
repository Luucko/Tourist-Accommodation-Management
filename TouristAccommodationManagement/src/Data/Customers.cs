using TouristAccommodationManagement.Models;

namespace TouristAccommodationManagement.Data;

public class Customers
{
    private static List<Customer> CustomersList = new List<Customer>(); // Save to file when needed

    public static Customer GetCustomer(int id)
    {
        return CustomersList.Find(c => c.GetId == id);
    }

    public static bool AddCustomer(Customer customer)
    {
        if (CustomersList.Any(c => c.GetId == customer.GetId)) 
        {
            return false;
        }
        CustomersList.Add(customer);
        return true;
    }

    public static bool RemoveCustomer(int id)
    {
        var customer = CustomersList.Find(c => c.GetId == id);
        if (customer != null)
        {
            CustomersList.Remove(customer);
            return true; 
        }
        return false; 
    }

    public static int GetNextId()
    {
        return CustomersList.Count + 1;
    }

    public static List<Customer> GetAllCustomers()
    {
        return CustomersList;
    }

    public static bool ClearCustomers()
    {
        CustomersList.Clear();
        return true;
    }
}