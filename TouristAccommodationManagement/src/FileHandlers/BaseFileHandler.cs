namespace TouristAccommodationManagement.FileHandlers;

public abstract class BaseFileHandler
{
    protected static void EnsureDirectoryExists(string path)
    {
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
    }

    protected static string GenerateFileName(string folder, string entity)
    {
        EnsureDirectoryExists(folder);
        string timestamp = DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss");
        return Path.Combine(folder, $"{entity}_{timestamp}.txt");
    }
}