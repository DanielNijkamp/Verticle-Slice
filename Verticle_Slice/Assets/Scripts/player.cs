using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private Inventory inventory;
    [SerializeField] private UI_Inventory InventoryUI;

    private void Awake()
    {
        inventory = new Inventory();

        InventoryUI.SetInventory(inventory);

        ItemWorld.SpawnItemWorld(new Vector3(0, 10), new Item { Itemid = Item.ItemID.Acorn, amount = 1 });
        ItemWorld.SpawnItemWorld(new Vector3(0, 20), new Item { Itemid = Item.ItemID.MapleSeed, amount = 1 });
        ItemWorld.SpawnItemWorld(new Vector3(0, 30), new Item { Itemid = Item.ItemID.Acorn, amount = 1 });
        ItemWorld.SpawnItemWorld(new Vector3(0, 40), new Item { Itemid = Item.ItemID.Coal, amount = 1 });
        ItemWorld.SpawnItemWorld(new Vector3(0, 50), new Item { Itemid = Item.ItemID.Fiber, amount = 1 });
        ItemWorld.SpawnItemWorld(new Vector3(0, 60), new Item { Itemid = Item.ItemID.Wood, amount = 1 });
        ItemWorld.SpawnItemWorld(new Vector3(0, 70), new Item { Itemid = Item.ItemID.Stone, amount = 1 });
        ItemWorld.SpawnItemWorld(new Vector3(0, 80), new Item { Itemid = Item.ItemID.Fiber, amount = 1 });


    }

    private void OnTriggerEnter2D(Collider2D Collider)
    {
        ItemWorld itemWorld = Collider.GetComponent<ItemWorld>();
        if(itemWorld != null)
        {
            inventory.AddItem(itemWorld.GetItem());
            InventoryUI.RefreshInventory();
            itemWorld.DestroyItem();
        }
    }

}
