using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NPC_DestinationSwitcher))]
public class NPC_DelayRandomiser : MonoBehaviour
{
    [SerializeField] private Vector2 delayRange = new Vector2(3, 5);
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<NPC_DestinationSwitcher>().updateDelay = Random.Range(delayRange.x, delayRange.y);

        Destroy(this);
    }

    
}
