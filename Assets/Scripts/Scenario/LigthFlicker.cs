using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;



class LigthFlicker : MonoBehaviour
{
    [SerializeField] private List<float> intensities = new List<float>();
    [SerializeField] private float minimumFlickerDuration = 0.3f;
    [SerializeField] private float flickerDurationRandomness = 1f;
    [SerializeField] private Ease easing = Ease.InOutBounce;

    public bool isFlickerEnabled = true;

    private Light _light;

    private void Start()
    {
        _light = GetComponent<Light>();
        EventManager.instance.OnStartEvacuation += FlickerLight;
    }
    private void OnDestroy()
    {
        EventManager.instance.OnStartEvacuation -= FlickerLight;
    }
    public void FlickerLight()
    {
        _light.DOKill(false);
        Sequence sequence = DOTween.Sequence();
        foreach (float intensity in intensities)
        {
            sequence.Append(
                _light.DOIntensity(intensity,(minimumFlickerDuration + Random.Range(0, flickerDurationRandomness))).SetEase(easing)
                );
        }
        if (isFlickerEnabled)
        {
            sequence.OnComplete(() =>
            {
                FlickerLight();
            });
        }
    }
}
