using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(NPC_DestinationSwitcher))]
public class NPC_SeekHelpAnimator : MonoBehaviour
{
    [SerializeField] Transform player;
    private Animator _anim;
    private NPC_DestinationSwitcher _destinationSwitcher;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _destinationSwitcher = GetComponent<NPC_DestinationSwitcher>();
    }

    public void SeekHelp()
    {
        _anim.SetTrigger("SeekHelp");
    }
    public void FollowPlayer()
    {
        List<Transform> newDestinations = new List<Transform>();
        newDestinations.Add(player);
        _destinationSwitcher.evacuationWaypoints = newDestinations;
        _destinationSwitcher.updateDelay = 1;
        
    }
}
