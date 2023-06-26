using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CanvasGroup))]
public class UIFade : MonoBehaviour
{
    [SerializeField] float fadeInDuration = 0.75f;
    [SerializeField] float fadeOutDuration = 0.25f;
    [SerializeField] Ease fadeEasing = Ease.InOutSine;

    private CanvasGroup _UIGroup = null;
    private bool _isFading = false;
    private Tween _currentTween;
    private void Start()
    {
        _UIGroup = GetComponent<CanvasGroup>();
    }
    // Start is called before the first frame update
    public void ShowUI()
    {
        if (_currentTween !=null)
        {
            //_currentTween.Kill(false);
            _currentTween.Kill(_isFading);//
        }
        ToogleHudInteraction(true);
        _UIGroup.DOFade(1, fadeInDuration)
            .SetEase(fadeEasing).OnComplete(() => { _isFading = false; });
    }
    public void ShowUINoFade()
    {
        if (_currentTween != null)
        {
            //_currentTween.Kill(false);
            _currentTween.Kill(_isFading);//
        }
        ToogleHudInteraction(true);
        _UIGroup.alpha = 1;
    }

    public void HideUI()
    {
        if (_currentTween != null)
        {
            //_currentTween.Kill(false);
            _currentTween.Kill(_isFading);//
        }
        ToogleHudInteraction(false);

        _UIGroup.DOFade(0, fadeOutDuration)
            .SetEase(fadeEasing)
            .OnComplete((TweenCallback)(() =>
            {
                _isFading = false;
            }));
    }
    public void HideUINoFade()
    {
        if (_currentTween != null)
        {
            //_currentTween.Kill(false);
            _currentTween.Kill(_isFading);//
        }
        ToogleHudInteraction(false);
        _UIGroup.alpha = 0;
    }
    private void ToogleHudInteraction(bool interact)
    {
        _UIGroup.interactable = interact;
        _UIGroup.blocksRaycasts = interact;
    }
}
