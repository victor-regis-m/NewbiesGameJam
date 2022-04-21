using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Database/Create Inventory", order = 0)]
public class InventorySO : ScriptableObject
{
    [SerializeField] ItemSO defaultSlotItem;
    [SerializeField] int numberOfSlots;
    public List<InventorySlot> container = new List<InventorySlot>();

    public void InitializeInventory()
    {
       for(int i = container.Count; i < numberOfSlots; i++) 
       {
           container.Add(new InventorySlot(defaultSlotItem));
       }
    }

    public bool CheckIfHaveItemType(ItemSO _item)
    {
        for(int i = 0; i < container.Count; i++) 
        {
            if(container[i].item.type ==_item.type)
            {
                return true;
            }
        }
        return false;
    }

    public void AddItem(ItemSO _item)
    {
        for(int i = 0; i < container.Count; i++) 
        {
            if(container[i].item == defaultSlotItem)
            {
                container[i].item = _item;
                break;
            }
        }
    }

    public void DropItem(int index)
    {
        if(container.Count > 0)
        {
            container[index].item = defaultSlotItem;
        }
    }
}

[System.Serializable]
public class InventorySlot
{
    public ItemSO item;

    public InventorySlot(ItemSO item)
    {
        this.item = item;
    }
}
