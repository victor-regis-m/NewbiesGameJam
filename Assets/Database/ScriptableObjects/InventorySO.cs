using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Database/Create Inventory", order = 0)]
public class InventorySO : ScriptableObject
{
    [SerializeField] ItemSO defaultSlotIcon;
    [SerializeField] int numberOfSlots;
    public List<InventorySlot> container = new List<InventorySlot>();

    /*This function Initialise the inventory of its maximum 
    defined size, with a default slot icon*/
    public void InitializeInventory()
    {
        defaultSlotIcon.SetSpriteOnItemPrefab(defaultSlotIcon.GetItemimage());
        for(int i = container.Count; i < numberOfSlots; i++) 
        {
            container.Add(new InventorySlot(defaultSlotIcon));
        }
    }

    /*This function checks for the Item type in the inventory 
    if already have and return true if it does and false otherwise*/
    public bool CheckIfHaveItemType(ItemSO item)
    {
        for(int i = 0; i < container.Count; i++) 
        {
            if(container[i].item.type == item.type)
            {
                return true;
            }
        }
        return false;
    }

    /*This function adds an item if the slot I want to place 
    the item is same with my default slot than I can place my 
    item on this slot*/
    public void AddItem(ItemSO item)
    {
        for(int i = 0; i < container.Count; i++) 
        {
            if(container[i].item == defaultSlotIcon)
            {
                container[i].item = item;
                break;
            }
        }
    }

    /*This function Drops an item from the inventory 
    by destroying the one from UI and returning the item*/
    public void DropItem(int index)
    {
        container[index].item = defaultSlotIcon;
    }

    public ItemSO GetDefaultSlotIcon()
    {
        return defaultSlotIcon;
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
