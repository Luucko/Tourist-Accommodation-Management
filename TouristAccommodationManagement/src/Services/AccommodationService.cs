using TouristAccommodationManagement.Data;
using TouristAccommodationManagement.Exceptions;
using TouristAccommodationManagement.Models;

namespace TouristAccommodationManagement.Services
{
    /// <summary>
    /// Provides services for managing accommodations.
    /// </summary>
    public class AccommodationService
    {
        /// <summary>
        /// Adds a new accommodation to the system.
        /// </summary>
        /// <param name="accommodation">The accommodation to add.</param>
        /// <returns>True if the accommodation is successfully added, false otherwise.</returns>
        /// <exception cref="DuplicateAccommodationException">Thrown when an accommodation with the same ID already exists.</exception>
        public static bool AddAccommodation(Accommodation accommodation)
        {
            if (Accommodations.GetAccommodation(accommodation.GetId) != null)
            {
                throw new DuplicateAccommodationException($"An accommodation with ID {accommodation.GetId} already exists.");
            }

            Accommodations.AddAccommodation(accommodation);
            return true;
        }

        /// <summary>
        /// Retrieves an accommodation by ID.
        /// </summary>
        /// <param name="id">The ID of the accommodation.</param>
        /// <returns>The accommodation if found.</returns>
        /// <exception cref="AccommodationNotFoundException">Thrown when no accommodation is found for the given ID.</exception>
        public static Accommodation GetAccommodation(int id)
        {
            var accommodation = Accommodations.GetAccommodation(id);
            if (accommodation == null)
            {
                throw new AccommodationNotFoundException($"Accommodation with ID {id} not found.");
            }

            return accommodation;
        }

        /// <summary>
        /// Removes an accommodation by ID.
        /// </summary>
        /// <param name="id">The ID of the accommodation to remove.</param>
        /// <returns>True if the accommodation was removed successfully.</returns>
        /// <exception cref="AccommodationNotFoundException">Thrown when no accommodation is found for the given ID.</exception>
        public static bool RemoveAccommodation(int id)
        {
            var accommodation = Accommodations.GetAccommodation(id);
            if (accommodation == null)
            {
                throw new AccommodationNotFoundException($"Accommodation with ID {id} not found.");
            }

            Accommodations.RemoveAccommodation(id);
            return true;
        }

        /// <summary>
        /// Gets the next available accommodation ID.
        /// </summary>
        /// <returns>The next available ID.</returns>
        public static int GetNextId()
        {
            return Accommodations.GetNextId();
        }

        /// <summary>
        /// Retrieves all accommodations in the system.
        /// </summary>
        /// <returns>A list of all accommodations.</returns>
        public static List<Accommodation> GetAllAccommodations()
        {
            return Accommodations.GetAllAccommodations();
        }

        /// <summary>
        /// Updates an existing accommodation.
        /// </summary>
        /// <param name="accommodation">The accommodation with updated details.</param>
        /// <returns>True if the update is successful.</returns>
        /// <exception cref="AccommodationNotFoundException">Thrown when no accommodation is found for the given ID.</exception>
        public static bool UpdateAccommodation(Accommodation accommodation)
        {
            var existingAccommodation = Accommodations.GetAccommodation(accommodation.GetId);
            if (existingAccommodation == null)
            {
                throw new AccommodationNotFoundException($"Accommodation with ID {accommodation.GetId} not found.");
            }

            Accommodations.RemoveAccommodation(accommodation.GetId);
            Accommodations.AddAccommodation(accommodation);
            return true;
        }
    }
}