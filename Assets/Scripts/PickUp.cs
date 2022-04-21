using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] InventorySO inventory;
    
    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            inventory.DropItem();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        var item = other.GetComponent<Item>();
        if(other.GetComponent<Item>() && !inventory.CheckIfHaveItemType(item.item))
        {
            inventory.AddItem(item.item);
            Destroy(other.gameObject);
        }
    }
}
