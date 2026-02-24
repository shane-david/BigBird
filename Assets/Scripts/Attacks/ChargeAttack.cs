using System;
using UnityEngine;

public class ChargeAttack : Attack
{
    
    //private variables
    //------------------
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float maxSize = 0f; 
    [SerializeField] private float growSpeed = 0f; 

    //our particular charge instance
    [SerializeField]private GameObject bigBullet; 


    //constructor
    //-----------
    ChargeAttack()
    {
        AttackName = "Charge"; 
    }

    //private methods
    //---------------
    private void OnEnable()
    {
        
        //make sure bullet prefab exists
        if (bulletPrefab == null)
        {
            Debug.LogError("Bullet prefab must exist!");
            return; 
        }


        //instantiate a bullet at the transform
        bigBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity); 

        //remove the moving script from the instance 
        bigBullet.GetComponent<BulletMove>().enabled = false; 

    }

    private void Update()
    {
        Execute(); 
    }


    //overriden method
    //----------------
    public override void Execute()
    {
        
        //if we are not at the max size grow 
        if (bigBullet.transform.localScale.x < maxSize)
        {
            bigBullet.transform.localScale += new Vector3(growSpeed, growSpeed, 0f); 

        //once we reach max size grow and exit 
        } else if (bigBullet != null)
        {
            //remove the moving script from the instance 
            bigBullet.GetComponent<BulletMove>().enabled = true;

            Debug.Log("Stopped Charge");
            onFinished();
            enabled = false; 
        }

    }

}
