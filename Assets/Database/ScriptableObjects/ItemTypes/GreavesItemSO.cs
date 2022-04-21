using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Default Object", menuName = "Database/Items/Greaves Item", order = 0)]
public class GreavesItemSO : ItemSO
{
    void Awake() 
    {
        type = ItemType.Greaves;
    }
}
