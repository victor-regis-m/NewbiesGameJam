using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    [SerializeField] InventorySO inventory;
    [SerializeField] StatsSO stats;

    float currentMaxHealth;

    void Start()
    {
        currentMaxHealth = stats.GetTotalHealthPoints();
        SetNewStats();
    }

    public void SetNewStats()
    {
        var healthPercentage = stats.GetCurrentHealthPoints()/currentMaxHealth;
        
        for(int i = 0; i < inventory.container.Count; i++) 
        {
            var armor = inventory.container[i].item as BodyArmorItemSO;
            var boots = inventory.container[i].item as GreavesItemSO;
            var weapon = inventory.container[i].item as WeaponItemSO;
            var helm = inventory.container[i].item as HelmetItemSO;
            var cloak = inventory.container[i].item as CloakItemSO;
            
            if(armor)
            {
                stats.SetBonusArmorPoints(armor.GetArmorPoints());
                stats.SetBonusInventoryWeight(armor.GetItemWeight());
            }
            else if(cloak)
            {
                stats.SetBonusHealthPoints(cloak.GetHealthPoints());
                stats.SetBonusInventoryWeight(cloak.GetItemWeight());
            }
            else if(boots)
            {
                stats.SetBonusArmorPoints(boots.GetArmorPoints());
                stats.SetBonusMoveSpeedPoints(boots.GetMoveSpeedPoints());
                stats.SetBonusJumpForcePoints(boots.GetJumpForcePoints());
                stats.SetBonusInventoryWeight(boots.GetItemWeight());
            }
            else if(helm)
            {
                stats.SetBonusArmorPoints(helm.GetArmorPoints());
                stats.SetBonusHealthPoints(helm.GetHealthPoints());
                stats.SetBonusInventoryWeight(helm.GetItemWeight());
            }
            else if(weapon)
            {
                stats.SetBonusDamagePoints(weapon.GetDamagePoints());
                stats.SetBonusRangePoints(weapon.GetRangeBonusPoints());
                stats.SetBonusInventoryWeight(weapon.GetItemWeight());
            }
        }
        Debug.Log("Current max health is: " + stats.GetTotalHealthPoints());
        if(currentMaxHealth != stats.GetTotalHealthPoints())
        {
            currentMaxHealth = stats.GetTotalHealthPoints();
            stats.ConvertCurrentHealthPoints(stats.GetTotalHealthPoints() * healthPercentage);  
        }
            
    }

    public void SetStatsToDefault()
    {
        stats.SetBonusHealthPoints(-stats.GetBonusHealthPoints());
        stats.SetBonusArmorPoints(-stats.GetBonusArmorPoints());
        stats.SetBonusDamagePoints(-stats.GetBonusDamagePoints());
        stats.SetBonusMoveSpeedPoints(-stats.GetBonusMoveSpeedPoints());
        stats.SetBonusRangePoints(-stats.GetBonusRangePoints());
        stats.SetBonusJumpForcePoints(-stats.GetBonusJumpForcePoints());
        stats.SetBonusInventoryWeight(-stats.GetBonusInventoryWeight());
    }

    public void StatsChangeReset()
    {
        SetStatsToDefault();
        SetNewStats();
    }

    public void ResetCurrentHealth()
    {
        stats.ResetCurrentHealthPoints(stats.GetTotalHealthPoints());
    }

    private void OnApplicationQuit()
    {
        SetStatsToDefault();
        ResetCurrentHealth();
    }
}