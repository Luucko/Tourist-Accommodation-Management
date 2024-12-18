using TouristAccommodationManagement.Services;

namespace TouristAccommodationManagement.Models
{
    /// <summary>
    /// Represents a reservation made by a customer for an accommodation, including customer details, accommodation details,
    /// check-in and check-out dates, and the reservation status.
    /// </summary>
    [Serializable]
    public class Reservation
    {
        private int Id;
        private Customer Customer;
        private Accommodation Accommodation;
        private DateTime CheckInDate;
        private DateTime CheckOutDate;
        private ReservationStatus Status;
        [NonSerialized] private double TotalPrice;

        /// <summary>
        /// Initializes a new instance of the <see cref="Reservation"/> class.
        /// </summary>
        /// <param name="id">The ID of the reservation.</param>
        /// <param name="customer">The customer making the reservation.</param>
        /// <param name="accommodation">The accommodation being reserved.</param>
        /// <param name="checkInDate">The check-in date for the reservation.</param>
        /// <param name="checkOutDate">The check-out date for the reservation.</param>
        public Reservation(int id, Customer customer, Accommodation accommodation, DateTime checkInDate, DateTime checkOutDate)
        {
            if (checkOutDate <= checkInDate)
            {
                throw new ArgumentException("Check-out date must be later than check-in date.");
            }

            Id = id;
            Customer = customer;
            Accommodation = accommodation;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            Status = ReservationStatus.Booked;
        }

        /// <summary>
        /// Gets the ID of the reservation.
        /// </summary>
        public int GetId => Id;

        /// <summary>
        /// Gets the customer associated with the reservation.
        /// </summary>
        public Customer GetCustomer => Customer;

        /// <summary>
        /// Gets the accommodation associated with the reservation.
        /// </summary>
        public Accommodation GetAccommodation => Accommodation;

        /// <summary>
        /// Gets the check-in date for the reservation.
        /// </summary>
        public DateTime GetCheckInDate => CheckInDate;

        /// <summary>
        /// Gets the check-out date for the reservation.
        /// </summary>
        public DateTime GetCheckOutDate => CheckOutDate;

        /// <summary>
        /// Gets the status of the reservation.
        /// </summary>
        public ReservationStatus GetStatus => Status;

        /// <summary>
        /// Updates the status of the reservation.
        /// </summary>
        /// <param name="status">The new status to set for the reservation.</param>
        /// <returns><c>true</c> if the status was updated successfully, otherwise <c>false</c> if the status was the same.</returns>
        public bool UpdateStatus(ReservationStatus status)
        {
            if (Status == status)
            {
                return false; // No update needed, status is the same
            }

            Status = status;
            return true;
        }

        /// <summary>
        /// Gets the total price of the reservation based on the accommodation and stay duration.
        /// </summary>
        public double GetTotalPrice => ReservationService.CalculateTotalPrice(this);

        /// <summary>
        /// Returns a string representation of the reservation, including details like ID, customer, accommodation, dates, and status.
        /// </summary>
        /// <returns>A string containing the reservation's details.</returns>
        public override string ToString()
        {
            return $"Reservation ID: {Id}\n" +
                   $"Customer: {Customer.GetName}\n" +
                   $"Accommodation: {Accommodation.GetName}\n" +
                   $"Check-In: {CheckInDate.ToShortDateString()}\n" +
                   $"Check-Out: {CheckOutDate.ToShortDateString()}\n" +
                   $"Total Price: {GetTotalPrice} EUR\n" +
                   $"Status: {Status}";
        }
    }
}