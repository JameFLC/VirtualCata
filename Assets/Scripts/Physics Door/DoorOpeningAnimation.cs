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
            StartCoroutine(OpeningAnimation());
        }
       
    }

    private IEnumerator OpeningAnimation()
    {
        isDoorOpening = true;
        
        _doorOpeningStates.SetDoorOpening(Force);

        yield return new WaitForSeconds(Time/2.0f);
        if (_animationDisableObstacle)
            _navMeshObstacle.enabled = false;

        yield return new WaitForSeconds(Time/2.0f);
        _doorOpeningStates.SetDoorClosing(Force);

        yield return new WaitForSeconds(Time);
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
