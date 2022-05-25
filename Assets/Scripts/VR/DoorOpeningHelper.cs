using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CollisionsIgnoreToggler),typeof(DoorOpeningAnimation))]
public class DoorOpeningHelper : MonoBehaviour
{
    [SerializeField] float collisionWaitTime = 0.75f;
    [SerializeField] float helperForce = 1;
    [SerializeField] float helperDuration = 3;

    private CollisionsIgnoreToggler _collisionsIgnoreToggler;
    private DoorOpeningAnimation _doorOpeningAnimation;
    private bool _isDoorGrabbed = false;


    // Start is called before the first frame update
    void Start()
    {
        _collisionsIgnoreToggler = GetComponent<CollisionsIgnoreToggler>();
        _doorOpeningAnimation = GetComponent<DoorOpeningAnimation>();
    }

    public void SetDoorGrabbed(bool grabbed)
    {
        _isDoorGrabbed = grabbed;
        Debug.Log("Door grabbed = " + _isDoorGrabbed);

        if (grabbed)
        {
            Debug.Log("Ignore collisions");
            SetDoorCollisionIgnore(true);
            
        }
        else
        {
            Debug.Log("Start coroutine");
            StartCoroutine(CollisionWait());
            _doorOpeningAnimation.OpenDoor(helperForce,helperDuration);
        }

    }

    private void SetDoorCollisionIgnore(bool ignore) => _collisionsIgnoreToggler.SetLayerCollisionIgnore(ignore);

    IEnumerator CollisionWait()
    {
        Debug.Log("coroutine started");
        yield return new WaitForSeconds(collisionWaitTime);
        Debug.Log("Door grabbed = " + _isDoorGrabbed);
        if (!_isDoorGrabbed)
        {
            Debug.Log("Enable collisions");
            SetDoorCollisionIgnore(false);
        }
    }
}
