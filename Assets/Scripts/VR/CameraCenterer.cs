using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCenterer : MonoBehaviour
{
    [SerializeField] private Camera cam;

    private void Update()
    {
        Vector3 camLocalPosition = cam.transform.localPosition;
        if (camLocalPosition != Vector3.zero)
        {
            camLocalPosition.y = 0;
            transform.localPosition -= camLocalPosition;
            Debug.Log("Centered Player");
            Destroy(this);
        }
    }
}
