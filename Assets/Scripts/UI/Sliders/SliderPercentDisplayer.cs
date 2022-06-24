using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderPercentDisplayer : SliderValueDisplayer
{
    protected override void UpdateText(float value)
    {
        float percent = (value - _slider.minValue) / _slider.maxValue * 100;
        sliderText.text = percent.ToString("0.#")+"%";
    }
}
