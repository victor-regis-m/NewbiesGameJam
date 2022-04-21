using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public ItemSO item;

    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.sprite = item.GetItemimage();
        Image img = item.itemPrefab.GetComponent<Image>();
        img.sprite = sr.sprite;

        Debug.Log(img.sprite.name);
    }
}
