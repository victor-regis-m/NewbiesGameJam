using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Consumable,
    Equipment,
    Default
}
public abstract class ItemSO : ScriptableObject
{
    [SerializeField] Sprite itemSprite;
    [SerializeField] string itemName;
    public ItemType type;

    public Sprite GetItemSprite()
    {
        return itemSprite;
    }

    public string GetItemName()
    {
        return itemName;
    }
}
