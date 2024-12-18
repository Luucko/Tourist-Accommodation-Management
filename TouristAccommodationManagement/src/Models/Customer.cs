namespace TouristAccommodationManagement.Models
{
    /// <summary>
    /// Represents a customer with properties such as ID, name, email, and optional contact info.
    /// </summary>
    public class Customer
    {
        private int Id;
        private string Name;
        private string ContactInfo;
        private string Email;

        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class.
        /// </summary>
        /// <param name="id">The ID of the customer.</param>
        /// <param name="name">The name of the customer.</param>
        /// <param name="email">The email of the customer.</param>
        /// <param name="contactInfo">Optional contact information of the customer.</param>
        public Customer(int id, string name, string email, string contactInfo = null)
        {
            if (!IsValidEmail(email))
            {
                throw new ArgumentException("Invalid email format.", nameof(email));
            }
            
            Id = id;
            Name = name;
            Email = email;
            ContactInfo = contactInfo;
        }

        /// <summary>
        /// Gets the ID of the customer.
        /// </summary>
        public int GetId => Id;

        /// <summary>
        /// Gets the name of the customer.
        /// </summary>
        public string GetName => Name;

        /// <summary>
        /// Gets the email of the customer.
        /// </summary>
        public string GetEmail => Email;

        /// <summary>
        /// Gets the contact information of the customer.
        /// </summary>
        public string GetContactInfo => ContactInfo;

        /// <summary>
        /// Returns a string representation of the customer, including all their details.
        /// </summary>
        /// <returns>A string that describes the customer with their ID, name, email, and contact info.</returns>
        public override string ToString()
        {
            return $"Customer ID: {Id}\n " +
                   $"Name: {Name}\n " +
                   $"Email: {Email}\n " +
                   $"Contact Info: {ContactInfo}";
        }

        /// <summary>
        /// Validates the email format.
        /// </summary>
        /// <param name="email">The email to be validated.</param>
        /// <returns><c>true</c> if the email is valid, otherwise <c>false</c>.</returns>
        private bool IsValidEmail(string email)
        {
            // Basic regex for simple email validation (just for illustration)
            return System.Text.RegularExpressions.Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
    }
}