using System;
using System.Collections.Generic;
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

    //array for attacks 
    [SerializeField] List<Attack> attacksPhase1; 


    //private variables 
    //-----------------

    //to determine what attack is happening
    private bool attackHappening = false; 

    //to determine what phase of the fight the player is in 
    //private int phase = 1; 

    //count down between attacks 
    private float countDown = 0f; 

    //movement 

    //track the enemy postion 
    private Vector2 startPos;

    //how tall the enemy is for bounds checking 
    private float height; 

    //how far from center of the enemy to top of the camera 
    private float upperBound = 0.0f;




    //private methods
    //---------------

    private void Start()
    {    
        //if the camera was not selected 
        if (mainCamera == null)
        {
            Debug.LogError("Camera Not Found!");
            return; 
        }

        //initilaze startPos (make sure they start at 0 on the y)
        transform.position = new Vector2(transform.position.x, 0); 
        startPos = transform.position;

        //initialize height and use it to set camera upper bound
        height = GetComponent<SpriteRenderer>().bounds.size.y; 
        upperBound = mainCamera.transform.position.y + mainCamera.orthographicSize - (height/2); 

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
        if (!attackHappening)
        {   
            //if there is time left 
            if ( countDown > 0 )
            {

                //else count down 
                countDown -= Time.deltaTime;

            } else
            {
                
                //ensure countdown is 0 for readability
                countDown = 0f; 
                
                //pick a random attack to do 
                RandomizeAttack(); 

                //randomly generate a new attack cooldown
                countDown = UnityEngine.Random.Range(minAttackCoolDown, maxAttackCoolDown+1); 

            }
        }
    }

    private void RandomizeAttack()
    {

        //TODO determine what list to pick from depending on phase 

        //get attack from list randomly
        Attack currentAttack = attacksPhase1[UnityEngine.Random.Range(0, attacksPhase1.Count)];
        Debug.Log(currentAttack.getAttackName() + " Selected"); 

        //enable attack (attack will handle its own disabling) 
        /*
         *NOTE: we are passing in a function that disables attackHappening
         *this is handled within each attack and is called at the end of every attack 
         *this ensures that the timer starts to count again after an attack finishes 
        */
        currentAttack.Begin(() => {attackHappening = false;}); 


    }

    private void Move()
    {   
        //get a new Y position use Sin to get it to oscillate up and down
        float newY = startPos.y + Mathf.Sin(Time.time * moveSpeed) * upperBound;

        //set the y position 
        transform.position = new Vector2(startPos.x , newY);  
    }
}
