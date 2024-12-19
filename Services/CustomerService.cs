using TouristAccommodationManagement.Data;
using TouristAccommodationManagement.Exceptions;
using TouristAccommodationManagement.Models;

namespace TouristAccommodationManagement.Services
{
    /// <summary>
    /// Provides services for managing customers.
    /// </summary>
    public class CustomerService
    {
        /// <summary>
        /// Adds a new customer to the system.
        /// </summary>
        /// <param name="customer">The customer to add.</param>
        /// <returns>True if the customer is successfully added.</returns>
        /// <exception cref="DuplicateCustomerException">Thrown when a customer with the same ID already exists.</exception>
        public static bool AddCustomer(Customer customer)
        {
            try
            {
                // Attempt to add the customer
                Customers.AddCustomer(customer);
                return true;
            }
            catch (CustomerAlreadyExistsException)
            {
                // Handle case where customer already exists
                throw new DuplicateCustomerException($"A customer with ID {customer.GetId} already exists.");
            }
        }

        /// <summary>
        /// Retrieves a customer by ID.
        /// </summary>
        /// <param name="id">The ID of the customer.</param>
        /// <returns>The customer if found.</returns>
        /// <exception cref="CustomerNotFoundException">Thrown when no customer is found for the given ID.</exception>
        public static Customer GetCustomer(int id)
        {
            var customer = Customers.GetCustomer(id);
            /*if (customer == null)
            {
                throw new CustomerNotFoundException($"Customer with ID {id} not found.");
            }
            */

            return customer;
        }

        /// <summary>
        /// Removes a customer by ID.
        /// </summary>
        /// <param name="id">The ID of the customer to remove.</param>
        /// <returns>True if the customer was removed successfully.</returns>
        /// <exception cref="CustomerNotFoundException">Thrown when no customer is found for the given ID.</exception>
        public static bool RemoveCustomer(int id)
        {
            var customer = Customers.GetCustomer(id);
            if (customer == null)
            {
                throw new CustomerNotFoundException($"Customer with ID {id} not found.");
            }

            Customers.RemoveCustomer(id);
            return true;
        }

        /// <summary>
        /// Gets the next available customer ID.
        /// </summary>
        /// <returns>The next available ID.</returns>
        public static int GetNextId()
        {
            return Customers.GetNextId();
        }

        /// <summary>
        /// Retrieves all customers in the system.
        /// </summary>
        /// <returns>A list of all customers.</returns>
        public static List<Customer> GetAllCustomers()
        {
            return Customers.GetAllCustomers();
        }
    }
}