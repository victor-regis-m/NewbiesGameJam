using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] InventorySO inventory;

    DisplayInventory displayInventory;
    Collider2D collid2D;
    bool canPickUp = false;

    void Start()
    {
        displayInventory = FindObjectOfType<DisplayInventory>();
    }
    
    void Update()
    {
        /*At key down this code drops the element on position 
        0 in my inventory list and reset the display*/
        DropItemLogic();
        AddItemLogic();
    }

    /* On trigger the item is added automatically to the inventory, 
    this has to be changed for the action to happen when key down*/
    //To be reworked 
    //Bug known the player can not pick up more than one item if multiple are in exact spot
    void OnTriggerStay2D(Collider2D other)
    {
        canPickUp = true;
        Debug.Log("This is bool on Stay: " + canPickUp);
        collid2D = other;
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        
        canPickUp = false;
        Debug.Log("This is bool on Exit: " + canPickUp);
    }



    //This function resets the inventory when the application terminates
    void OnApplicationQuit() 
    {
        inventory.container.Clear();
    }

    private void AddItemLogic()
    {
        if (canPickUp && Input.GetKeyDown(KeyCode.E))
        {
            var item = collid2D.GetComponent<Item>();
            if (collid2D.GetComponent<Item>() && !inventory.CheckIfHaveItemType(item.item))
            {
                AddItemInInventory(item);
            }
        }
    }
    
    void AddItemInInventory(Item item)
    {
        item.ResetSprite();
        inventory.AddItem(item.item);
        Destroy(collid2D.gameObject);
        displayInventory.RefreshDisplay();
    }

    private void DropItemLogic()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            DropItem(0);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            DropItem(1);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            DropItem(2);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            DropItem(3);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha5))
        {
            DropItem(4);
        }
    }

    void DropItem(int index)
    {
        if(inventory.container[index].item != inventory.GetDefaultSlotIcon())
        {
            var itemToSpawn = new GameObject("Item");
            itemToSpawn.gameObject.AddComponent<Item>().item = inventory.container[index].item;
            itemToSpawn.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            inventory.DropItem(index);
            displayInventory.RefreshDisplay();
        }
    }
}
