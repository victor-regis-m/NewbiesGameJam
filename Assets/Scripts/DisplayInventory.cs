using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayInventory : MonoBehaviour
{
    [SerializeField] InventorySO inventory;

    void Start() 
    {
         inventory.InitializeInventory();
         CreateDisplay();
    }

    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            RefreshDisplay();
        }
    }

    public void CreateDisplay()
    {
        for(int i = 0; i < inventory.container.Count; i++) 
        {
            var obj = Instantiate(inventory.container[i].item.GetItemPrefab(), Vector3.zero, Quaternion.identity);
            obj.transform.SetParent(gameObject.transform);
            Debug.Log("I created " + (i + 1) + " slots name: " + obj.GetComponent<Image>().sprite.name);
        }
    }

    public void RefreshDisplay()
    {
        foreach(Transform child in gameObject.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        CreateDisplay();
    }
}
