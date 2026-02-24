using Unity.Mathematics;
using UnityEngine;

public class Lunge : Attack
{

    //private variables
    //------------------

    //what pase of the lunge attack it is currently in 
    private int phase = 1; 

    //array of move speeds for different phases 
    [SerializeField] private float[] moveSpeed;

    //transform of the enemy 
    [SerializeField] private Transform enemyTransform; 

    //left and right bounds of the camera
    private float leftBound = 0f;
    private float rightBound = 0f; 

    //start x position
    private float startPos; 
    
    //default constructor
    //-------------------
    Lunge()
    {
        AttackName = "Lunge"; 
    }

    //private methods
    //----------------

    private void OnEnable()
    {   
        //make sure enemyTransform exists
        if (enemyTransform == null)
        {
            Debug.LogError("Must select enemytransform!");
            return; 
        }

        //get left and right bounds of camera
        leftBound  = Camera.main.transform.position.x - Camera.main.orthographicSize * Camera.main.aspect; 
        rightBound = Camera.main.transform.position.x + Camera.main.orthographicSize * Camera.main.aspect; 

        //get start pos
        startPos = enemyTransform.position.x; 
    }
    

    private void Update()
    {
        Execute(); 
    }

    //overriden method
    //----------------
    public override void Execute()
    {   
 
        //do proper action depending on phase
        switch (phase)
        {   
            //move  the enemy back until it is off screen 
            case 1: 

                enemyTransform.position += enemyTransform.right * moveSpeed[phase-1] * Time.deltaTime; 

                if (enemyTransform.position.x - enemyTransform.GetComponent<SpriteRenderer>().size.x > rightBound)
                {
                    phase++; 
                }

                break; 

            //move the enemy through the scene until it is off screen
            case 2:

                enemyTransform.position -= enemyTransform.right * moveSpeed[phase-1] * Time.deltaTime; 

                if (enemyTransform.position.x + enemyTransform.GetComponent<SpriteRenderer>().size.x < leftBound)
                {
                    phase++; 
                }

                break; 

            //move the enemy to original position and finish 
            case 3:

                enemyTransform.position += enemyTransform.right * moveSpeed[phase-1] * Time.deltaTime; 

                if (enemyTransform.position.x >= startPos)
                {   
                    phase = 1; 
                    Debug.Log("Stopped Lunge");
                    onFinished();
                    enabled = false; 

                }

                break; 

        }
    }
}
