using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneTransitionSimple : MonoBehaviour, ISceneTransition
{
    public static SceneTransitionSimple instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            //Rest of Awake
        }
        else
        {
            Destroy(this);
        }
    }
    public int GetCurrentSceneIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
    public void GoToNextScene()
    {
        SceneManager.LoadScene(ClampBuidIndexes(GetBuildIndex() + 1));
    }
    public void GoToPreviousScene()
    {
        SceneManager.LoadScene(ClampBuidIndexes(GetBuildIndex() - 1));
    }
    public void GoToSceneByIndex(int index)
    {
        SceneManager.LoadScene(ClampBuidIndexes(index));
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(GetBuildIndex());
    }

    private int GetBuildIndex() => SceneManager.GetActiveScene().buildIndex;
    private int GetNumberOfScenes() => SceneManager.sceneCountInBuildSettings;
    private int GetMaxBuidIndex() => GetNumberOfScenes() - 1;
    private int ClampBuidIndexes(int index) => Mathf.RoundToInt(Mathf.Clamp(index, 0, GetMaxBuidIndex()));
}
