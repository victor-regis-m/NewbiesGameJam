using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Database/Create Inventory", order = 0)]
public class InventorySO : ScriptableObject
{
    [SerializeField] ItemSO inventoryDefaultItemSlot;
    [SerializeField] GameObject inventoryPanel;
    [SerializeField] GameObject inventoryFrameSlotPrefab;
    [SerializeField] List<InventorySlot> inventorySlots;
    [SerializeField] GameObject[] slots;

    void Update()
    {
        Debug.Log(inventorySlots.Count);
        if(slots.Length != inventorySlots.Count)
        {
            for(int i = 0; i < slots.Length; i++) 
            {
                Destroy(slots[i].gameObject);
            }
            slots = new GameObject[inventorySlots.Count];
            for(int i = 0; i < inventorySlots.Count; i++) 
            {
                slots[i] = Instantiate(inventorySlots[i].frameSlot,new Vector2(0,0), Quaternion.identity);
                slots[i].transform.parent = inventoryPanel.transform;
            }
        }
    }

    public void AddItemInInventory(ItemSO itemToAdd)
    {
        inventorySlots.Add(new InventorySlot(inventoryFrameSlotPrefab, itemToAdd));
    }
}

[System.Serializable]
public class InventorySlot
{
    public GameObject frameSlot;
    public ItemSO item;

    public InventorySlot(GameObject frameSlot, ItemSO item)
    {
        this.item = item;
        this.frameSlot = frameSlot;
    }
}
