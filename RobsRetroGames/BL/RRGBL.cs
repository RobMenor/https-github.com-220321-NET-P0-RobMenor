using Models;
using DL;

namespace BL;
public class RRGBL
{
    public void CreateRequest(Inventory requestToCreate)
    {
        new FileRepository().CreateRequest(requestToCreate);
    }

    public List<Inventory> GetInventory()
    {
        return new FileRepository().GetInventories();
    }

    public void SoldOut(Inventory markAsSold)
    {
        StaticStorage.Items.Remove(markAsSold);
    }
}
