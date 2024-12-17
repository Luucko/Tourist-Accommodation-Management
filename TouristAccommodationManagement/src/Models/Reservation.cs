using TouristAccommodationManagement.Data;
using TouristAccommodationManagement.Models;
using TouristAccommodationManagement.Services;

namespace TouristAccommodationManagement.Models
{ //make serializable if needed if there's calculated properties
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
            Id = id;
            Customer = customer;
            Accommodation = accommodation;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            Status = ReservationStatus.Booked; // Default status
        }
        
        public int GetId => Id;
        public Customer GetCustomer => Customer;
        public Accommodation GetAccommodation => Accommodation;
        public DateTime GetCheckInDate => CheckInDate;
        public DateTime GetCheckOutDate => CheckOutDate;
        public ReservationStatus GetStatus => Status;
        
        public void UpdateStatus(ReservationStatus status)
        {
            Status = status;
            ReservationRules.UpdateReservation(this);
        }
        
        public override bool Equals(object obj)
        {
            if (obj is not Reservation other) return false;

            return Accommodation.GetId == other.Accommodation.GetId && // Find same accommodation
                   CheckInDate < other.CheckOutDate &&           // Overlapping dates
                   CheckOutDate > other.CheckInDate;             // Overlapping dates
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Accommodation.GetId, CheckInDate, CheckOutDate);
        }
        
        public override string ToString()
        {
            return $"Reservation ID: {Id}\n " +
                   $"Customer: {Customer.GetName} ({Customer.GetEmail})\n " +
                   $"Accommodation: {Accommodation.GetName} ({Accommodation.GetType})\n " +
                   $"Check-in: {CheckInDate.ToShortDateString()}\n " +
                   $"Check-out: {CheckOutDate.ToShortDateString()}\n " +
                   $"Status: {Status}";
        }
    }
}