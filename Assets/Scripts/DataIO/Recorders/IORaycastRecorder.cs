using System.Globalization;
using UnityEngine;

public class IORaycastRecorder : IODataRecorder
{
    [SerializeField] Transform targetTransform;
    [SerializeField] Vector3 rayDirection = Vector3.forward;
    [SerializeField] LayerMask layerMask = 0;
    private float _lastTime = 0;

    private GameObject _lastGameObject = null;
    private float _lastObjectBeginTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        data = new IOStrings(dataName);

    }

    // Update is called once per frame
    void Update()
    {
        if (!_isEnabled)
            return;

        if (Time.time >= _lastTime + updateDelay)
        {
            _lastTime = Time.time;
            if (targetTransform != null)
            {
            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            const int MAX_DISTANCE = 70;
                if (Physics.Raycast(targetTransform.position, targetTransform.TransformDirection(rayDirection), out hit, MAX_DISTANCE, layerMask))
                {
                    Debug.DrawRay(targetTransform.position, targetTransform.TransformDirection(rayDirection) * hit.distance, Color.cyan, updateDelay);
                    //Debug.Log("Did Hit");
                    Debug.Log(hit);
                    CheckHit(hit);
                }
                else
                {

                    Debug.DrawRay(targetTransform.position, targetTransform.TransformDirection(rayDirection) * 1000, Color.red, updateDelay);
                    //Debug.Log("Did not Hit");
                }
            }
        }
    }
    void CheckHit(RaycastHit hit)
    {
        GameObject newGameObject = hit.collider.gameObject;
        Debug.Log(newGameObject);
        if (_lastGameObject == null)
        {
            _lastObjectBeginTime = Time.time;

        }
        if (newGameObject != _lastGameObject)
        {
            if (newGameObject != null )
            {
                if (_lastGameObject != null)
                    SaveData(_lastGameObject);

                _lastGameObject = newGameObject;
                _lastObjectBeginTime = Time.time;
            }
        }
    }
    void SaveData(GameObject gameObject)
    {

        string itemString = gameObject.name + " from [" + _lastObjectBeginTime.ToString("F" + 2, CultureInfo.InvariantCulture) + "] to [" + Time.time.ToString("F" + 2, CultureInfo.InvariantCulture) + "]";
        Debug.Log(itemString);
        IODataUnit currentData = new IODataUnit(itemString);
        data.AddData(currentData);
    }
}
