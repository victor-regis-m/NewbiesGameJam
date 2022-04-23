using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemSO item;

    void Awake() 
    {
        //Add a Sprite Renderer and a BoxCollider 2D to our GameObject
        gameObject.AddComponent<SpriteRenderer>();
        gameObject.AddComponent<BoxCollider2D>();
    }
    /*At startthe UI prefab within the SO, the item will be 
    initialised with the current sprite attached to the same SO*/
    void Start()
    {
        //Setting up our Sprite Renderer
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.sprite = item.GetItemimage();
        item.SetSpriteOnItemPrefab(sr.sprite);
        //Setting up our Box Collider
        BoxCollider2D bc2D = GetComponent<BoxCollider2D>();
        bc2D.isTrigger = true;
        bc2D.size = new Vector2(1,1);
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
