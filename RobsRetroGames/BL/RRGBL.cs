﻿using Models;
using DL;

namespace BL;
public class RRGBL
{
    public void CreateRequest(Inventory GameRequest)
    {
        StaticStorage.Items.Add(GameRequest);
    }

    public List<Inventory> GetInventory()
    {
        return StaticStorage.Items;
    }
}