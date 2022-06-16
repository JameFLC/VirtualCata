using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ControllerHighlightManager : MonoBehaviour
{
    [SerializeField] GameObject body;
    [SerializeField] GameObject grip;
    [SerializeField] GameObject menu;
    [SerializeField] GameObject system;
    [SerializeField] GameObject trackpad;
    [SerializeField] GameObject trigger;
    [SerializeField] GameObject clockwiseArrow;
    [SerializeField] GameObject counterClockwiseArrow;

    [SerializeField] float duration = 0.2f;
    [SerializeField] Ease easing = Ease.OutBounce;



    public void SetBodyHighlight(float value) => SetHighlight(body, value);
    public void SetGripHighlight(float value) => SetHighlight(grip, value);
    public void SetMenuHighlight(float value) => SetHighlight(menu, value);
    public void SetSystemHighlight(float value) => SetHighlight(system, value);
    public void SetTrackpadHighlight(float value) => SetHighlight(trackpad, value);
    public void SetTriggerHighlight(float value) => SetHighlight(trigger, value);

    public void SetClockwiseHighlight(float value) => SetHighlight(clockwiseArrow, value);
    public void SetCounterClockwiseHighlight(float value) => SetHighlight(counterClockwiseArrow, value);

    private void SetHighlight(GameObject obj, float value)
    {
        Material mat = obj.GetComponent<MeshRenderer>().material;
        if (mat != null)
        {
            mat.DOFloat(value, "_EmissionMask", duration).SetEase(easing);
        }
    }
}
