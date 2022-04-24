using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] InventorySO inventory;
    [SerializeField] UIBar uIBar;

    DisplayInventory displayInventory;
    [SerializeField]List<Item> pickableItems;

    void Start()
    {
        pickableItems = new List<Item>();
        displayInventory = FindObjectOfType<DisplayInventory>();
        displayInventory.Initiate();
        uIBar.SetMaxValue(inventory.GetMaximumWeight());
        uIBar.SetCurrentValue(inventory.GetInventoryWeight());
    }
    
    void Update()
    {
        /*At key down this code drops the element on position 
        0 in my inventory list and reset the display*/
        DropItemLogic();
        AddItemLogic();
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        Item interactable = other.gameObject.GetComponent<Item>();
        if(interactable!=null)
            pickableItems.Add(interactable);
    }
    void OnTriggerExit2D(Collider2D other) 
    {
        Item interactable = other.gameObject.GetComponent<Item>();
        if(interactable!=null)
            pickableItems.Remove(interactable);
    }

    //This function resets the inventory when the application terminates
    void OnApplicationQuit() 
    {
        inventory.container.Clear();
    }

    private void AddItemLogic()
    {
        if (Input.GetKeyDown(KeyCode.E) && pickableItems.Count>0)
        {
            var item = pickableItems[0];
            pickableItems.Remove(item);
            if (!inventory.CheckIfHaveItemType(item.item))
            {
                AddItemInInventory(item);
            }
        }
    }
    
    void AddItemInInventory(Item item)
    {
        item.ResetSprite();
        inventory.AddItem(item.item);
        Destroy(item.gameObject);
        displayInventory.RefreshDisplay();
        uIBar.SetCurrentValue(inventory.GetInventoryWeight());
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
            uIBar.SetCurrentValue(inventory.GetInventoryWeight());
        }
    }
}