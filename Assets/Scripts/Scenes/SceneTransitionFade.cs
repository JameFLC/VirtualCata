using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneTransitionFade : SceneTransitionBase
{


    public override void GoToNextScene()
    {

        StartCoroutine(LoadSceneAsync(GetBuildIndex() + 1));
    }
    public override void GoToPreviousScene()
    {
        StartCoroutine(LoadSceneAsync(GetBuildIndex() - 1));
    }
    public override void GoToSceneByIndex(int index)
    {
        StartCoroutine(LoadSceneAsync(index));
    }

    public override void GoToSceneByChoice()
    {
        ProfileData profileData = ProfileFilesManager.LoadProfileData(ProfileStorageManager.instance.GetSimulatedProfileID());
        StartCoroutine(LoadSceneAsync(((int)profileData.hotelType) + 2));
    }


    public override void ReloadScene()
    {
        StartCoroutine(LoadSceneAsync(GetBuildIndex()));
    }
    IEnumerator LoadSceneAsync(int index)
    {
        ViewFader.instance.FadeIn();
        yield return new WaitForSeconds(ViewFader.instance.GetDuration());


        AsyncOperation loadingOperation = SceneManager.LoadSceneAsync(ClampBuidIndexes(index),LoadSceneMode.Single);

        while ( !loadingOperation.isDone)
        {

            yield return null;
        }


    }
}
