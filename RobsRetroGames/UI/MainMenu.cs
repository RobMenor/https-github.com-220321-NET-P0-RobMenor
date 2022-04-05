using Models;
using System.ComponentModel.DataAnnotations;
using BL;

namespace UI;

public class MainMenu
{
    public void Start()
    {
        Main:
        Console.WriteLine("Have you shopped with us before? [Y/N]");

        string newShopper = Console.ReadLine() ?? "";

        char respChar;
            try
            {
                respChar = newShopper.Trim().ToUpper()[0];
            }
            catch(IndexOutOfRangeException ex)
            {
                Console.WriteLine("Invalid response");
                goto Main;
            }

            if(respChar == 'N')
            {
                Name:
                Console.WriteLine("Please sign up. What is your name?");
                string name = Console.ReadLine() ?? "";

            if(String.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Please enter valid name.");
                goto Name;
            }
            else if (respChar != 'Y' )
            {
                Console.WriteLine("Hello " + name);
            }
        }

        Console.WriteLine("Sign in with name");
        Console.ReadLine();

        bool exit = false;
        do
        {
            Console.WriteLine("Welcome to Rob's Retro Games");
            Console.WriteLine("What can I do for you today?");
            Console.WriteLine("[1] Request a game");
            Console.WriteLine("[2] View inventory");
            Console.WriteLine("[3] Select an item");
            Console.WriteLine("[4] Upsell or Downsell a game");
            Console.WriteLine("[5] Mark as sold out");
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

                case "3":
                    SelectItem();
                break;

                case "4":
                    SearchGames();
                break;

                case "5":
                    SoldOut();
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
            Console.WriteLine(itemToDisplay);
        }
    }

    private Inventory? SelectItem()
    {
        Console.WriteLine("Select an item");
        List<Inventory> allItems = new RRGBL().GetInventory();

        if(allItems.Count == 0)
        {
            Console.WriteLine("No items to display");
            return null;
        }

        ItemSelect:
        for(int i = 0; i < allItems.Count; i++)
        {
            Console.WriteLine($"[{i}] {allItems[i]}");
        }

        int selection;
        if(Int32.TryParse(Console.ReadLine(), out selection) && (selection >= 0 && selection < allItems.Count))
        {
            return allItems[selection];
        }
        else
        {
            Console.WriteLine("Enter valid input");
            goto ItemSelect;
        }
    }

    private List<Inventory> SearchGames()
    {
        Console.WriteLine("Enter title of game");
        string input = Console.ReadLine()!.ToLower();

        List<Inventory> allItems = new RRGBL().GetInventory();
        List<Inventory> foundItems = allItems.FindAll(item => item.Title.ToLower().Contains(input) || item.GameSystem.Contains(input));

        foreach(Inventory item in foundItems)
        {
            Rate:
            Console.WriteLine(item);
            Console.WriteLine("[U]psell or [D]ownsell game. [P]ass or [E]xit");

            string resp = Console.ReadLine().Trim().ToUpper();

            char respChar;
            try
            {
                respChar = resp.Trim().ToUpper()[0];
            }
            catch(IndexOutOfRangeException ex)
            {
                Console.WriteLine("Invalid response");
                goto Rate;
            }

            if(resp == "U")
            {
                item.UpSell();
            }
            else if(resp == "D")
            {
                item.DownSell();
            }
            else if(resp == "P")
            {
                continue;
            }
            else if(resp == "E")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid response");
                goto Rate;
            }
            //Console.WriteLine(item);
        }
        return foundItems;
    }

    private void SoldOut()
    {
        Inventory? x = SelectItem();

        OutOfStock:
        Console.WriteLine($"Are you sure {x.Title} is out of stock? [Y/N]: ");
        string? resp = Console.ReadLine();

        char respChar = resp.Trim().ToUpper()[0];

        if(String.IsNullOrWhiteSpace(resp))
        {
            Console.WriteLine("Invalid response");
            goto OutOfStock;
        }

        if(respChar == 'N')
        {
            return;
        }
        else if (respChar != 'Y')
        {
            Console.WriteLine("Invalid response");
            goto OutOfStock;
        }

        Console.WriteLine($"{x.Title} is now out of stock");

        new RRGBL().SoldOut(x);
    }
}