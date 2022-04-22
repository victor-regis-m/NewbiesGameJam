using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemSO item;

    void Awake()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.sprite = item.GetItemimage();
        item.SetSpriteOnItemPrefab(sr.sprite);
    }

    public void ResetSprite()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        item.SetSpriteOnItemPrefab(item.GetItemimage());
    }
}
