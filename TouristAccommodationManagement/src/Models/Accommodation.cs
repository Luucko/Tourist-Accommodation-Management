namespace TouristAccommodationManagement.Models
{
    /// <summary>
    /// Represents an accommodation entity with properties such as ID, name, type, and price per night.
    /// </summary>
    public class Accommodation
    {
        private int Id;
        private string Name;
        private string Type;
        private double PricePerNight;

        /// <summary>
        /// Initializes a new instance of the <see cref="Accommodation"/> class.
        /// </summary>
        /// <param name="id">The ID of the accommodation.</param>
        /// <param name="name">The name of the accommodation.</param>
        /// <param name="type">The type of the accommodation.</param>
        /// <param name="pricePerNight">The price per night for the accommodation.</param>
        public Accommodation(int id, string name, string type, double pricePerNight)
        {
            Id = id;
            Name = name;
            Type = type;
            PricePerNight = pricePerNight;
        }

        /// <summary>
        /// Gets the ID of the accommodation.
        /// </summary>
        public int GetId => Id;

        /// <summary>
        /// Gets the name of the accommodation.
        /// </summary>
        public string GetName => Name;

        /// <summary>
        /// Gets the type of the accommodation.
        /// </summary>
        public string GetType => Type;

        /// <summary>
        /// Gets the price per night of the accommodation.
        /// </summary>
        public double GetPricePerNight => PricePerNight;

        /// <summary>
        /// Returns a string representation of the accommodation.
        /// </summary>
        /// <returns>A string that describes the accommodation with its details.</returns>
        public override string ToString()
        {
            return $"Accommodation ID: {Id}\n " +
                   $"Name: {Name}\n " +
                   $"Type: {Type}\n " +
                   $"Price per Night: {PricePerNight} EUR\n ";
        }
    }
}