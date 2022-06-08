using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class GlowingWallToggler : MonoBehaviour
{
    [SerializeField] float duration = 1;
    [SerializeField] Ease easing = Ease.OutBounce;

    private Collider[] _colliders;
    private Material _mat;
    // Start is called before the first frame update
    void Start()
    {
        _colliders = GetComponents<Collider>();
        _mat = GetComponent<MeshRenderer>().material;
    }
    public void ToggleWall(bool collision)
    {
        _mat.DOFloat((collision ? 1 : 0), "_Alpha", duration).SetEase(easing).OnComplete(() =>DisableCollisions(collision)) ;

    }
    private void DisableCollisions(bool collision)
    {
       foreach (var collider in _colliders)
        { collider.enabled = collision;
        }
    }
}
