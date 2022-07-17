using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SceneTransitionDebug : MonoBehaviour
{
    [SerializeField] private InputActionProperty nextSceneControl;
    [SerializeField] private InputActionProperty reloadSceneControl;
    [SerializeField] private InputActionProperty previousSceneControl;

    // Start is called before the first frame update
    void Start()
    {
        nextSceneControl.action.started += LoadNextScene;
        reloadSceneControl.action.started += ReloadScene;
        previousSceneControl.action.started += LoadPreviousScene;
    }
    private void OnDestroy()
    {
        nextSceneControl.action.started -= LoadNextScene;
        reloadSceneControl.action.started -= ReloadScene;
        previousSceneControl.action.started -= LoadPreviousScene;
    }



    private void LoadNextScene(InputAction.CallbackContext context)
    {
        if (Debug.isDebugBuild)
            SceneTransitionBase.instance.GoToNextScene();
    } 
    private void ReloadScene(InputAction.CallbackContext context)
    {
        if (Debug.isDebugBuild)
            SceneTransitionBase.instance.ReloadScene();
    }
    private void LoadPreviousScene(InputAction.CallbackContext context)
    {
        if (Debug.isDebugBuild)
            SceneTransitionBase.instance.GoToPreviousScene();
    }
}
