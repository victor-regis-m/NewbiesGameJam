using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Stats", menuName ="Database/Create New Stats", order = 1)]
public class StatsSO : ScriptableObject
{   
    [Header("Base Stats")]
    [SerializeField] float currentHealthPoints;

    [SerializeField] float baseHealthPoints;
    [SerializeField] float baseArmorPoints;
    [SerializeField] float baseDamagePoints;
    [SerializeField] float baseMoveSpeedPoints;
    [SerializeField] float baseRangePoints;
    [SerializeField] float baseJumpForcePoints;
    [SerializeField] float baseInventoryWeight;

    [Header("Bonus Stats")]
    [SerializeField] float bonusHealthPoints;
    [SerializeField] float bonusArmorPoints;
    [SerializeField] float bonusDamagePoints;
    [SerializeField] float bonusMoveSpeedPoints;
    [SerializeField] float bonusRangePoints;
    [SerializeField] float bonusJumpForcePoints;
    [SerializeField] float bonusInventoryWeight;

    public float GetCurrentHealthPoints() => currentHealthPoints;

    public float GetBonusHealthPoints() => bonusHealthPoints;
    public float GetBonusArmorPoints() => bonusArmorPoints;
    public float GetBonusDamagePoints() => bonusDamagePoints;
    public float GetBonusMoveSpeedPoints() => bonusMoveSpeedPoints;
    public float GetBonusRangePoints() => bonusRangePoints;
    public float GetBonusJumpForcePoints() => bonusJumpForcePoints;
    public float GetBonusInventoryWeight() => bonusInventoryWeight;

    public float GetTotalHealthPoints() => bonusHealthPoints + baseHealthPoints;
    public float GetTotalArmorPoints() => bonusArmorPoints + baseArmorPoints;
    public float GetTotalDamagePoints() => bonusDamagePoints + baseDamagePoints;
    public float GetTotalMoveSpeedPoints() => bonusMoveSpeedPoints + baseMoveSpeedPoints;
    public float GetTotalRangePoints() => bonusRangePoints + baseRangePoints;
    public float GetTotalJumpForcePoints() => bonusJumpForcePoints + baseJumpForcePoints;
    public float GetTotalInventoryWeight() => bonusInventoryWeight + baseInventoryWeight;

    public void ResetCurrentHealthPoints( float healthPoints){ currentHealthPoints = healthPoints;}
    public void SetCurrentHealthPoints(float healthPoints){ currentHealthPoints += healthPoints;}
    public void ConvertCurrentHealthPoints( float healthPoints){ currentHealthPoints = healthPoints;}
    
    public void SetBonusHealthPoints(float healthPoints){ bonusHealthPoints += healthPoints;}
    public void SetBonusArmorPoints(float armorPoints){ bonusArmorPoints += armorPoints;}
    public void SetBonusDamagePoints(float damagePoints){ bonusDamagePoints += damagePoints;}
    public void SetBonusMoveSpeedPoints(float moveSpeedPoints){ bonusMoveSpeedPoints += moveSpeedPoints;}
    public void SetBonusRangePoints(float rangePoints){ bonusRangePoints += rangePoints;}
    public void SetBonusJumpForcePoints(float jumpForcePoints){ bonusJumpForcePoints += jumpForcePoints;}
    public void SetBonusInventoryWeight(float inventoryWeight){ bonusInventoryWeight += inventoryWeight;}
}
