using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Default Object", menuName = "Database/Items/Cloak Item", order = 0)]
public class CloakItemSO : ItemSO
{
    [SerializeField] float healthPoints;

    public float GetHealthPoints() => healthPoints;

    void Awake() 
    {
        type = ItemType.Cloak;
    }
}
