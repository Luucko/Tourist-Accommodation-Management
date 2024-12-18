using TouristAccommodationManagement.Exceptions;
using TouristAccommodationManagement.Models;

namespace TouristAccommodationManagement.Data;

/// <summary>
    /// Provides methods to manage customers.
    /// </summary>
    public class Customers
    {
        private static List<Customer> CustomersList = new List<Customer>(); // Save to file when needed

        /// <summary>
        /// Retrieves a customer by their ID.
        /// </summary>
        /// <param name="id">The ID of the customer.</param>
        /// <returns>The customer if found, otherwise null.</returns>
        /// <exception cref="CustomerNotFoundException">Thrown when no customer is found for the given ID.</exception>
        public static Customer GetCustomer(int id)
        {
            var customer = CustomersList.Find(c => c.GetId == id);
            if (customer == null)
            {
                throw new CustomerNotFoundException($"Customer with ID {id} not found.");
            }
            return customer;
        }

        /// <summary>
        /// Adds a new customer to the list.
        /// </summary>
        /// <param name="customer">The customer to add.</param>
        /// <returns>True if the customer was successfully added; otherwise, false.</returns>
        /// <exception cref="CustomerAlreadyExistsException">Thrown when a customer with the same ID already exists.</exception>
        public static bool AddCustomer(Customer customer)
        {
            if (CustomersList.Any(c => c.GetId == customer.GetId))
            {
                throw new CustomerAlreadyExistsException($"Customer with ID {customer.GetId} already exists.");
            }

            CustomersList.Add(customer);
            return true;
        }

        /// <summary>
        /// Removes a customer from the list by their ID.
        /// </summary>
        /// <param name="id">The ID of the customer to remove.</param>
        /// <returns>True if the customer was successfully removed; otherwise, false.</returns>
        /// <exception cref="CustomerNotFoundException">Thrown when no customer is found for the given ID.</exception>
        public static bool RemoveCustomer(int id)
        {
            var customer = CustomersList.Find(c => c.GetId == id);
            if (customer == null)
            {
                throw new CustomerNotFoundException($"Customer with ID {id} not found.");
            }

            CustomersList.Remove(customer);
            return true;
        }

        /// <summary>
        /// Gets the next available customer ID.
        /// </summary>
        /// <returns>The next available ID.</returns>
        public static int GetNextId()
        {
            return CustomersList.Count + 1;
        }

        /// <summary>
        /// Retrieves all customers in the list.
        /// </summary>
        /// <returns>A list of all customers.</returns>
        public static List<Customer> GetAllCustomers()
        {
            return CustomersList;
        }

        /// <summary>
        /// Clears all customers from the list.
        /// </summary>
        /// <returns>True if the list was cleared successfully.</returns>
        public static bool ClearCustomers()
        {
            CustomersList.Clear();
            return true;
        }
    }