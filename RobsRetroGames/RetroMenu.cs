
namespace RobsRMenu;

public class RetroMenu
{
    public void MainMenu()
    {
        Console.WriteLine("Welcome to Rob's Retro Games.");

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
            else if (respChar != 'Y')
            {
                Console.WriteLine("Invalid response");
            }
        }
        bool exit = false;
        do
        {
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

            Inventory newInventory = new Inventory(brand, title);
            Console.WriteLine(newInventory.ToString());

            Another:
            Console.WriteLine("Would you like to look for something else? [Y/N]");
            string enterAnother = Console.ReadLine() ?? "";
            
            char responseChar;
            try
            {
                responseChar = enterAnother.Trim().ToUpper()[0];
            }
            catch(IndexOutOfRangeException ex)
            {
                Console.WriteLine("Invalid response");
                goto Another;
            }

            if(responseChar == 'N')
            {
                Console.WriteLine("Have a good day!");
                exit = true;
            }
            else if (responseChar != 'Y')
            {
                Console.WriteLine("Invalid response");
                goto Another;
            }
        }while(!exit);
    }
        
}