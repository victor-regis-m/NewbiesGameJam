using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Default Object", menuName = "Database/Items/Weapon Item", order = 0)]
public class WeaponItemSO : ItemSO
{
    [SerializeField] float damagePoints;
    [SerializeField] float rangeBonusPoints;

    public float GetDamagePoints() => damagePoints;
    public float GetRangeBonusPoints() => rangeBonusPoints;

    void Awake() 
    {
        type = ItemType.Weapon;
    }
}
