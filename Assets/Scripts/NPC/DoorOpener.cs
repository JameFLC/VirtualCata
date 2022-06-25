using UnityEngine;
using UnityEngine.AI;
public class DoorOpener : MonoBehaviour
{
    [SerializeField] private float updateDelay = 0.5f;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float openingDistance = 1.2f;

    private NavMeshAgent agent;
    private float lastTime = 0;
    private float heightOffset = 1;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= lastTime + updateDelay)
        {
            lastTime = Time.time;
            CheckDoorInPath();
        }

    }
    private void CheckDoorInPath()
    {
        
        Vector3[] pathCorners = agent.path.corners;
        Vector3 offset = new Vector3(0, heightOffset, 0);


        //Raycast along the agent path to detect if a door is in the way 
        for (int i = 0; i+1 < pathCorners.Length; i++)
        {
            Ray ray = new Ray(pathCorners[i] + offset, pathCorners[i + 1] - pathCorners[i]);

            float maxDistance = Vector3.Magnitude(pathCorners[i + 1] - pathCorners[i]);

            RaycastHit hit;
            
            if (Physics.Raycast(pathCorners[i] + offset, pathCorners[i + 1] - pathCorners[i], out hit, maxDistance, layerMask))
            {

                Debug.DrawRay(pathCorners[i] + offset, hit.point - offset - pathCorners[i], Color.red, updateDelay);


                // Calculate position in horizontal 2d plane to prevent issue with height differences
                float distance = CheckDoorDistance(hit);
            }
            else
            {
                Debug.DrawRay(pathCorners[i] + offset, pathCorners[i + 1] - pathCorners[i], Color.white, updateDelay);
            }
        }
    }

    private float CheckDoorDistance(RaycastHit hit)
    {
        Vector2 pos2d = new Vector2(transform.position.x, transform.position.z);
        Vector2 hit2d = new Vector2(hit.point.x, hit.point.z);
        float distance = Vector2.Distance(pos2d, hit2d);


        if (distance < openingDistance)
        {
            OpenDoor(hit.transform.gameObject);
        }

        return distance;
    }

    private void OpenDoor(GameObject door)
    {
        DoorOpeningAnimation[] doorOpeningAnimations = door.GetComponentsInChildren<DoorOpeningAnimation>();

        if (doorOpeningAnimations != null)
        {
            foreach (var doorOpeningAnimation in doorOpeningAnimations)
            {
                doorOpeningAnimation.OpenDoor();
            }
        }

    }
}
