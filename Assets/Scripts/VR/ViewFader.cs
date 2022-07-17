using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ViewFader : MonoBehaviour
{
    [HideInInspector]
    public static ViewFader instance;

    [SerializeField] float duration = 0.5f;
    [SerializeField] Ease easing = Ease.OutBounce;


    private MeshRenderer _meshRenderer;
    private Material _mat;
    protected void Awake()
    {
        instance = this;

        _meshRenderer = GetComponent<MeshRenderer>();

        _mat = _meshRenderer.material;


        Color newColor = new Color(0, 0, 0, 1);

        _mat.DOColor(newColor, 0);

        EventManager.instance.OnPlayerCentered += FadeOut;
        StartCoroutine(FadeOutBackup());
    }
    private void OnDestroy()
    {
        EventManager.instance.OnPlayerCentered -= FadeOut;
    }

    public void FadeIn()
    {
        FadeTo(1);
    }
    public void FadeOut()
    {
        FadeTo(0);
    }
    public void FadeTo(float alpha)
    {

        Debug.Log("Begining Fading");
        
        Color newColor = new Color(0, 0, 0, alpha);
        _mat.DOColor(newColor, duration).SetEase(easing);

    }
    public float GetDuration()
    {
        return duration;
    }

    private IEnumerator FadeOutBackup()
    {
        yield return new WaitForSeconds(5);
        FadeOut();
    }
}
