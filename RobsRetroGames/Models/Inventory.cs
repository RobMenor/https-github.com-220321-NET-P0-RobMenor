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
}
