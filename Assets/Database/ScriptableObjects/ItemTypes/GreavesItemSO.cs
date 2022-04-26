using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Default Object", menuName = "Database/Items/Greaves Item", order = 0)]
public class GreavesItemSO : ItemSO
{
    [SerializeField] float armorPoints;
    [SerializeField] float moveSpeedPoints;
    [SerializeField] float jumpForcePoints;

    public float GetArmorPoints() => armorPoints;
    public float GetMoveSpeedPoints() => moveSpeedPoints;
    public float GetJumpForcePoints() => jumpForcePoints;
    
    void Awake() 
    {
        type = ItemType.Greaves;
    }
}
