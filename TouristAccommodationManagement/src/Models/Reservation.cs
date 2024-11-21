using TouristAccommodationManagement.Data;
using TouristAccommodationManagement.Models;
using TouristAccommodationManagement.Services;

namespace TouristAccommodationManagement.Models
{
    public class Reservation {
        
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public Accommodation Accommodation { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public ReservationStatus Status { get; set; }
        
        public Reservation(int id, Customer customer, Accommodation accommodation, DateTime checkInDate, DateTime checkOutDate)
        {
            Id = id;
            Customer = customer;
            Accommodation = accommodation;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            Status = ReservationStatus.Booked; // Later create ENUM for this, three statuses: Booked, CheckedIn, CheckedOut, Cancelled
        }
        
        public void UpdateStatus(ReservationStatus status)
        {
            Status = status;
            ReservationRules.UpdateReservation(this);
        }
        
        public override bool Equals(object obj)
        {
            if (obj is not Reservation other) return false;

            return Accommodation.ID == other.Accommodation.ID && // Find same accommodation
                   CheckInDate < other.CheckOutDate &&           // Overlapping dates
                   CheckOutDate > other.CheckInDate;             // Overlapping dates
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Accommodation.ID, CheckInDate, CheckOutDate);
        }
        
        public override string ToString()
        {
            return $"Reservation ID: {Id}\n " +
                   $"Customer: {Customer.Name} ({Customer.Email})\n " +
                   $"Accommodation: {Accommodation.Name} ({Accommodation.Type})\n " +
                   $"Check-in: {CheckInDate.ToShortDateString()}\n " +
                   $"Check-out: {CheckOutDate.ToShortDateString()}\n " +
                   $"Status: {Status}";
        }
    }
}