using UnityEngine;
using System.Collections;
public class LandManager : MonoBehaviour
{
    //create an array to hold all the objects
    public GameObject Land;
    
    //create an array to hold the spawn points
    public Transform SpawnPoint;
    public float SpawnRate = 5.0f;

    private void Start()
    {
        //start the coroutine
        //nameof converts RunWave into a string
        StartCoroutine(nameof(RunLand));
    }

    private void StartWave()
    {
        for (int i = 0; i < SpawnRate; i++)
        {
            //grab the random enemy and spawn it
            //transform.rotation positions the sprite in the right direction
            Instantiate(Land, SpawnPoint.position, Land.transform.rotation);
        }
    }
    
    //set up a coroutine to space out the spawning frequency
    private IEnumerator RunLand()
    {
        while (true)
        {
            StartWave();
            yield return new WaitForSeconds(SpawnRate);
        }
    }
}
