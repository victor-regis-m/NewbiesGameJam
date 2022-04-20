using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Database/Create Inventory", order = 0)]
public class InventorySO : ScriptableObject
{
    [SerializeField] GameObject inventorySlotPrefab;
    [SerializeField] int slotsCount;
    [SerializeField] List<InventorySlot> inventorySlots = new List<InventorySlot>();

    public void InitializeInventory() 
    {
        inventorySlots = new List<InventorySlot>(slotsCount);
        for(int i = 0; i < slotsCount; i++) 
        {
            inventorySlots[i].frameSlot = inventorySlotPrefab;
            inventorySlots[i].isEmpty = true; 
        }
    }

}

[System.Serializable]
public class InventorySlot
{
    public GameObject frameSlot;
    public bool isEmpty = true;
    public ItemSO item;
}
