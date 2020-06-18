using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private string sceneToLoadName;

public void LoadScene()
{
    StartCoroutine(Load());
}

private IEnumerator Load()
{
    var loadingScreenInstance = Instantiate(loadingScreen);
    //contains the Prefab
    var loadingAnimator = loadingScreenInstance.GetComponent<Animator>();

    var animationTime = loadingAnimator.GetCurrentAnimatorStateInfo(0).length;
    //getting the duration of our animations

    DontDestroyOnLoad(loadingScreenInstance);
    var loading = SceneManager.LoadSceneAsync(sceneToLoadName);
    //will open the scene once it is fully charged

    loading.allowSceneActivation = false;
    //we don't automatically load the scene when it's fully charged

    while (loading.progress < 0.9f)
    {
        yield return new WaitForSeconds(animationTime);
        //yield = waiting
    }

    loading.allowSceneActivation = true;
    loadingAnimator.SetTrigger("EndLoading");
}
}
