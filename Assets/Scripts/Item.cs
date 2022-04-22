using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemSO item;

    /*At startthe UI prefab within the SO, the item will be 
    initialised with the current sprite attached to the same SO*/
    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.sprite = item.GetItemimage();
        item.SetSpriteOnItemPrefab(sr.sprite);
    }

    /* Reset the sprite before Instantiate it in the UI 
    so the sprite will reflect what the item would like, 
    this is needed due to using the same prefab UI element*/
    public void ResetSprite()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        item.SetSpriteOnItemPrefab(item.GetItemimage());
    }
}
