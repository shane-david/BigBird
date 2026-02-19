using System;
using Unity.Mathematics;
using UnityEngine;

public class ShootBullets : Attack
{
    //serialized variables
    //--------------------

    //max and min amounts of time the attack can last 
    [SerializeField] private float maxTime = 0f;
    [SerializeField] private float minTime = 0f; 

    //time inbetween shots
    [SerializeField] private float shotTime = 0f; 

    //normal bullet prefab
    [SerializeField] private GameObject bulletPrefab; 

    //homing bullet prefab
    [SerializeField] private GameObject bulletHomePrefab; 

    //player prefab for homing bullets
    [SerializeField] private Transform playerTransform; 

    //private variables
    //-----------------

    //countdown timer for when to shoot
    private float shotCountdown; 

    //default constructor
    //-------------------
    ShootBullets()
    {
        AttackName = "ShootBullets"; 
    }

    //private methods
    //---------------

    //initalize attack (onEnable() instead of start because it is enabled each time we want it to happen)
    private void OnEnable()
    {
        //set the timer to a random amount of seconds bullets will be shot for 
        timer = UnityEngine.Random.Range(minTime, maxTime); 

        //set the shotCountdown 
        shotCountdown = shotTime; 

        //make sure bullet prefabe exists
        if (bulletPrefab == null)
        {
            Debug.LogError("Need to Define Bullet Prefab!");
            return; 
        }

        //TODO make sure homing bullet prefab exists
    }

    private void Update()
    {
        Execute(); 
    }

    //overriden method
    //----------------

    //spawn bullets for random amount of seconds 
    public override void Execute()
    {       

        //if the attack is still in execution time
        if (timer > 0)
        {
            //decrease timer 
            timer -= Time.deltaTime; 

            //countdown for shot timer 
            if (shotCountdown > 0)
            {

                shotCountdown -= Time.deltaTime; 

            //once it runs out we need to shoot
            } else
            {
                
                //reset shot count down
                shotCountdown = shotTime; 

                var bulletRng = UnityEngine.Random.Range(0,4); 

                //if the rng hits create homeing bullet
                if (bulletRng == 3) {

                    //create homing bullet and set target transform
                    GameObject bullet = Instantiate(bulletHomePrefab, transform.position, Quaternion.identity);
                    bullet.GetComponent<BulletHome>().target = playerTransform; 

                //otherwise create normal bullet
                } else
                {
                    GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                }
            }

        //once timer is 0 disable the attack and call callback method
        } else
        {
            Debug.Log("Stopped Shooting"); 
            enabled = false; 
            onFinished(); 
        }
    }
}
