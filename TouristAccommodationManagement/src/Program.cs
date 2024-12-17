using TouristAccommodationManagement.Data;
using TouristAccommodationManagement.Models;
using TouristAccommodationManagement.Services;

namespace TouristAccommodationManagement
{
    class Program //this program is ok as front-end, but it should be in another project (same solution)
    {
        public static void Main(string[] args)
        {
            // Create customers
            var idCust1 = CustomerRules.GetNextId();
            var customer1 = new Customer(idCust1, "John Doe", "john.doe@email.com", "555-1234");
            CustomerRules.AddCustomer(customer1);
            
            var idCust2 = CustomerRules.GetNextId();
            var customer2 = new Customer(idCust2, "Jane Smith", "jane.smith@email.com", "555-5678");
            CustomerRules.AddCustomer(customer2);

            // Show customers
            Console.WriteLine("Customers:");
            foreach (var customer in Customers.GetAllCustomers())
            {
                Console.WriteLine(customer);
            }
            Console.WriteLine();
            
            
            // Create accommodations
            var idAcc1 = AccommodationRules.GetNextId();
            var accommodation1 = new Accommodation(idAcc1, "Beachside Apartment", "Apartment", 120.50);
            AccommodationRules.AddAccommodation(accommodation1);
            
            var idAcc2 = AccommodationRules.GetNextId();
            var accommodation2 = new Accommodation(idAcc2, "Mountain Cabin", "House", 150.00);
            AccommodationRules.AddAccommodation(accommodation2);
            
            // Update accommodation
            accommodation2.UpdateStatus(false);
            
            // Show accommodations
            Console.WriteLine("Accommodations:");
            foreach (var accommodation in Accommodations.GetAllAccommodations())
            {
                Console.WriteLine(accommodation);
            }
            Console.WriteLine();
            
            
            // Create a reservation
            var idRes1 = ReservationRules.GetNextId();
            var reservation1 = new Reservation(idRes1, customer1, accommodation1, new DateTime(2022, 6, 1), new DateTime(2022, 6, 7));
            var successRes1 = ReservationRules.AddReservation(reservation1);
            if (successRes1)  {
                Console.WriteLine($"Reservation #{reservation1.GetId} added successfully.");
            } else {
                Console.WriteLine($"Reservation #{reservation1.GetId} could not be added.");
            }
            
            // Update reservation status
            reservation1.UpdateStatus(ReservationStatus.Cancelled);
            
            // Create overlapping reservation
            var idRes2 = ReservationRules.GetNextId();
            var reservation2 = new Reservation(idRes2, customer2, accommodation1, new DateTime(2022, 6, 5), new DateTime(2022, 6, 10));
            var successRes2 = ReservationRules.AddReservation(reservation2);
            if (successRes2)  {
                Console.WriteLine($"Reservation #{reservation2.GetId} added successfully.");
            } else {
                Console.WriteLine($"Reservation #{reservation2.GetId} could not be added.");
            }
            
            // Show reservations 
            Console.WriteLine("Reservations:");
            foreach (var reservation in ReservationRules.GetAllReservations())
            {
                Console.WriteLine(reservation);
            }
        }
    }
}