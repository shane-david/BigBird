using UnityEngine;

public class BirdSelection : MonoBehaviour
{

    public void SelectBird(string birdName)
    {
        // This method can be called when the player selects a bird from the UI.
        Debug.Log("Selected bird: " + birdName);
        
    }
}
