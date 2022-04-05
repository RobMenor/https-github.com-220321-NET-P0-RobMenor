using System.ComponentModel.DataAnnotations;

namespace Models;
public class Inventory : TextEntry
{
    private string? gameSystem;

     public new string? GameSystem
    {
        get => gameSystem;
        set
        {
            if(String.IsNullOrWhiteSpace(value))
            {
                throw new ValidationException("Game System cannot be empty");
            }
            gameSystem = value;
        }
    }

    public bool IsSold { get; set; }
    public List<Demand> Demands { get; set; }

    public override string ToString()
    {
        return $"Game System: {GameSystem} \nTitle: {Title} \nPrice: {Price} \nDate Created: {DateCreated}";
    }
}
