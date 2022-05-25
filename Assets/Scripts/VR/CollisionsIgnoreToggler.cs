using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionsIgnoreToggler : MonoBehaviour
{

    [SerializeField] LayerMask layerMask1;
    [SerializeField] LayerMask layerMask2;

    private int _layer1 = 0, _layer2 = 0;

    private void Start()
    {
        _layer1 = GetLayerFromMask(layerMask1);
        _layer2 = GetLayerFromMask(layerMask2);
    }

    
    public void SetLayerCollisionIgnore(bool ignore)
    {
        Debug.Log("layer 1 value = " + _layer1 + " layer 2 value = " + _layer2);
        Physics.IgnoreLayerCollision(_layer1, _layer2, ignore);
    }
    public bool GetLayerCollisionIgnore()
    {
        Debug.Log("layer 1 value = " + _layer1 + " layer 2 value = " + _layer2);
        return Physics.GetIgnoreLayerCollision(_layer1, _layer2);
    }
    public void ToggleLayerCollisionIgnore()
    {
        SetLayerCollisionIgnore(!GetLayerCollisionIgnore());
    }



    private int GetLayerFromMask(LayerMask mask) // From zckhyt at http://answers.unity.com/answers/1131425/view.html
    {

        uint bitstring = (uint)mask.value;
        for (int i = 31; bitstring > 0; i--)
        {
            if (i < 0) break;
            if ((bitstring >> i) > 0)
            {
                bitstring = ((bitstring << 32 - i) >> 32 - i);
                return i;
            }
        }
        return -1;

    }
}
