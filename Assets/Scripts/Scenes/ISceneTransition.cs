public interface ISceneTransition
{
    int GetCurrentSceneIndex();
    void GoToNextScene();
    void GoToPreviousScene();
    void GoToSceneByIndex(int index);
    void ReloadScene();
}