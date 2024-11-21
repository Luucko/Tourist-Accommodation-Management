namespace TouristAccommodationManagement.Models
{
    public class Customer
    {
        public int ID { get; set; } 
        public string Name { get; set; } 
        public string ContactInfo { get; set; } 
        public string Email { get; set; }  

        
        public Customer(int id, string name, string email, string contactInfo = null)
        {
            ID = id;
            Name = name;
            Email = email;
            ContactInfo = contactInfo;
        }

        public override string ToString()
        {
            return $"Customer ID: {ID}\n " +
                   $"Name: {Name}\n " +
                   $"Email: {Email}\n " +
                   $"Contact Info: {ContactInfo}";
        }
    }
}