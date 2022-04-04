using Models;
using System.ComponentModel.DataAnnotations;
using BL;

namespace UI;

public class MainMenu
{
    public void Start()
    {

        bool exit = false;
        do
        {
            Console.WriteLine("Welcome to Rob's Retro Games");
            Console.WriteLine("What can I do for you today?");
            Console.WriteLine("[1] Request a game");
            Console.WriteLine("[2] View inventory");
            Console.WriteLine("[x] Exit");

            string? input = Console.ReadLine();

            switch(input)
            {
                case "1":
                    GameRequest();
                break;

                case "2":
                    DisplayAllItems();
                break;

                case "x":
                    Console.WriteLine("Thank you. Come again.");
                    exit = true;
                break;

                default:
                    Console.WriteLine("Invalid input");
                break;
            }
        }while(!exit);
    }

    private void GameRequest()
    {
        RequestGame:
        Console.WriteLine("Submiting new game request");
        Console.WriteLine("Enter system game is on: ");
        string? gameSystem = Console.ReadLine();

        Console.WriteLine("Enter title of game: ");
        string? title = Console.ReadLine();

        // Console.WriteLine("What is your price range?: ");
        // int priceRange = Console.ReadLine();

        Inventory GameRequest = new Inventory();
        try
        {
            GameRequest.GameSystem = gameSystem;
            GameRequest.Title = title;
            //GameRequest.Price = priceRange;
        }
        catch(ValidationException ex)
        {
            Console.WriteLine(ex.Message);
            goto RequestGame;
        }

        new RRGBL().CreateRequest(GameRequest);
    }

    private void DisplayAllItems()
    {
        Console.WriteLine("Inventory List");
        List<Inventory> allItems = new RRGBL().GetInventory();

        foreach(Inventory itemToDisplay in allItems)
        {
            Console.WriteLine($"Game System: {itemToDisplay.GameSystem}, Title: {itemToDisplay.Title}, DateCreated: {itemToDisplay.DateCreated}, Price: {itemToDisplay.Price}");
        }
    }
}