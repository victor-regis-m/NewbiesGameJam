using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayInventory : MonoBehaviour
{
    [SerializeField] InventorySO inventory;

    void Start() 
    {
        //Initialise the display at run
         inventory.InitializeInventory();
         CreateDisplay();
    }

    //Initialize the UI prefab within the Inventory panel UI
    public void CreateDisplay()
    {
        for(int i = 0; i < inventory.container.Count; i++) 
        {
            var obj = Instantiate(inventory.container[i].item.GetItemPrefab(), Vector3.zero, Quaternion.identity);
            obj.transform.SetParent(gameObject.transform);
        }
    }

    //This function recreates all the slots as a refresh
    public void RefreshDisplay()
    {
        foreach(Transform child in gameObject.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        CreateDisplay();
    }
}
