using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image barFill;



    public void SetExp(int exp)
    {
        slider.value = exp;

        barFill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void MaxExp(int exp)
    {
        slider.maxValue = exp;

    }
}
