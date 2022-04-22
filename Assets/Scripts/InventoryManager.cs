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
        if(Input.GetKeyDown(KeyCode.E))
        {
            inventory.DropItem(0);
            displayInventory.RefreshDisplay();
        }
    }

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
        other.GetComponent<Item>().ResetSprite();
        inventory.AddItem(item.item);
        Destroy(other.gameObject);
        displayInventory.RefreshDisplay();
    }

    private void OnApplicationQuit() 
    {
        inventory.container.Clear();
    }
}
