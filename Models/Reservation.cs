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

        public int GetId => Id;
        public Customer GetCustomer => Customer;
        public Accommodation GetAccommodation => Accommodation;
        public DateTime GetCheckInDate => CheckInDate;
        public DateTime GetCheckOutDate => CheckOutDate;
        public ReservationStatus GetStatus => Status;

        public bool UpdateStatus(ReservationStatus status)
        {
            if (Status == status)
            {
                return false;
            }

            Status = status;
            return true;
        }

        public override string ToString()
        {
            return $"Reservation ID: {Id}\n" +
                   $"Customer: {Customer.GetName}\n" +
                   $"Accommodation: {Accommodation.GetName}\n" +
                   $"Check-In: {CheckInDate.ToShortDateString()}\n" +
                   $"Check-Out: {CheckOutDate.ToShortDateString()}\n" +
                   $"Status: {Status}";
        }
    }
}