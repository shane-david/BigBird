using System;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    //public variables 
    //----------------

    //objects to select
    public Camera mainCamera; 

    public float moveSpeed = 5.0f; 
    public float maxAttackCoolDown = 10f; 
    public float minAttackCoolDown = 4.0f; 

    //private variables 
    //-----------------
    private string attackHappening = "NONE"; 
    private float countDown = 0f; 
    private float upperBound = 0.0f;
    private float lowerBound = 0.0f; 

    //movement 
    private Vector2 startPos; 

    //private methods
    //---------------

    private void Start()
    {    
        //if the camera was not selected 
        if (mainCamera == null)
        {
            Debug.LogError("Camer not Found!");
            return; 
        }

        //initilaze startPos
        startPos = transform.position; 

        //get the camera upper and lower bounds 
        upperBound = mainCamera.transform.position.y + mainCamera.orthographicSize; 
        lowerBound = mainCamera.transform.position.y - mainCamera.orthographicSize; 
        Debug.Log("Upper Bound: " + upperBound + " Lower Bound: " + lowerBound); 

        //set the countdown properly when the object is crated 
        countDown = UnityEngine.Random.Range(minAttackCoolDown, maxAttackCoolDown+1); 
    }

    private void Update()
    {
        Move(); 
        Timer(); 
    }

    private void Timer()
    {   
        //if there is not an attack currently happening keep counting down 
        if (attackHappening == "NONE")
        {   
            //if there is time left 
            if ( countDown > 0 )
            {

                //else count down 
                countDown -= Time.deltaTime;

            } else
            {
                
                //pick a random attack to do 
                RandomizeAttack(); 

                //randomly generate a new attack cooldown
                countDown = UnityEngine.Random.Range(minAttackCoolDown, maxAttackCoolDown+1); 

            }
        }
    }

    private void RandomizeAttack()
    {

        Debug.Log("Randomized"); 

    }

    private void DoAttack()
    {
        
    }

    private void ShootBullet()
    {
        
    }

    private void SpawnBirds()
    {
        
    }

    private void ChargeAttack()
    {
        
    }

    private void Lunge()
    {
        
    }

    private void Move()
    {   
        //get a new Y position use Sin to get it to oscillate up and down
        float newY = startPos.y + Mathf.Sin(Time.time * moveSpeed) * upperBound;
        transform.position = new Vector2(startPos.x , newY);  
    }
}
