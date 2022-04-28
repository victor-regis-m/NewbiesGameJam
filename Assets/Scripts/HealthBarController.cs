using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    [SerializeField] Sprite emptyHeart;
    [SerializeField] Sprite halfHeart;
    [SerializeField] Sprite fullHeart;

    float maxHealthValue;
    float currentHealth;
    int halfHeartAmount;
    int fullHeartAmount;
    int emptyHeartAmount;
    Vector2 imageSize;
    [SerializeField]List<GameObject> heartList;

    public void SetMaxValue(float val)
    {
        maxHealthValue = val;
    }

    public void SetCurrentValue(float val)
    {
        currentHealth = val;
    }

    public void CalculateHeartAmount()
    {
        int slots = (int) maxHealthValue/2;
        int quotient = (int) currentHealth;
        halfHeartAmount = quotient%2;
        fullHeartAmount = (quotient - halfHeartAmount)/2;
        emptyHeartAmount = slots - halfHeartAmount - fullHeartAmount;
    }

    public void DisplayHearts()
    {
        imageSize = new Vector2 (100,100);
        heartList = new List<GameObject>();
        RectTransform startingPosition = GetComponent<RectTransform>();
        for (int i=0; i<fullHeartAmount; i++)
        {
            GameObject empty = new GameObject();
            empty.transform.position = transform.position + new Vector3(i*imageSize.x,0);
            empty.transform.parent = transform;
            Image heartImage = empty.AddComponent<Image>() as Image;
            heartImage.sprite = fullHeart;
            heartImage.GetComponent<RectTransform>().sizeDelta = imageSize;
            heartList.Add(empty);
        }
        for (int i=fullHeartAmount; i<halfHeartAmount+fullHeartAmount; i++)
        {
            GameObject empty = new GameObject();
            empty.transform.position = transform.position + new Vector3(i*imageSize.x,0);
            empty.transform.parent = transform;
            Image heartImage = empty.AddComponent<Image>() as Image;
            heartImage.sprite =  halfHeart;
            heartImage.GetComponent<RectTransform>().sizeDelta = imageSize;
            heartList.Add(empty);
        }
        for (int i=halfHeartAmount+fullHeartAmount; i<emptyHeartAmount+halfHeartAmount+fullHeartAmount; i++)
        {
            GameObject empty = new GameObject();
            empty.transform.position = transform.position + new Vector3(i*imageSize.x,0);
            empty.transform.parent = transform;
            Image heartImage = empty.AddComponent<Image>() as Image;
            heartImage.sprite = emptyHeart;
            heartImage.GetComponent<RectTransform>().sizeDelta = imageSize;
            heartList.Add(empty);
        }
    }


    void Update()
    {
        CalculateHeartAmount();
        DisplayHearts();
    }
}
