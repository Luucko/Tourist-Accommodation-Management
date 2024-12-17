using TouristAccommodationManagement.Models;

namespace TouristAccommodationManagement.Data;

public class Customers
{
    private static List<Customer> CustomersList = new List<Customer>();
    
    public static Customer GetCustomer(int id)
    {
        return CustomersList.Find(c => c.GetId == id);
    }
    
    public static void AddCustomer(Customer customer)
    {
        CustomersList.Add(customer);
    }
    
    public static void RemoveCustomer(int id)
    {
        CustomersList.RemoveAll(c => c.GetId == id);
    }
    
    public static int GetNextId()
    {
        return CustomersList.Count + 1;
    }
    
    public static List<Customer> GetAllCustomers()
    {
        return CustomersList;
    }
    
    public static void ClearCustomers()
    {
        CustomersList.Clear();
    }
}