using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Default Object", menuName = "Database/Items/Default Inventory Slot Item", order = 1)]
public class DefaultItemSO : ItemSO
{
    void Awake() 
    {
        type = ItemType.Default;
    }
}
