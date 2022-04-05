using Models;

namespace DL;
public static class StaticStorage
{
    public static List<Inventory> Items { get; set; } = new List<Inventory>()
    {
        new Inventory
        {
            GameSystem = "Nintendo",
            Title = "Teenage Mutant Ninja Turtles",
            Price = 15 
        },
        new Inventory
        {
            GameSystem = "Nintendo",
            Title = "Tecmo Bowl",
            Price = 10
        },
        new Inventory
        {
            GameSystem = "Super Nintendo",
            Title = "Mario Cart",
            Price = 20
        },
        new Inventory
        {
            GameSystem = "Super Nintendo",
            Title = "NBA Jam",
            Price = 17
        },
        new Inventory
        {
            GameSystem = "Playstation",
            Title = "Final Fantasy 7",
            Price = 50
        },
        new Inventory
        {
            GameSystem = "Playstation",
            Title = "The Legend of Dragoon",
            Price = 40
        },
    };
}
