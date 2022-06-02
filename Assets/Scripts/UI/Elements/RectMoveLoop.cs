using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
[RequireComponent(typeof(RectTransform))]
public class RectMoveLoop : MonoBehaviour
{
    [SerializeField] float transformBegin = 0;
    [SerializeField] float transformEnd = -0.01f;
    [SerializeField] float loopDuration = 1f;
    [SerializeField] Ease loopEasing = Ease.InOutSine;
    [SerializeField] LoopType loopType = LoopType.Yoyo;
    private RectTransform _rectTransform;
    // Start is called before the first frame update
    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _rectTransform.anchoredPosition3D = new Vector3(_rectTransform.anchoredPosition3D.x, _rectTransform.anchoredPosition3D.y, transformBegin);
        _rectTransform.DOAnchorPos3DZ(transformEnd, loopDuration).SetLoops(-1, loopType).SetEase(loopEasing);
        ;
    }


}
