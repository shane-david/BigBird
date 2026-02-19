using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoaderScript : MonoBehaviour
{
    //Loading Scene Based On Name
    public void loadSceneByName (string sceneName)
    {
        Debug.Log("By Name");
        SceneManager.LoadScene(sceneName);
    }

    //Loading Scene Based On Index 
    public void loadSceneByIndex (string sceneIndex)
    {

        Debug.Log("By Index");
        SceneManager.LoadScene(sceneIndex);
    }

    //For Try Again Button from Game Over Scene
    public void ReloadCurrentScene()
    {
        Debug.Log("Reloading Current Scene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
