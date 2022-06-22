using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Slider))]
public class SliderValueDisplayer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI sliderText;

    private Slider _slider;
    // Start is called before the first frame update
    void Start()
    {
        _slider = GetComponent<Slider>();
        if (sliderText != null)
        {
            _slider.onValueChanged.AddListener((value) =>
            {
                sliderText.text = value.ToString("0.##");
            });
        }
        
    }
}
