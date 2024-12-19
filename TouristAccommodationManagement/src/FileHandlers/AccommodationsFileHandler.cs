using System.Text.Json;
using TouristAccommodationManagement.Data;
using TouristAccommodationManagement.Models;

namespace TouristAccommodationManagement.FileHandlers;

public static class AccommodationsFileHandler
{
    private static readonly string FilePath = Path.Combine("DataFiles", "accommodations.txt");

    /// <summary>
    /// Saves accommodations data to a file.
    /// </summary>
    public static void SaveToFile()
    {
        try
        {
            var accommodations = Accommodations.GetAllAccommodations();
            var json = JsonSerializer.Serialize(accommodations, new JsonSerializerOptions { WriteIndented = true });
            Directory.CreateDirectory(Path.GetDirectoryName(FilePath) ?? string.Empty);
            File.WriteAllText(FilePath, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving accommodations to file: {ex.Message}");
        }
    }

    /// <summary>
    /// Loads accommodations data from a file.
    /// </summary>
    public static void LoadFromFile()
    {
        try
        {
            if (!File.Exists(FilePath))
            {
                Console.WriteLine("Accommodations file not found. Starting with an empty list.");
                return;
            }

            var json = File.ReadAllText(FilePath);
            var accommodations = JsonSerializer.Deserialize<List<Accommodation>>(json) ?? new List<Accommodation>();
            Accommodations.ClearAccommodations();
            accommodations.ForEach(accommodation => Accommodations.AddAccommodation(accommodation));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading accommodations from file: {ex.Message}");
        }
    }
}