using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Default Object", menuName = "Database/Items/Default Inventory Slot Item", order = 1)]
public class DefaultItemSO : ItemSO
{
    void Awake() 
    {
        type = ItemType.Default;
    }   
}
