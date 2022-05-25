using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DoorOpeningAnimation : MonoBehaviour
{
    [SerializeField] private float Time = 2;
    [SerializeField] protected float Force = 3;

    protected DoorOpeningStates _doorOpeningStates;
    protected NavMeshObstacle _navMeshObstacle;
    protected bool isDoorOpening = false;
    protected const bool _animationDisableObstacle = true;
    // Start is called before the first frame update
    void Start()
    {
        _doorOpeningStates = GetComponent<DoorOpeningStates>();
        _navMeshObstacle = GetComponent<NavMeshObstacle>();
    }

    public virtual void OpenDoor()
    {
        if (!isDoorOpening)
        {
            StartCoroutine(OpeningAnimation(Force, Time / 2.0f));
        }
       
    }
    public virtual void OpenDoor(float force)
    {
        if (!isDoorOpening)
        {
            StartCoroutine(OpeningAnimation(force, Time / 2.0f));
        }
    }
    public virtual void OpenDoor(float force, float time)
    {
        if (!isDoorOpening)
        {
            StartCoroutine(OpeningAnimation(force,time));
        }
    }
    private IEnumerator OpeningAnimation(float force, float time)
    {
        isDoorOpening = true;
        
        _doorOpeningStates.SetDoorOpening(force);

        yield return new WaitForSeconds(time);
        if (_animationDisableObstacle)
            _navMeshObstacle.enabled = false;

        yield return new WaitForSeconds(time/2);
        _doorOpeningStates.SetDoorClosing(force);

        yield return new WaitForSeconds(time*2);
        _doorOpeningStates.SetDoorNeutral();
        if (_animationDisableObstacle)
            _navMeshObstacle.enabled = true;


        isDoorOpening = false;
    }
    public bool getDoorOpening()
    {
        return isDoorOpening;
    }
}
