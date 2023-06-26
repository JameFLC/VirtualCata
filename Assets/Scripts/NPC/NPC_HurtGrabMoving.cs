using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_HurtGrabMoving : MonoBehaviour
{
    public List<Transform> waypoints;
    private Animator anim;
    public Transform player;
    public Transform grabbable;
    public float speed = 2;
    int index = 0;
    bool _isGrabbed = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dest = new Vector3(waypoints[index].transform.position.x, 0, waypoints[index].transform.position.z);
        Vector3 pos = Vector3.MoveTowards(transform.position, dest, speed * Time.deltaTime);
        transform.position = pos;

        //
        if (_isGrabbed)
        {
            waypoints.Add(player);
            index++;
        }
        else
        {
            waypoints.Clear();
            index = 0;
            waypoints.Add(transform);
            Vector3 positionNPC = new Vector3(transform.position.x, grabbable.position.y, transform.position.z);
            grabbable.position = positionNPC;
        }
        //
    }

    public void FollowGrab()
    {
        _isGrabbed = true;
        Debug.Log("Following the player");
        anim.SetTrigger("IsRunning");
        anim.SetFloat("Speed", 0.37f) ;
    }
    public void UnfollowGrab()
    {
        _isGrabbed = false;
        Debug.Log("Unfollowing the player");
        anim.SetTrigger("SeekHelp");
        anim.SetFloat("Speed", 0f);
    }

}