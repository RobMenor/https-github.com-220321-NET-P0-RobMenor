
namespace RobsRMenu;

public class RetroMenu
{
    public void MainMenu()
    {
        Console.WriteLine("Welcome to Rob's Retro Games.");

        EnterBrand:
        Console.WriteLine("What console are you looking for today?");
        
        string? brand = Console.ReadLine();

        if(String.IsNullOrWhiteSpace(brand))
        {
            Console.WriteLine("Please enter valid brand.");
            goto EnterBrand;
        }

        Console.WriteLine("You said " + brand);

        EnterTitle:
        Console.WriteLine("Ok. What title are you looking for?");
        string? title = Console.ReadLine();

        if(String.IsNullOrWhiteSpace(title))
        {
            Console.WriteLine("Please enter valid title.");
            goto EnterTitle;
        }

        //Inventory newInventory = new Inventory();
        // newInventory.Brand = brand;
        // newInventory.Title = title;
        // newInventory.Price = 0;

        Inventory newInventory = new Inventory(brand, title);
        Console.WriteLine(newInventory.ToString());
    }
}