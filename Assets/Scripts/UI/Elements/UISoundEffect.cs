using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class UISoundEffect : MonoBehaviour
{
    [SerializeField] private AudioClip hoverInSound;
    [SerializeField] private AudioClip hoverOutSound;
    [SerializeField] private AudioClip clickSound;

    private AudioSource _source;
    // Start is called before the first frame update
    void Start()
    {
        _source = GetComponent<AudioSource>();
    }

    public void HoverInSound()
    {
        if (hoverInSound) _source.PlayOneShot(hoverInSound);
    }
    public void HoverOutSound()
    {
        if (hoverOutSound) _source.PlayOneShot(hoverOutSound);
    }
    public void ClickSound()
    {
        if (clickSound) _source.PlayOneShot(clickSound);
    }
}
