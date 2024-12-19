using TouristAccommodationManagement.Models;

namespace TouristAccommodationManagement.FileHandlers;

public class AccommodationFileHandler : BaseFileHandler
{
    private const string FolderPath = "./files/accommodations";

    public static void SaveToFile(List<Accommodation> accommodations)
    {
        var filePath = GenerateFileName(FolderPath, "accommodations");

        using StreamWriter writer = new StreamWriter(filePath);
        foreach (var accommodation in accommodations)
        {
            writer.WriteLine($"{accommodation.GetId}|{accommodation.GetName}|{accommodation.GetType}|{accommodation.GetPricePerNight}");
        }
    }
}