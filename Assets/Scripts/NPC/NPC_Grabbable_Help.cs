using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Grabbable_Help : MonoBehaviour
{
    [SerializeField] private Transform defaultTransform;
    [SerializeField] private NPC_SeekHelpAnimator npcSeekHelpBehaviour;

    [SerializeField] private Transform NPC_hurt;

    private bool _isGrabbed = false;
    // Start is called before the first frame update
    void Start()
    {
        transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        //if (!_isGrabbed)
        //    ResetTransform();
    }

    public void Grabbed()
    {
        Transform trans = null;
        trans.position = new Vector3(defaultTransform.position.x, 0, defaultTransform.position.z);
        npcSeekHelpBehaviour.FollowPlayer(trans);
        _isGrabbed = true;
    }

    public void Released()
    {
        ResetTransform();
        //NPC_hurt.position = new Vector3(defaultTransform.position.x, 0, defaultTransform.position.z);
        Transform trans = null;
        trans.position = new Vector3(defaultTransform.position.x, 0, defaultTransform.position.z);
        npcSeekHelpBehaviour.UnfollowPlayer(trans);
        _isGrabbed = false;
    }

    private void ResetTransform()
    {
        //GetComponent<Transform>().transform.position = defaultTransform.position;
        defaultTransform.position = GetComponent<Transform>().transform.position;
        //GetComponent<Transform>().transform.rotation = defaultTransform.rotation;
        defaultTransform.rotation = GetComponent<Transform>().transform.rotation;
        //GetComponent<Transform>().transform.localScale = defaultTransform.localScale;
        defaultTransform.localScale = GetComponent<Transform>().transform.localScale;
    }    
}


