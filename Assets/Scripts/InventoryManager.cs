using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] InventorySO inventory;
    // Start is called before the first frame update
    void Start()
    {
        inventory.InitializeInventory();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
