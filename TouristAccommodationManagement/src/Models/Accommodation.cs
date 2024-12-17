using System;
using TouristAccommodationManagement.Services;

namespace TouristAccommodationManagement.Models
{
    [Serializable]
    public class Accommodation
    {
        private int Id;
        private string Name;
        private string Type;
        private double PricePerNight;
        [NonSerialized] private bool IsAvailable;

        public Accommodation(int id, string name, string type, double pricePerNight)
        {
            Id = id;
            Name = name;
            Type = type;
            PricePerNight = pricePerNight;
            IsAvailable = true;
        }

        public int GetId => Id;
        public string GetName => Name;
        public string GetType => Type;
        public bool GetIsAvailable => IsAvailable;

        public void UpdateStatus(bool isAvailable)
        {
            IsAvailable = isAvailable;
            AccommodationRules.UpdateAccommodation(this);
        }

        public override string ToString()
        {
            return $"Accommodation ID: {Id}\n " +
                   $"Name: {Name}\n " +
                   $"Type: {Type}\n " +
                   $"Price per Night: {PricePerNight} EUR\n " +
                   $"Available: {IsAvailable}";
        }
    }
}