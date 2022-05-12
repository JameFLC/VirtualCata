using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class MoveTo : MonoBehaviour
{
    [SerializeField] private Transform destination;
    [SerializeField] private float duration = 3;
    [SerializeField] private Ease easing = Ease.InOutCirc;
    [SerializeField] private float overshoot = 0;


    private Vector3 _originalPosition = Vector3.zero;
    private Tween _curentTween;
    private void Start()
    {
        _originalPosition = transform.position;
    }
    public void BeginMoveEase()
    {
        KillCurrentTween();
        _originalPosition = transform.position;
        _curentTween = transform.DOMove(destination.position, duration).SetEase(easing, overshoot);
    }
    public void BeginMoveSnap()
    {
        KillCurrentTween();
        _originalPosition = transform.position;
        transform.position = destination.position;
    }
    public void ResetPositionEase()
    {
        KillCurrentTween();
        transform.DOMove(_originalPosition, duration).SetEase(easing, overshoot);
    }
    public void ResetPositionSnap()
    {
        KillCurrentTween();
        transform.position = _originalPosition;
    }
    private void KillCurrentTween()
    {
        if (_curentTween != null)
        {
            _curentTween.Kill(false);
        }
    }
}
