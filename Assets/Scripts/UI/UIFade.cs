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

    private void Start()
    {
        _UIGroup = GetComponent<CanvasGroup>();
    }
    // Start is called before the first frame update
    public void ShowUI()
    {
        ToogleHudInteraction(true);
        _UIGroup.DOFade(1, fadeInDuration)
            .SetEase(fadeEasing).OnComplete(() => { _isFading = false; });
    }
    public void HideUI()
    {
        ToogleHudInteraction(false);

        _UIGroup.DOFade(0, fadeOutDuration)
            .SetEase(fadeEasing)
            .OnComplete((TweenCallback)(() =>
            {
                _isFading = false;
            }));
    }
    private void ToogleHudInteraction(bool interact)
    {
        _UIGroup.interactable = interact;
        _UIGroup.blocksRaycasts = interact;
    }
}
