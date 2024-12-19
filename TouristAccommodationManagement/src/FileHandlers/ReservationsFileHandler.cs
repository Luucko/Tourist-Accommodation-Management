using TouristAccommodationManagement.Models;

namespace TouristAccommodationManagement.FileHandlers;

public class ReservationsFileHandler : BaseFileHandler
{
    private const string FolderPath = "files/reservations";

    public static void SaveReservations(List<Reservation> reservations)
    {
        BaseFileHandler.EnsureDirectoryExists(FolderPath);
        string fileName = BaseFileHandler.GenerateFileName(FolderPath, "reservations");

        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (var reservation in reservations)
            {
                writer.WriteLine($"{reservation.GetId}|{reservation.GetCustomer.GetId}|{reservation.GetAccommodation.GetId}|{reservation.GetCheckInDate}|{reservation.GetCheckOutDate}");
            }
        }
    }
}