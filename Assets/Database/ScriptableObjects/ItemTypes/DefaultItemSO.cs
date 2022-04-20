using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Default Object", menuName = "Database/Items/Default Item", order = 0)]
public class DefaultItemSO : ItemSO
{
    void Awake() 
    {
        type =ItemType.Default;
    }
}
