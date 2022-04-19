using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Database/CreateItem", order = 1)]
public class ItemSO : ScriptableObject
{
    [SerializeField] string itemName;
    [SerializeField] bool canUse;
    [SerializeField] Sprite icon;
    [SerializeField] float weight;

    public string GetName()
    {
        return itemName;
    }
    public Sprite GetIcon()
    {
        return icon;
    } 
    public float GetWeight()
    {
        return weight;
    }

    
}
