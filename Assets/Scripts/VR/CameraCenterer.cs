using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCenterer : MonoBehaviour
{
    [SerializeField] private Transform cam;
    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = new Vector3(-cam.position.x, transform.position.y, -cam.position.z);
    }
}
