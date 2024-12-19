using TouristAccommodationManagement.Models;

namespace TouristAccommodationManagement.FileHandlers;

public class CustomerFileHandler : BaseFileHandler
{
    private const string FolderPath = "files/customers";

    public static void SaveCustomers(List<Customer> customers)
    {
        var filePath = GenerateFileName(FolderPath, "customers");

        using StreamWriter writer = new StreamWriter(filePath);
        foreach (var customer in customers)
        {
            writer.WriteLine($"{customer.GetId}|{customer.GetName}|{customer.GetEmail}");
        }
    }
    
    public static List<Customer> LoadCustomers(string filePath)
    {
        var customers = new List<Customer>();

        if (!File.Exists(filePath))
        {
            Console.WriteLine("Customer file does not exist.");
            return customers; // Return empty list if file doesn't exist
        }

        using StreamReader reader = new StreamReader(filePath);
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            var parts = line.Split('|');
            if (parts.Length == 3)
            {
                var customer = new Customer(int.Parse(parts[0]), parts[1], parts[2], null);  // Assuming contact info is optional
                customers.Add(customer);
            }
        }

        return customers;
    }
}