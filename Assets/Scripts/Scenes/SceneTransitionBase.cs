using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class SceneTransitionBase : MonoBehaviour
{
    public static SceneTransitionBase instance;
    protected virtual void Awake()
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

    public abstract void GoToNextScene();
    public abstract void GoToPreviousScene();
    public abstract void GoToSceneByIndex(int index);
    public abstract void GoToSceneByChoice();
    public abstract void ReloadScene();
    protected int ClampBuidIndexes(int index) => Mathf.RoundToInt(Mathf.Clamp(index, 0, GetMaxBuidIndex()));
    protected int GetBuildIndex() => SceneManager.GetActiveScene().buildIndex;
    protected int GetCurrentSceneIndex() => SceneManager.GetActiveScene().buildIndex;
    protected int GetMaxBuidIndex() => GetNumberOfScenes() - 1;
    protected int GetNumberOfScenes() => SceneManager.sceneCountInBuildSettings;
    protected string GetSceneNameAtIndex(int index)
    {
        return SceneManager.GetSceneByBuildIndex(index).name;
    }
    
}