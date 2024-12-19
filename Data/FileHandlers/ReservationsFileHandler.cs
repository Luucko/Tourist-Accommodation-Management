using TouristAccommodationManagement.Data;
using TouristAccommodationManagement.Models;

namespace TouristAccommodationManagement.FileHandlers;

public class ReservationsFileHandler : BaseFileHandler
{
    private const string FolderPath = "files/reservations";

    public static void SaveReservations(List<Reservation> reservations)
    {
        var fileName = BaseFileHandler.GenerateFileName(FolderPath, "reservations");

        using StreamWriter writer = new StreamWriter(fileName);
        foreach (var reservation in reservations)
        {
            writer.WriteLine($"{reservation.GetId}|{reservation.GetCustomer.GetId}|{reservation.GetAccommodation.GetId}|{reservation.GetCheckInDate}|{reservation.GetCheckOutDate}");
        }
    }
    
    public static List<Reservation> LoadReservations(string filePath)
    {
        var reservations = new List<Reservation>();

        if (!File.Exists(filePath))
        {
            Console.WriteLine("Reservations file does not exist.");
            return reservations; // Return empty list if file doesn't exist
        }

        using StreamReader reader = new StreamReader(filePath);
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            var parts = line.Split('|');
            if (parts.Length == 5)
            {
                var customerId = int.Parse(parts[1]);
                var accommodationId = int.Parse(parts[2]);
                var checkInDate = DateTime.Parse(parts[3]);
                var checkOutDate = DateTime.Parse(parts[4]);

                // Assuming that the `Customer` and `Accommodation` objects can be retrieved using these IDs
                var reservation = new Reservation(int.Parse(parts[0]), Customers.GetCustomer(customerId), Accommodations.GetAccommodation(accommodationId), checkInDate, checkOutDate);
                reservations.Add(reservation);
            }
        }

        return reservations;
    }
}