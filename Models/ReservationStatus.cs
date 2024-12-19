namespace TouristAccommodationManagement.Models
{
    /// <summary>
    /// Represents the status of a reservation.
    /// </summary>
    public enum ReservationStatus
    {
        /// <summary>
        /// The reservation has been booked but the customer has not yet checked in.
        /// </summary>
        Booked,

        /// <summary>
        /// The customer has checked into the accommodation.
        /// </summary>
        CheckedIn,

        /// <summary>
        /// The customer has checked out of the accommodation.
        /// </summary>
        CheckedOut,

        /// <summary>
        /// The reservation has been cancelled, and the accommodation is no longer booked.
        /// </summary>
        Cancelled
    }
}