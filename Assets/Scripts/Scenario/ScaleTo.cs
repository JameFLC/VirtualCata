using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ScaleTo : MonoBehaviour
{
    public Vector3 scale = new Vector3(1,1,1);
    public float duration = 3;
    public Ease easing = Ease.InOutSine;
    public float overshoot = 0;


    private Vector3 _originalScale = Vector3.zero;
    private Tween _curentTween;
    private void Start()
    {
        _originalScale = transform.localScale;
    }
    public void BeginScaleEase()
    {
        KillCurrentTween();
        _curentTween = transform.DOScale(scale, duration).SetEase(easing, overshoot);
    }
    public void BeginScaleSnap()
    {
        KillCurrentTween();

        transform.localScale = scale;
    }
    public void ResetScaleEase()
    {
        KillCurrentTween();
        transform.DOScale(_originalScale, duration).SetEase(easing, overshoot);
    }
    public void ResetScaleSnap()
    {
        KillCurrentTween();
        transform.localScale = _originalScale;
    }
    private void KillCurrentTween()
    {
        if (_curentTween != null)
        {
            _curentTween.Kill(false);
        }
    }
}
