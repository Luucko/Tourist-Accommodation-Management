using TouristAccommodationManagement.Exceptions;
using TouristAccommodationManagement.Models;

namespace TouristAccommodationManagement.Data;

/// <summary>
    /// Provides methods to manage accommodations.
    /// </summary>
    public class Accommodations
    {
        private static List<Accommodation> AccommodationsList = new List<Accommodation>(); // Save to file when needed

        /// <summary>
        /// Retrieves an accommodation by its ID.
        /// </summary>
        /// <param name="id">The ID of the accommodation.</param>
        /// <returns>The accommodation if found, otherwise null.</returns>
        /// <exception cref="AccommodationNotFoundException">Thrown when no accommodation is found for the given ID.</exception>
        public static Accommodation GetAccommodation(int id)
        {
            var accommodation = AccommodationsList.Find(a => a.GetId == id);
            if (accommodation == null)
            {
                throw new AccommodationNotFoundException($"Accommodation with ID {id} not found.");
            }
            return accommodation;
        }

        /// <summary>
        /// Adds a new accommodation to the list.
        /// </summary>
        /// <param name="accommodation">The accommodation to add.</param>
        /// <returns>True if the accommodation was successfully added; otherwise, false.</returns>
        /// <exception cref="AccommodationAlreadyExistsException">Thrown when an accommodation with the same ID already exists.</exception>
        public static bool AddAccommodation(Accommodation accommodation)
        {
            if (AccommodationsList.Any(a => a.GetId == accommodation.GetId))
            {
                throw new AccommodationAlreadyExistsException($"Accommodation with ID {accommodation.GetId} already exists.");
            }

            AccommodationsList.Add(accommodation);
            return true;
        }


        /// <summary>
        /// Removes an accommodation from the list by its ID.
        /// </summary>
        /// <param name="id">The ID of the accommodation to remove.</param>
        /// <returns>True if the accommodation was successfully removed; otherwise, false.</returns>
        /// <exception cref="AccommodationNotFoundException">Thrown when no accommodation is found for the given ID.</exception>
        public static bool RemoveAccommodation(int id)
        {
            var accommodation = AccommodationsList.Find(a => a.GetId == id);
            if (accommodation == null)
            {
                throw new AccommodationNotFoundException($"Accommodation with ID {id} not found.");
            }

            AccommodationsList.Remove(accommodation);
            return true;
        }

        /// <summary>
        /// Gets the next available accommodation ID.
        /// </summary>
        /// <returns>The next available ID.</returns>
        public static int GetNextId()
        {
            return AccommodationsList.Count + 1;
        }

        /// <summary>
        /// Retrieves all accommodations in the list.
        /// </summary>
        /// <returns>A list of all accommodations.</returns>
        public static List<Accommodation> GetAllAccommodations()
        {
            return AccommodationsList;
        }

        /// <summary>
        /// Clears all accommodations from the list.
        /// </summary>
        /// <returns>True if the list was cleared successfully.</returns>
        public static bool ClearAccommodations()
        {
            AccommodationsList.Clear();
            return true;
        }
    }