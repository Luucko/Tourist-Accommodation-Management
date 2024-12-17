using System;
using TouristAccommodationManagement.Models;

namespace TouristAccommodationManagement.Models
{
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

        public Reservation(int id, Customer customer, Accommodation accommodation, DateTime checkInDate, DateTime checkOutDate)
        {
            Id = id;
            Customer = customer;
            Accommodation = accommodation;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            Status = ReservationStatus.Booked;
            CalculateTotalPrice();
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
        }
        
        private double CalculateTotalPrice()
        {
            int totalNights = (CheckOutDate - CheckInDate).Days;
            TotalPrice = totalNights * Accommodation.GetPricePerNight;
            return TotalPrice;
        }

        public override string ToString()
        {
            return $"Reservation ID: {Id}\n" +
                   $"Customer: {Customer.GetName}\n" +
                   $"Accommodation: {Accommodation.GetName}\n" +
                   $"Check-In: {CheckInDate.ToShortDateString()}\n" +
                   $"Check-Out: {CheckOutDate.ToShortDateString()}\n" +
                   $"Price per night: {Accommodation.GetPricePerNight} EUR\n" +
                   $"Total Nights: {(CheckOutDate - CheckInDate).Days}\n" +
                   $"Total Price: {TotalPrice} EUR\n" +
                   $"Status: {Status}";
        }
    }
}
