using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TextHoverMove : MonoBehaviour
{

    [SerializeField] float transformNormal = 0;
    [SerializeField] float transformHover = -0.02f;

    [SerializeField] private float duration = 1f;
    [SerializeField] private Ease easing = Ease.InOutSine;
    [SerializeField] private float overshoot = 0;


    private Vector3 _originalPosition = Vector3.zero;
    private Vector3 _destination = Vector3.zero;
    private RectTransform _rectTransform;
    private Tween _curentTween;
    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();

    }
    public void HoverEase()
    {
        KillCurrentTween();
        _curentTween = _rectTransform.DOAnchorPos3DZ(transformHover, duration).SetEase(easing,overshoot);
    }
    public void HoverSnap()
    {
        KillCurrentTween();
        _curentTween = _rectTransform.DOAnchorPos3DZ(transformHover, 0);
    }
    public void NormalEase()
    {
        KillCurrentTween();
        _curentTween = _rectTransform.DOAnchorPos3DZ(transformNormal, duration).SetEase(easing, overshoot);
    }
    public void NormalSnap()
    {
        KillCurrentTween();
        _curentTween = _rectTransform.DOAnchorPos3DZ(transformNormal, 0);
    }
    private void KillCurrentTween()
    {
        if (_curentTween != null)
        {
            _curentTween.Kill(false);
        }
    }
}
