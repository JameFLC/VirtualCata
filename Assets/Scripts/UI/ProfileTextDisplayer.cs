using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ProfileTextDisplayer : MonoBehaviour
{
    private void Start()
    {
        Init();
    }
    // Start is called before the first frame update
    public void Init()
    {
        TextMeshProUGUI text = GetComponent<TextMeshProUGUI>();
        text.text = "Profile " + ProfileStorageManager.instance.GetSimulatedProfileID().ToString();
    }
    
}
