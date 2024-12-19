using TouristAccommodationManagement.Models;

namespace TouristAccommodationManagement.FileHandlers;

public class CustomerFileHandler : BaseFileHandler
{
    private const string FolderPath = "files/customers";

    public static void SaveCustomers(List<Customer> customers)
    {
        BaseFileHandler.EnsureDirectoryExists(FolderPath);
        string filePath = GenerateFileName(FolderPath, "customers");

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (var customer in customers)
            {
                writer.WriteLine($"{customer.GetId}|{customer.GetName}|{customer.GetEmail}");
            }
        }
    }
}