using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XR.CoreUtils;
using UnityEngine.XR.Interaction.Toolkit;

public class BodyColliderUpdater : MonoBehaviour
{
    // Start is called before the first frame update

    private XROrigin xrOrigin;
    private CharacterController characterController;
    private CharacterControllerDriver driver;


    private void Start()
    {
        xrOrigin = GetComponent<XROrigin>();
        characterController = GetComponent<CharacterController>();
        driver = GetComponent<CharacterControllerDriver>();
        if (xrOrigin == null || characterController == null || driver == null)
        {
            Debug.LogError("Body Collider Updater missing component in game object " + this.name);
        }
    }
    // Update is called once per frame
    void Update()
    {
        UpdateCharacterController();
    }
    protected virtual void UpdateCharacterController()
    {
        if (xrOrigin == null || characterController == null)
            return;

        var height = Mathf.Clamp(xrOrigin.CameraInOriginSpaceHeight, driver.minHeight, driver.maxHeight);

        Vector3 center = xrOrigin.CameraInOriginSpacePos;
        center.y = height / 2f + characterController.skinWidth;

        characterController.height = height;
        characterController.center = center;
    }
}
