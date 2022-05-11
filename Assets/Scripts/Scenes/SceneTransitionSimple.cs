using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneTransitionSimple : SceneTransition
{
    
    public override void GoToNextScene()
    {
        SceneManager.LoadScene(ClampBuidIndexes(GetBuildIndex() + 1));
    }
    public override void GoToPreviousScene()
    {
        SceneManager.LoadScene(ClampBuidIndexes(GetBuildIndex() - 1));
    }
    public override void GoToSceneByIndex(int index)
    {
        SceneManager.LoadScene(ClampBuidIndexes(index));
    }
    public override void ReloadScene()
    {
        SceneManager.LoadScene(GetBuildIndex());
    }
}
