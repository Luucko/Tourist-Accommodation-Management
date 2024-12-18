using TouristAccommodationManagement.Data;
using TouristAccommodationManagement.Models;

namespace TouristAccommodationManagement.Services
{
    public class CustomerRules
    {
        public static void AddCustomer(Customer customer)
        {
            Customers.AddCustomer(customer);
        }

        public static Customer GetCustomer(int id)
        {
            return Customers.GetCustomer(id);
        }

        public static void RemoveCustomer(int id)
        {
            Customers.RemoveCustomer(id);
        }

        public static int GetNextId()
        {
            return Customers.GetNextId();
        }

        public static List<Customer> GetAllCustomers()
        {
            return Customers.GetAllCustomers();
        }
    }
}