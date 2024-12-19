using TouristAccommodationManagement.Models;

namespace TouristAccommodationManagement.FileHandlers;

public class AccommodationFileHandler : BaseFileHandler
{
    private const string FolderPath = "./files/accommodations";

    public static void SaveAccommodations(List<Accommodation> accommodations)
    {
        var filePath = GenerateFileName(FolderPath, "accommodations");

        using StreamWriter writer = new StreamWriter(filePath);
        foreach (var accommodation in accommodations)
        {
            writer.WriteLine($"{accommodation.GetId}|{accommodation.GetName}|{accommodation.GetType}|{accommodation.GetPricePerNight}");
        }
    }
    
    public static List<Accommodation> LoadAccommodations(string filePath)
    {
        var accommodations = new List<Accommodation>();

        if (!File.Exists(filePath))
        {
            Console.WriteLine("Accommodation file does not exist.");
            return accommodations; // Return empty list if file doesn't exist
        }

        using StreamReader reader = new StreamReader(filePath);
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            var parts = line.Split('|');
            if (parts.Length == 4)
            {
                var accommodation = new Accommodation(int.Parse(parts[0]), parts[1], parts[2], double.Parse(parts[3]));
                accommodations.Add(accommodation);
            }
        }

        return accommodations;
    }
}