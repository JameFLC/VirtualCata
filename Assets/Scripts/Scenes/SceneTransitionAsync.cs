using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionAsync : SceneTransition
{

    public override void GoToNextScene() => StartCoroutine(LoadSceneAsync(GetBuildIndex() + 1));

    public override void GoToPreviousScene() => StartCoroutine(LoadSceneAsync(GetBuildIndex() - 1));

    public override void GoToSceneByIndex(int index) => StartCoroutine(LoadSceneAsync(index));

    public override void ReloadScene() => StartCoroutine(LoadSceneAsync(GetBuildIndex()));
    protected virtual IEnumerator LoadSceneAsync(int index)
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(ClampBuidIndexes(index), LoadSceneMode.Single);
        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        Debug.Log("Level " + GetSceneNameAtIndex(ClampBuidIndexes(index)) + " has been loaded async !");
    }
}
