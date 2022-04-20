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
    [SerializeField] GameObject itemPrefab;
    [SerializeField] ItemType type;
}
