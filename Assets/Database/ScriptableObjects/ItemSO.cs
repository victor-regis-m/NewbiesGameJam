using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] GameObject itemPrefab;
    [SerializeField] Sprite itemImage;
    [SerializeField] string itemName;
    [SerializeField] float itemWeight;
    public ItemType type;

    public GameObject GetItemPrefab() => itemPrefab;
    public Sprite GetItemimage() => itemImage;
    public string GetItemName() => itemName;
    public float GetItemWeight() => itemWeight;

    public void SetSpriteOnItemPrefab(Sprite sprite)
    {
        itemPrefab.GetComponent<Image>().sprite = sprite;
    }
}
