using TouristAccommodationManagement.Data;
using TouristAccommodationManagement.Models;

namespace TouristAccommodationManagement.Services
{
    public class CustomerRules
    {
        public static bool AddCustomer(Customer customer)
        {
            if (Customers.GetCustomer(customer.GetId) != null)
            {
                return false;
            }

            Customers.AddCustomer(customer);
            return true;
        }

        public static Customer GetCustomer(int id)
        {
            return Customers.GetCustomer(id);
        }

        public static bool RemoveCustomer(int id)
        {
            var customer = Customers.GetCustomer(id);
            if (customer == null)
            {
                return false;
            }

            Customers.RemoveCustomer(id);
            return true;
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