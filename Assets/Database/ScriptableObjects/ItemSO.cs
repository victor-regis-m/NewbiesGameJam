using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Weapon,
    Helmet,
    BodyArmor,
    Greaves,
    Cloak,
    Default
}
public abstract class ItemSO : ScriptableObject
{
    public GameObject itemPrefab;
    [SerializeField] Sprite itemImage;
    [SerializeField] string itemName;
    [SerializeField] float itemWeight;
    public ItemType type;

    public GameObject GetItemPrefab()
    {
        return itemPrefab;
    }

    public Sprite GetItemimage()
    {
        return itemImage;
    }

    public string GetItemName()
    {
        return itemName;
    }
    
    public float GetItemWeight()
    {
        return itemWeight;
    }
}
