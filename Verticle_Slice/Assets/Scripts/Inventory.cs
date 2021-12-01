using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    List<Item> items;
    public event EventHandler OnItemListChange;

    public Inventory()
    {
        items = new List<Item>();
        /*
        AddItem(new Item { Itemid = Item.ItemID.Axe, amount = 1 });
        AddItem(new Item { Itemid = Item.ItemID.Hoe, amount = 1 });
        AddItem(new Item { Itemid = Item.ItemID.Scythe, amount = 1 });
        AddItem(new Item { Itemid = Item.ItemID.WateringCan, amount = 1 });
        */
    }

    public void AddItem(Item item)
    {
        if (item.IsStackable())
        {
            bool ItemAlreadyIninv = false;
            foreach(Item InventoryItem in items)
            {
                if(InventoryItem.Itemid == item.Itemid)
                {
                    InventoryItem.amount += item.amount;
                    ItemAlreadyIninv = true;
                }
            }
            if (!ItemAlreadyIninv)
            {
                items.Add(item);
            }
        }
        else
        {
            items.Add(item);
        }

        OnItemListChange?.Invoke(this, EventArgs.Empty);
    }

    public List<Item> GetItemList()
    {
        return items;
    }

}
