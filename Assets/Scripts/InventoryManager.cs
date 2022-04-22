using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] InventorySO inventory;

    DisplayInventory displayInventory;
    void Start()
    {
        displayInventory = FindObjectOfType<DisplayInventory>();
    }
    
    void Update() 
    {
        /*At key down this code drops the element on position 
        0 in my inventory list and reset the display*/
        //To be reworked
        if(Input.GetKeyDown(KeyCode.E))
        {
            inventory.DropItem(0);
            displayInventory.RefreshDisplay();
        }
    }

    /* On trigger the item is added automatically to the inventory, 
    this has to be changed for the action to happen when key down*/
    //To be reworked
    private void OnTriggerEnter2D(Collider2D other) 
    {
        var item = other.GetComponent<Item>();
        if(other.GetComponent<Item>() && !inventory.CheckIfHaveItemType(item.item))
        {
            AddItemInInventory(other, item);
        }
    }

    private void AddItemInInventory(Collider2D other, Item item)
    {
        //Reset Item Sprite
        item.ResetSprite();
        //Add item to the inventory using the prefab UI attached
        inventory.AddItem(item.item);
        //Destroy this gameobject
        Destroy(other.gameObject);
        //Refresh display to show the latest update
        displayInventory.RefreshDisplay();
    }

    //This function resets the inventory when the application terminates
    private void OnApplicationQuit() 
    {
        inventory.container.Clear();
    }
}
