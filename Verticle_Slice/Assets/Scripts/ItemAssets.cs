using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets instance { get; private set; }

    private void Awake()
    {
        instance = this;
    }

    public Transform pfItemworld;

    [Header("Tools")]
    public Sprite Pickaxe;
    public Sprite Axe;
    public Sprite hoe;
    public Sprite WateringCan;
    public Sprite Scythe;

    [Header("Pick-ups")]
    public Sprite Grass;
    public Sprite Wood;
    public Sprite Stone;
    public Sprite Coal;
    public Sprite sap;
    public Sprite Fiber;
    public Sprite MapleSeed;
    public Sprite Acorn;
    public Sprite PineCone;
    [Header("Craftables")]
    public Sprite Chest;
}
