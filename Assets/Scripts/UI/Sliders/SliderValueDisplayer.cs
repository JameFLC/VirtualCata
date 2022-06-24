using TMPro;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Slider))]
public class SliderValueDisplayer : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI sliderText;

    protected Slider _slider;
    // Start is called before the first frame update
    void Start()
    {
        _slider = GetComponent<Slider>();
        if (sliderText != null)
        {
            _slider.onValueChanged.AddListener((value) =>
            {
                UpdateText(value);
            });
        }
        
    }
    protected virtual void UpdateText(float value)
    {
        sliderText.text = value.ToString("0.##");
    }
}
