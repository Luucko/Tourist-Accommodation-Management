using TouristAccommodationManagement.Data;
using TouristAccommodationManagement.Exceptions;
using TouristAccommodationManagement.Models;
using TouristAccommodationManagement.Services;

namespace TouristAccommodationManagement
{
    /// <summary>
    /// Program class that handles the application flow.
    /// It manages customers, accommodations, and reservations, and displays them on the console.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main entry point for the console application.
        /// Initializes and manages customers, accommodations, and reservations.
        /// </summary>
        /// <param name="args">Command-line arguments (not used in this application).</param>
        public static void Main(string[] args)
        {
            // Clear existing data
            Reservations.ClearReservations();
            Accommodations.ClearAccommodations();
            Customers.ClearCustomers();

            // Create customers
            var customer1 = CreateCustomer("John Doe", "john.doe@email.com", "555-1234");
            var customer2 = CreateCustomer("Jane Smith", "jane.smith@email.com", "555-5678");

            // Display customers
            ShowCustomers();

            // Create accommodations
            var accommodation1 = CreateAccommodation("Beachside Apartment", "Apartment", 120.50);
            var accommodation2 = CreateAccommodation("Mountain Cabin", "House", 150.00);

            // Display accommodations
            ShowAccommodations();

            // Create reservations and handle overlapping dates
            var reservation1 = CreateReservation(customer1, accommodation1, new DateTime(2024, 12, 20), new DateTime(2024, 12, 24));

            Console.WriteLine("Trying to create a reservation with overlapping dates...");
            try
            {
                var reservation2 = CreateReservation(customer2, accommodation1, new DateTime(2024, 12, 22), new DateTime(2024, 12, 26));
            }
            catch (InvalidReservationException ex)
            {
                // Handle the exception (for example, log it or notify the user)
                Console.WriteLine($"Error: {ex.Message}");
            }

            // Update reservation status
            reservation1.UpdateStatus(ReservationStatus.Cancelled);
            Console.WriteLine($"Reservation #{reservation1.GetId} status changed to {reservation1.GetStatus}.");

            Console.WriteLine("Retrying to create reservation #2...");
            var reservation3 = CreateReservation(customer2, accommodation1, new DateTime(2024, 12, 25), new DateTime(2024, 12, 30));

            // Display reservations
            ShowReservations();
        }


        /// <summary>
        /// Creates and adds a new customer to the system.
        /// </summary>
        /// <param name="name">Name of the customer.</param>
        /// <param name="email">Email address of the customer.</param>
        /// <param name="contactInfo">Contact information (optional).</param>
        /// <returns>The created Customer object.</returns>
        private static Customer CreateCustomer(string name, string email, string contactInfo)
        {
            var id = CustomerService.GetNextId();
            var customer = new Customer(id, name, email, contactInfo);
            CustomerService.AddCustomer(customer);
            Console.WriteLine("Created customer #" + customer.GetId);
            return customer;
        }

        /// <summary>
        /// Creates and adds a new accommodation to the system.
        /// </summary>
        /// <param name="name">Name of the accommodation.</param>
        /// <param name="type">Type of the accommodation.</param>
        /// <param name="pricePerNight">Price per night for the accommodation.</param>
        /// <returns>The created Accommodation object.</returns>
        private static Accommodation CreateAccommodation(string name, string type, double pricePerNight)
        {
            var id = AccommodationService.GetNextId();
            var accommodation = new Accommodation(id, name, type, pricePerNight);
            AccommodationService.AddAccommodation(accommodation);
            Console.WriteLine("Created accommodation #" + accommodation.GetId);
            return accommodation;
        }

        /// <summary>
        /// Creates and adds a new reservation for a customer and accommodation.
        /// </summary>
        /// <param name="customer">Customer making the reservation.</param>
        /// <param name="accommodation">Accommodation being reserved.</param>
        /// <param name="checkIn">Check-in date for the reservation.</param>
        /// <param name="checkOut">Check-out date for the reservation.</param>
        /// <returns>The created Reservation object.</returns>
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

        /// <summary>
        /// Displays all customers in the system.
        /// </summary>
        private static void ShowCustomers()
        {
            Console.WriteLine("Customers:");
            foreach (var customer in Customers.GetAllCustomers())
            {
                Console.WriteLine(customer);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Displays all accommodations in the system.
        /// </summary>
        private static void ShowAccommodations()
        {
            Console.WriteLine("Accommodations:");
            foreach (var accommodation in Accommodations.GetAllAccommodations())
            {
                Console.WriteLine(accommodation);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Displays all reservations in the system.
        /// </summary>
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
