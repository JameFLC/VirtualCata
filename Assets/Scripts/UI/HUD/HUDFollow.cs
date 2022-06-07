using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDFollow : MonoBehaviour
{

    [SerializeField] private Camera cam;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float rotationspeed = 3;
    [SerializeField] private float heightSpeed = 4;

    private Transform _camTransform;
    // Start is called before the first frame update
    private void Start()
    {
        if (cam == null)
            Destroy(this);

        _camTransform = cam.gameObject.transform;

    }
    // Update is called once per frame
    void Update()
    {
        RotateAllongCamera();
        MoveAlongCamera();
    }
    void MoveAlongCamera()
    {
        float playerHeight = characterController.height;
        float camHeight = _camTransform.position.y;

        float middleHeight = camHeight - playerHeight/2;

        float newHeight = Mathf.Lerp(transform.position.y, middleHeight, Time.deltaTime * heightSpeed);

        transform.position = new Vector3(_camTransform.position.x, newHeight, _camTransform.position.z);
    }


    void RotateAllongCamera()
    {
        var newAngle = Mathf.LerpAngle(transform.rotation.eulerAngles.y, _camTransform.rotation.eulerAngles.y, Time.deltaTime * rotationspeed);
        transform.rotation = Quaternion.Euler(new Vector3(0, newAngle, 0));
    }
}
