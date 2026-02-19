using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void exitApplication() {

        if (Application.isEditor) //If App Is Running In Editor, Stop Playing The Scene
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else Application.Quit(); //If App Is Not Running In Editor, Quit The Application
    }

}
