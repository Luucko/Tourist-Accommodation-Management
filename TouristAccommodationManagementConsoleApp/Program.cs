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
            // Clear previous data (ensuring clean slate)
            Reservations.ClearReservations();
            Accommodations.ClearAccommodations();
            Customers.ClearCustomers();

            // Create customers
            var customer1 = CreateCustomer("John Doe", "john.doe@email.com", "555-1234");
            var customer2 = CreateCustomer("Jane Smith", "jane.smith@email.com", "555-5678");

            ShowCustomers();

            // Create accommodations
            var accommodation1 = CreateAccommodation("Beachside Apartment", "Apartment", 120.50);
            var accommodation2 = CreateAccommodation("Mountain Cabin", "House", 150.00);

            // Show all accommodations
            ShowAccommodations();

            // Create reservations
            var reservation1 = CreateReservation(customer1, accommodation1, new DateTime(2022, 6, 1), new DateTime(2022, 6, 7));
            
            // Try creating a second reservation with overlapping dates
            Console.WriteLine("Trying to create a reservation with overlapping dates...");
            var reservation2 = CreateReservation(customer2, accommodation1, new DateTime(2022, 6, 5), new DateTime(2022, 6, 10));

            // Simulate a reservation status change (e.g., cancel the reservation)
            reservation1.UpdateStatus(ReservationStatus.Cancelled);
            Console.WriteLine($"Reservation #{reservation1.GetId} status changed to {reservation1.GetStatus}.");
            
            // Try recreating the second reservation
            Console.WriteLine("Retrying to create reservation #2...");
            reservation2 = CreateReservation(customer2, accommodation1, new DateTime(2022, 6, 5), new DateTime(2022, 6, 10));

            ShowReservations();
        }

        // Helper method to create a customer and add to the list
        private static Customer CreateCustomer(string name, string email, string contactInfo)
        {
            var id = CustomerRules.GetNextId();
            var customer = new Customer(id, name, email, contactInfo);
            CustomerRules.AddCustomer(customer);
            Console.WriteLine("Created customer #" + customer.GetId);
            return customer;
        }

        // Helper method to create an accommodation and add to the list
        private static Accommodation CreateAccommodation(string name, string type, double pricePerNight)
        {
            var id = AccommodationRules.GetNextId();
            var accommodation = new Accommodation(id, name, type, pricePerNight);
            AccommodationRules.AddAccommodation(accommodation);
            Console.WriteLine("Created accommodation #" + accommodation.GetId);
            return accommodation;
        }

        // Helper method to create a reservation and add to the list
        private static Reservation CreateReservation(Customer customer, Accommodation accommodation, DateTime checkIn, DateTime checkOut)
        {
            var id = Reservations.GetNextId();
            var reservation = new Reservation(id, customer, accommodation, checkIn, checkOut);

            // Ensure no overlap before adding the reservation
            if (Reservations.AddReservation(reservation))
            {
                Console.WriteLine($"Reservation #{reservation.GetId} added successfully.");
            }
            else
            {
                Console.WriteLine($"Reservation #{reservation.GetId} could not be added due to overlap or availability issues.");
            }

            return reservation;
        }

        // Helper method to show all customers
        private static void ShowCustomers()
        {
            Console.WriteLine("Customers:");
            foreach (var customer in Customers.GetAllCustomers())
            {
                Console.WriteLine(customer);
            }
            Console.WriteLine();
        }

        // Helper method to show all accommodations
        private static void ShowAccommodations()
        {
            Console.WriteLine("Accommodations:");
            foreach (var accommodation in Accommodations.GetAllAccommodations())
            {
                Console.WriteLine(accommodation);
            }
            Console.WriteLine();
        }

        // Helper method to show all reservations
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
