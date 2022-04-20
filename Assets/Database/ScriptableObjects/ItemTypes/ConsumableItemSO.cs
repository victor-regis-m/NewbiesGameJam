using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Default Object", menuName = "Database/Items/Consumable Item", order = 0)]
public class ConsumableItemSO : ItemSO
{
    void Awake() 
    {
        type =ItemType.Consumable;
    }
}
