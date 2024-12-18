using System;
using TouristAccommodationManagement.Models;
using TouristAccommodationManagement.Data;
using TouristAccommodationManagement.Services;

namespace TouristAccommodationManagement
{
    class Program
    {
        public static void Main(string[] args)
        {
            Reservations.ClearReservations();
            Accommodations.ClearAccommodations();
            Customers.ClearCustomers();

            var customer1 = CreateCustomer("John Doe", "john.doe@email.com", "555-1234");
            var customer2 = CreateCustomer("Jane Smith", "jane.smith@email.com", "555-5678");

            ShowCustomers();

            var accommodation1 = CreateAccommodation("Beachside Apartment", "Apartment", 120.50);
            var accommodation2 = CreateAccommodation("Mountain Cabin", "House", 150.00);

            ShowAccommodations();

            var reservation1 = CreateReservation(customer1, accommodation1, new DateTime(2024, 12, 20), new DateTime(2024, 12, 24));

            Console.WriteLine("Trying to create a reservation with overlapping dates...");
            var reservation2 = CreateReservation(customer2, accommodation1, new DateTime(2024, 12, 22), new DateTime(2024, 12, 26));

            reservation1.UpdateStatus(ReservationStatus.Cancelled);
            Console.WriteLine($"Reservation #{reservation1.GetId} status changed to {reservation1.GetStatus}.");

            Console.WriteLine("Retrying to create reservation #2...");
            reservation2 = CreateReservation(customer2, accommodation1, new DateTime(2024, 12, 25), new DateTime(2024, 12, 30));

            ShowReservations();
        }

        private static Customer CreateCustomer(string name, string email, string contactInfo)
        {
            var id = CustomerService.GetNextId();
            var customer = new Customer(id, name, email, contactInfo);
            CustomerService.AddCustomer(customer);
            Console.WriteLine("Created customer #" + customer.GetId);
            return customer;
        }

        private static Accommodation CreateAccommodation(string name, string type, double pricePerNight)
        {
            var id = AccommodationService.GetNextId();
            var accommodation = new Accommodation(id, name, type, pricePerNight);
            AccommodationService.AddAccommodation(accommodation);
            Console.WriteLine("Created accommodation #" + accommodation.GetId);
            return accommodation;
        }

        private static Reservation CreateReservation(Customer customer, Accommodation accommodation, DateTime checkIn, DateTime checkOut)
        {
            var id = ReservationService.GetNextId();
            var reservation = new Reservation(id, customer, accommodation, checkIn, checkOut);

            if (ReservationService.AddReservation(reservation))
            {
                Console.WriteLine($"Reservation #{reservation.GetId} added successfully.");
            }
            else
            {
                Console.WriteLine($"Reservation #{reservation.GetId} could not be added due to overlap or availability issues.");
            }

            return reservation;
        }

        private static void ShowCustomers()
        {
            Console.WriteLine("Customers:");
            foreach (var customer in Customers.GetAllCustomers())
            {
                Console.WriteLine(customer);
            }
            Console.WriteLine();
        }

        private static void ShowAccommodations()
        {
            Console.WriteLine("Accommodations:");
            foreach (var accommodation in Accommodations.GetAllAccommodations())
            {
                Console.WriteLine(accommodation);
            }
            Console.WriteLine();
        }

        private static void ShowReservations()
        {
            Console.WriteLine("Reservations:");
            foreach (var reservation in Reservations.GetAllReservations())
            {
                Console.WriteLine(reservation);
            }
            Console.WriteLine();
        }
    }
}
