using System;
using TouristAccommodationManagement.Services;

namespace TouristAccommodationManagement.Models
{
    public class Accommodation
    {
        private int Id;
        private string Name;
        private string Type;
        private double PricePerNight;

        public Accommodation(int id, string name, string type, double pricePerNight)
        {
            Id = id;
            Name = name;
            Type = type;
            PricePerNight = pricePerNight;
        }

        public int GetId => Id;
        public string GetName => Name;
        public string GetType => Type;
        public double GetPricePerNight => PricePerNight;

        public override string ToString()
        {
            return $"Accommodation ID: {Id}\n " +
                   $"Name: {Name}\n " +
                   $"Type: {Type}\n " +
                   $"Price per Night: {PricePerNight} EUR\n ";
        }
    }
}