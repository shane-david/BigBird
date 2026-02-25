using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    //create an array to hold all the objects
    public GameObject[] Rocks;
    
    //create an array to hold the spawn points
    public Transform SpawnPoints;
    public float SpawnRate = 5.0f;

    private void Start()
    {
        //start the coroutine
        //nameof converts RunWave into a string
        StartCoroutine(nameof(RunWave));
    }

    private void StartWave()
    {
        //select a random rock to spawn
        //pick a random number from 0 to end of the Rocks array
        var rockTypeIndex = Random.Range(0, Rocks.Length);
        //grab the random enemy and spawn it
        //transform.rotation positions the sprite in the right direction
        Instantiate(Rocks[rockTypeIndex], SpawnPoints.position, Rocks[rockTypeIndex].transform.rotation);
        
    }
    
    //set up a coroutine to space out the spawning frequency
    private IEnumerator RunWave()
    {
        while (true)
        {
            StartWave();
            yield return new WaitForSeconds(SpawnRate);
        }
    }
}
