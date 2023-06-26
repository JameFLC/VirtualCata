using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IODataRecorderManager : MonoBehaviour
{
    public static void EnableAllRecorders()
    {
        SetEnableAllRecorders(true);
    }
    public static void DisableAllRecorders()
    {
        SetEnableAllRecorders(false);
    }

    private static void SetEnableAllRecorders(bool enabled)
    {
        List<IODataRecorder> recorderList = getAllRecorders();
        
        foreach (var recorder in recorderList)
        {
            recorder.SetEnabled(enabled);
        }
    }
    public static List<IODataRecorder> getAllRecorders()
    {
        //List<IODataRecorder> recorderList = new List<IODataRecorder>(); // Reset list
        //
        //GameObject[] rootObjects = SceneManager.GetActiveScene().GetRootGameObjects();
        //
        //
        //foreach (var root in rootObjects)
        //{
        //    recorderList.AddRange(root.GetComponentsInChildren<IODataRecorder>(false)); // Get all IO Datarecorders
        //}

        List<IODataRecorder> recorderList = (FindObjectsOfType(typeof(IODataRecorder)) as IODataRecorder[]).ToList();

        Debug.Log($"There is {recorderList.Count} recorders detected in the scene");
        return recorderList;
    }
}
