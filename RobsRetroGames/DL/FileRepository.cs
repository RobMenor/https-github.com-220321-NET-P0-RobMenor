using System.Text.Json;
using Models;

namespace DL;

public class FileRepository
{
    private readonly string filePath = "../DL/StackLite.json";

    public List<Inventory> GetInventories()
    {
        string jsonString = "";

        try
        {
            jsonString = File.ReadAllText(filePath);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            
        }

        List<Inventory> items = new List<Inventory>();

        try
        {
            items = JsonSerializer.Deserialize<List<Inventory>>(jsonString) ?? new List<Inventory>();
        }
        catch(JsonException ex)
        {
            Console.WriteLine("There was a problem with the format of jsonString");
            Console.WriteLine(ex.Message);
        }

        return items;
    }

    public void CreateRequest(Inventory requestToCreate)
    {
        if(requestToCreate == null) throw new ArgumentNullException();

        List<Inventory> allItems = GetInventories();
        allItems.Add(requestToCreate);

        string jsonString = JsonSerializer.Serialize(allItems);
        File.WriteAllText(filePath, jsonString);
    }
}