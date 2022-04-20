using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Default Object", menuName = "Database/Items/Equipment Item", order = 0)]
public class EquipmentItemSO : ItemSO
{
    void Awake() 
    {
        type =ItemType.Equipment;
    }
}
