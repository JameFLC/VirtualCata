using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderTimeDisplayer : SliderValueDisplayer
{
    [SerializeField] protected bool tenTimes = true;
    protected override void UpdateText(float value)
    {
        uint seconds = (uint)Mathf.RoundToInt(value);
        if (tenTimes)
            seconds *= 10;

        string timeText = "";
       
        timeText += seconds + "s";
        sliderText.text = timeText;
    }
    
}
