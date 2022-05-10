using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XR.CoreUtils;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.AI;
public class BodyColliderUpdater : MonoBehaviour
{
    // Start is called before the first frame update

    private XROrigin _xrOrigin;
    private CharacterController _characterController;
    private CharacterControllerDriver _driver;
    private NavMeshObstacle _obstacle;

    private void Start()
    {
        _xrOrigin = GetComponent<XROrigin>();
        _characterController = GetComponent<CharacterController>();
        _driver = GetComponent<CharacterControllerDriver>();
        _obstacle = GetComponent<NavMeshObstacle>();
        if (_xrOrigin == null || _characterController == null || _driver == null)
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
        if (_xrOrigin == null || _characterController == null)
            return;

        var height = Mathf.Clamp(_xrOrigin.CameraInOriginSpaceHeight, _driver.minHeight, _driver.maxHeight);

        Vector3 center = _xrOrigin.CameraInOriginSpacePos;
        center.y = height / 2f + _characterController.skinWidth;

        _characterController.height = height;
        _characterController.center = center;

        if (_obstacle != null) // Update AI Collider
        {
            _obstacle.height = height;
            _obstacle.center = center;
        }
    }
}
