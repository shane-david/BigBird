using UnityEngine;
public class ExitGame : MonoBehaviour
{
    public void exitApplication() {

        Application.Quit(); //If App Is Not Running In Editor, Quit The Application
    }

}
