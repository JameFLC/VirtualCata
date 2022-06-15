
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class ObjectDestroyer : MonoBehaviour
{
    [SerializeField] private SingleUnityLayer layer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == layer.LayerIndex)
        {
            Debug.Log(other.gameObject + " is being destroyed");
            Destroy(other.gameObject);
            
        }
    }
}


