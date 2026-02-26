using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class SceneLoaderScript : MonoBehaviour
{
    //SCENE FADING
    [SerializeField]
    private float sceneFadeDuration;

    [SerializeField]
    private SceneFader sceneFader;

    private SceneLoaderScript instance;

    //private static int lastGameplaySceneIndex;

    private void Awake()
    {
        //sceneFader = GetComponentInChildren<SceneFader>();
    }

    private IEnumerator Start()
    {
        yield return sceneFader.FadeInCoroutine(sceneFadeDuration);
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneCoroutine(sceneName));
    }

    private IEnumerator LoadSceneCoroutine(string sceneName)
    {
        yield return sceneFader.FadeOutCoroutine(sceneFadeDuration);
        yield return SceneManager.LoadSceneAsync(sceneName);
    }


    // CHANGE SCENE

    //Loading Scene Based On Name
    public void loadSceneByName (string sceneName)
    {
        Debug.Log("By Name");
        StartCoroutine(LoadSceneCoroutine(sceneName));
    }

    //Loading Scene Based On Index 
    public void loadSceneByIndex (int sceneIndex)
    {

        Debug.Log("By Index");
        SceneManager.LoadScene(sceneIndex);
    }

    //For Try Again Button from Game Over Scene
    public void ReloadCurrentScene()
    {
        Debug.Log("Reloading Current Scene");
        SceneManager.LoadScene("Fight");
    }

    
}
