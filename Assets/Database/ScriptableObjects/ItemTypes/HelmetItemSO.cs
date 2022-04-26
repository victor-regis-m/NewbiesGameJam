using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Default Object", menuName = "Database/Items/Helmet Item", order = 0)]
public class HelmetItemSO : ItemSO
{
    [SerializeField] float armorPoints;
    [SerializeField] float healthPoints;

    public float GetArmorPoints() => armorPoints;
    public float GetHealthPoints() => healthPoints;
    
    void Awake() 
    {
        type = ItemType.Helmet;
    }
}
