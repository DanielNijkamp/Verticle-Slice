using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    private Transform ItemContainer;
    private Transform ItemSlot;
    [SerializeField]private int amountofslots;
    [SerializeField]private float SlotZise = 20;

    private void Awake()
    {
        ItemContainer = transform.Find("ItemContainer");
        ItemSlot = ItemContainer.Find("ItemSlot");
        RefreshInventory();
    }


    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
    }

    public void RefreshInventory()
    {
        int x = 0;
        int y = 0;
        foreach (Item item in inventory.GetItemList())
        {
            RectTransform ItemSlotRect = Instantiate(ItemSlot, ItemContainer).GetComponent<RectTransform>();
            ItemSlotRect.gameObject.SetActive(true);
            ItemSlotRect.anchoredPosition = new Vector2(x * SlotZise, y * SlotZise);
            Image image = ItemSlotRect.Find("Background").GetComponent<Image>();
            image.sprite = item.GetSprite();
            TextMeshProUGUI text = ItemSlotRect.Find("Text").GetComponent<TextMeshProUGUI>();
            if (item.amount > 1)
            {
                text.SetText(item.amount.ToString());
            }
            else
            {
                text.SetText("");
            }
            x++;
            if (x >= amountofslots)
            {
                x = 0;
                y--;
            }


        }
    }








    /*
    private Inventory inventory;
    private Transform ItemContainer;
    private Transform ItemSlot;

    private void Awake()
    {
        ItemContainer = transform.Find("ItemContainer");
        Debug.Log(ItemContainer);
        ItemSlot = ItemContainer.Find("ItemSlot");
        Debug.Log(ItemSlot);
    }
    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;

        inventory.OnItemListChange += Inventory_OnItemListChange;

        RefreshInventory();
    }

    private void Inventory_OnItemListChange(object sender, System.EventArgs e)
    {
        Debug.Log("changed");
        RefreshInventory();
    }

    private void RefreshInventory()
    {
        foreach (Transform child in ItemContainer)
        {
            if (child == ItemSlot) continue;
            Destroy(child.gameObject);
        }

        int x = 0;
        int y = 0;
        float slotzise = 45;
        foreach (Item item in inventory.GetItemList())
        {
            RectTransform ItemslotRtransform = Instantiate(ItemSlot, ItemContainer).GetComponent<RectTransform>();
            ItemslotRtransform.gameObject.SetActive(true);
            ItemslotRtransform.anchoredPosition = new Vector2(x * slotzise, y * slotzise);
            Image image = ItemslotRtransform.Find("Image").GetComponent<Image>();
            image.sprite = item.GetSprite();
            TextMeshProUGUI text = ItemslotRtransform.Find("text").GetComponent<TextMeshProUGUI>();
            if (item.amount > 1)
            {
                text.SetText(item.amount.ToString());
            }
            else
            {
                text.SetText("");
            }
            x++;
            if(x >= 4)
            {
                x = 0;
                y--;
            }
        }
    }
    */

}
