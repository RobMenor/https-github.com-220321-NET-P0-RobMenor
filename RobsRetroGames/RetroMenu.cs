
namespace RobsRMenu;

public class RetroMenu
{
    public void MainMenu()
    {
        Console.WriteLine("Welcome to Rob's Retro Games.");
        Console.WriteLine("What console are you looking for today?");
        
        string? brand = Console.ReadLine();
        Console.WriteLine("You said " + brand);

        Console.WriteLine("Ok. What title are you looking for?");
        string? title = Console.ReadLine();
        Console.WriteLine("Ok. Let me see if I have " + title + " for " + brand);
    }
}