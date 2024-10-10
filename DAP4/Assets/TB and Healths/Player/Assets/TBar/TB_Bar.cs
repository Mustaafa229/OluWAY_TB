using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TB_Bar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
   
    public void SetMaxTBAmount(int tbAmount)
    {
        slider.maxValue = tbAmount;
        slider.value = tbAmount;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void SetTBAmount(int tbAmount)
    {
        slider.value = tbAmount;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

   
}
