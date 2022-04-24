using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBar : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] Gradient gradient;
    [SerializeField] Image fill;

    public void SetMaxValue(float maxValue)
    { 
        slider.maxValue = maxValue;
        gradient.Evaluate(1f);
    }

    public void SetCurrentValue(float currentValue)
    {
        slider.value = currentValue;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
