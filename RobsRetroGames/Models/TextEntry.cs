using System.ComponentModel.DataAnnotations;

namespace Models;

public class TextEntry
{
    public DateTime DateCreated { get; set; } = DateTime.Now;

    private string title = "";
    public string? Title
    {
        get => title;
        set
        {
            if(String.IsNullOrWhiteSpace(value))
            {
                throw new ValidationException("Title cannot be empty");
            }
            title = value;
        }
    }

    public string? GameSystem { get; set; } = "";

    public int Price { get; set; } = 20;

    public void UpSell()
    {
        Price++;
    }

    public void DownSell()
    {
        Price--;
    }
}