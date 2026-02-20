using System.Collections.Generic;
using UnityEngine;

public class SpawnBirds : Attack
{
    //private data
    //------------
    [SerializeField] private int numBirds = 0; 
    private int birdCount; 
    [SerializeField] private float birdTimer = 0f; 
    private int birdTrails = 0; 
    private float increment = 0f; 
    private bool birdsSpawned;
    [SerializeField] private List<GameObject> birds = new(); 
    private float cameraSize = 0f; 

    //public data
    //------------
    public GameObject birdPrefab; 
    public Camera mainCamera; 

    //default constructor
    //-------------------
    SpawnBirds()
    {
        AttackName = "ShootBirds"; 
    }

    //private methods
    //----------------

    private void OnEnable()
    {   
        //check that the bird prefab exists
        if (birdPrefab == null)
        {
            Debug.LogError("Must select bird prefab!");
            return; 
        }

        //check that the camera exists
        if (mainCamera == null)
        {
            Debug.LogError("Must select camera!");
            return;
        }

        //set birds spawned to false when enables so that it starts spawning birds
        birdsSpawned = false; 

        //set birdCount, this needs to be set to the user selected value each time so that it knows
        //when to stop the second time the move is activated
        birdCount = numBirds; 

        //random amount of bird trails
        birdTrails = UnityEngine.Random.Range(1,5);

        //get the increment between bird trails based on number and height of screen
        cameraSize = mainCamera.orthographicSize * 2f;
        increment = cameraSize / (birdTrails+1); 

        //set timer for first value 
        timer = birdTimer; 

    }

    private void Update()
    {
        DestroyBirds();
        Execute(); 
    }

    //removes any birds that are null from the list
    //birds become null when they are destroyed which is handled in their own script
    //this list simply exists so we know when to end the attack because 
    //all of the birds it spawend are no longer on screen 
    private void DestroyBirds()
    {
        birds.RemoveAll(bird => bird == null); 
    }

    //overriden method
    //----------------
    public override void Execute()
    {
        
        //if the birds have not already been spawned, start spawning them
        if (!birdsSpawned)
        {
            
            //if it is not time to spawn a bird decrease timer
            if (timer > 0)
            {

                timer -= Time.deltaTime; 

            //if it is time spawn birds
            } else 
            {   
                //restore the timer for next bird
                timer = birdTimer; 

                //spawn bird on each trail for the number of birds per trail
                for (int i = 0; i < birdTrails; i++)
                {
                    //instatiate bird at players x postion and changin y position depening on increment and for loop iteration 
                    GameObject bird = Instantiate(birdPrefab, new Vector2(transform.position.x, (cameraSize / 2) - ((i+1) * increment)), Quaternion.identity); 

                    //add bird to list
                    birds.Add(bird); 
                }

                //decrease numbirds so that we know when to stop 
                birdCount--; 

                //if numbirds is 0 we know all the birds have been spawned
                if (birdCount == 0)
                {
                    birdsSpawned = true; 
                }
            }

        //otherwise all birds have been spawned and we just need to check if all have been destroyed 
        } else
        {   

            //if there are no more birds disable the attack and finish 
            if (birds.Count == 0)
            {   
                Debug.Log("Stopped Birds"); 
                onFinished();
                enabled = false; 
            }

        }
    }

}
