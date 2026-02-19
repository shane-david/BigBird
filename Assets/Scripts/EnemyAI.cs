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

    //list for randomization of attacks
    public enum AttackTypes { ShootBullet, SpawnBirds, ChargeAttack, Lunge }
    public List<AttackTypes> attacks = new(); 

    //private variables 
    //-----------------
    private string attackHappening = "NONE"; 
    private int phase = 1; 
    private float countDown = 0f; 
    private float upperBound = 0.0f;

    //movement 
    private Vector2 startPos; 
    private float height; 

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

        //initialize height 
        height = GetComponent<SpriteRenderer>().bounds.size.y; 

        //get the camera upper and lower bounds 
        upperBound = mainCamera.transform.position.y + mainCamera.orthographicSize - (height/2); 

        //set the countdown properly when the object is crated 
        countDown = UnityEngine.Random.Range(minAttackCoolDown, maxAttackCoolDown+1); 
    }

    private void Update()
    {
        Move(); 
        Timer(); 
        DoAttack(); 
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

        //randomly pick an attack
        var chosenAttack = attacks[UnityEngine.Random.Range(0, attacks.Count)]; 

        //set the current attack variable depening on result 
        switch (chosenAttack)
        {
            case AttackTypes.ShootBullet: 
                attackHappening = "ShootBullet";
                break; 
            case AttackTypes.SpawnBirds:
                attackHappening = "SpawnBirds";
                break;
            case AttackTypes.Lunge:
                attackHappening = "Lunge";
                break;
            case AttackTypes.ChargeAttack:
                attackHappening = "ChargeAttack";
                break; 
            default:
                Debug.LogError("Unknown Attack Type"); 
                break; 
        }

    }

    private void DoAttack()
    {
        switch(attackHappening)
        {
            case "ShootBullet":
                ShootBullet();
                break; 
            case "SpawnBirds":
                SpawnBirds();
                break;
            case "Lunge":
                Lunge();
                break;
            case "ChargeAttack":
                ChargeAttack();
                break; 
        }
    }

    private void ShootBullet()
    {
        Debug.Log("Shooting Bullet");
    }

    private void SpawnBirds()
    {
        Debug.Log("Spawning Birds");
        
    }

    private void ChargeAttack()
    {
        Debug.Log("Charging");
        
    }

    private void Lunge()
    {
        Debug.Log("Lunging");
    }

    private void Move()
    {   
        //get a new Y position use Sin to get it to oscillate up and down
        float newY = startPos.y + Mathf.Sin(Time.time * moveSpeed) * upperBound;
        transform.position = new Vector2(startPos.x , newY);  
    }
}
