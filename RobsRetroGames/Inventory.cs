namespace RobsRMenu;

public class Inventory
{
    public Inventory()
    {
        Price = 0;
        _brand = "";
        Title = "";
    }

    public Inventory(string brand, string title) : this()
    {
        _brand = brand;
        Title = title;
    }
    private string? _brand;
    public string? Brand
    {
        get
        {
            return _brand;
        }
        set
        {
            _brand = value;
        }
    }

    public string? Title { get; set; }

    public int Price { get; set; }

    public void UpSell()
    {
        Price++;
    }

    public void DownSell()
    {
        Price--;
    }

    public override string ToString()
    {
        return $"Ok. Let me see if I have {this.Title} for {this.Brand} it'll be {this.Price} dollars";
    }
}