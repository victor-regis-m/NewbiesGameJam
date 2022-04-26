using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Default Object", menuName = "Database/Items/BodyArmor Item", order = 0)]
public class BodyArmorItemSO : ItemSO
{
    [SerializeField] float armorPoints;

    public float GetArmorPoints() => armorPoints;

    void Awake() 
    {
        type = ItemType.BodyArmor;
    }
}
