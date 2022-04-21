using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Default Object", menuName = "Database/Items/Helmet Item", order = 0)]
public class HelmetItemSO : ItemSO
{
    void Awake() 
    {
        type = ItemType.Helmet;
    }
}
