using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayInventory : MonoBehaviour
{
    [SerializeField] InventorySO inventory;
    void Start() 
    {
         inventory.InitializeInventory();
    }
}
