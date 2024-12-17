namespace TouristAccommodationManagement.Models
{
    public class Customer
    {
        private int Id;
        private string Name;
        private string ContactInfo;
        private string Email;
        
        public Customer(int id, string name, string email, string contactInfo = null)
        {
            Id = id;
            Name = name;
            Email = email;
            ContactInfo = contactInfo;
        }
        
        public int GetId => Id;
        public string GetName => Name;
        public string GetEmail => Email;
        public string GetContactInfo => ContactInfo;

        public override string ToString()
        {
            return $"Customer ID: {Id}\n " +
                   $"Name: {Name}\n " +
                   $"Email: {Email}\n " +
                   $"Contact Info: {ContactInfo}";
        }
    }
}