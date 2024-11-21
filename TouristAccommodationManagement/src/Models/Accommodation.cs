using TouristAccommodationManagement.Services;

namespace TouristAccommodationManagement.Models
{
    public class Accommodation
    {
        public int ID { get; set; }  
        public string Name { get; set; } 
        public string Type { get; set; }  
        public double PricePerNight { get; set; } 
        public bool IsAvailable { get; set; }


        public Accommodation(int id, string name, string type, double pricePerNight)
        {
            ID = id;
            Name = name;
            Type = type;
            PricePerNight = pricePerNight;
            IsAvailable = true;
        }
        
        public void UpdateStatus(bool isAvailable)
        {
            IsAvailable = isAvailable;
            AccommodationRules.UpdateAccommodation(this);
        }

        public override string ToString()
        {
            return $"Accommodation ID: {ID}\n " +
                   $"Name: {Name}\n " +
                   $"Type: {Type}\n " +
                   $"Price per Night: {PricePerNight} EUR\n " +
                   $"Available: {IsAvailable}";
        }
    }
}