namespace Models;

public abstract class TextEntry
{
    public DateTime DateCreated { get; set; }

    public string? Console { get; set; }

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
}