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
        Console.WriteLine("Submiting new game request");
        Console.WriteLine("Enter title of game: ");
        string? title = Console.ReadLine();

        Console.WriteLine("Enter price range: ");
        string? priceRange = Console.ReadLine();
    }
}