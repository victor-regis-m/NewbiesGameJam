using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using TMPro;

public class DisplayInventory : MonoBehaviour
{
    [SerializeField] InventorySO inventory;

    public void Initiate() 
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
            GameObject obj = DisplayItem(i);
            DisplayWeightText(i, obj);
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

    private void DisplayWeightText(int i, GameObject obj)
    {
        var slotText = obj.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        if (inventory.container[i].item.GetItemWeight() > 0)
        {
            slotText.text = inventory.container[i].item.GetItemWeight().ToString();
        }
        else
        {
            slotText.text = "";
        }
    }

    private GameObject DisplayItem(int i)
    {
        var obj = Instantiate(inventory.container[i].item.GetItemPrefab(), Vector3.zero, Quaternion.identity);
        obj.transform.SetParent(gameObject.transform);
        return obj;
    }
}
