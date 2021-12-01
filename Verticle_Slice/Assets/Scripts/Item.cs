using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    private string name;
    public ItemID Itemid;
    public int amount;
    public enum ItemID
    {
        Axe,
        Hoe,
        WateringCan,
        PickAxe,
        Scythe,
        grass,
        Wood,
        Stone,
        Coal,
        Sap,
        Fiber,
        MapleSeed,
        Acorn,
        PineCone,
    }

    public Sprite GetSprite()
    {
        switch (Itemid)
        {
            default:
            case ItemID.Axe: return ItemAssets.instance.Axe;
            case ItemID.Hoe: return ItemAssets.instance.hoe;
            case ItemID.WateringCan: return ItemAssets.instance.WateringCan;
            case ItemID.PickAxe: return ItemAssets.instance.Pickaxe;
            case ItemID.Scythe: return ItemAssets.instance.Scythe;
            case ItemID.grass: return ItemAssets.instance.Grass;
            case ItemID.Wood: return ItemAssets.instance.Wood;
            case ItemID.Stone: return ItemAssets.instance.Stone;
            case ItemID.Coal: return ItemAssets.instance.Coal;
            case ItemID.Sap: return ItemAssets.instance.sap;
            case ItemID.Fiber: return ItemAssets.instance.Fiber;
            case ItemID.MapleSeed: return ItemAssets.instance.MapleSeed;
            case ItemID.Acorn: return ItemAssets.instance.Acorn;
            case ItemID.PineCone: return ItemAssets.instance.PineCone;


        }
    }

    public bool IsStackable()
    {
        switch (Itemid)
        {
            default:
            case ItemID.Axe:
            case ItemID.Hoe:
            case ItemID.Scythe:
            case ItemID.WateringCan:
            case ItemID.PickAxe:
                return false;
            case ItemID.grass:
            case ItemID.Wood:
            case ItemID.Stone:
            case ItemID.Coal:
            case ItemID.Sap:
            case ItemID.Fiber:
            case ItemID.MapleSeed:
            case ItemID.Acorn:
            case ItemID.PineCone:
                return true;
        }
    }


}
