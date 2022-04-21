using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Database/Create Inventory", order = 0)]
public class InventorySO : ScriptableObject
{
    public List<InventorySlot> Container = new List<InventorySlot>();

    public bool CheckIfHaveItemType(ItemSO _item)
    {
        for(int i = 0; i < Container.Count; i++) 
        {
            if(Container[i].item.type ==_item.type)
            {
                return true;
            }
        }
        return false;
    }
    public void AddItem(ItemSO _item)
    {
        Container.Add(new InventorySlot(_item));
    }

    public void DropItem()
    {
        if(Container.Count > 0)
        {
            Container.RemoveAt(0);
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
