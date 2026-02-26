using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private float delayTime = 25f;

    private string targetScene = "Fight";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("LoadNextScene", delayTime);
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(targetScene);
    }
}
