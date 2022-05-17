using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeMover : MonoBehaviour
{
    [SerializeField] private Transform cameraOffset;
    // Start is called before the first frame update
    private void Start()
    {
        if (cameraOffset == null) Destroy(this);
    }
    // Update is called once per frame
    void Update()
    {
        // Position
        Vector3 newPosition = new Vector3(cameraOffset.position.x, transform.position.y, cameraOffset.position.z);
        transform.position = newPosition;

        //Rotation
        transform.rotation = Quaternion.Euler(0, cameraOffset.rotation.eulerAngles.y, 0);

    }
}
