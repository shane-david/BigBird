using System.Numerics;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    //private data
    //-------------
    [SerializeField] private float moveSpeed = 0f; 
    [SerializeField] private float damage = -2f; 
    private float leftBound = 0f;

    //private methods
    //----------------
    private void Update()
    {
        Move(); 
    }

    private void Start()
    {
        leftBound = Camera.main.transform.position.x - Camera.main.orthographicSize * Camera.main.aspect; 
    }    //destroy and decrase player health 

    //if collision is a player get the script and damage it, destroy bullet
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.CompareTag("Player") && enabled)
        {   
            PlayerController player = collision.GetComponent<PlayerController>(); 
            player.ChangeHealth(damage); 
            Destroy(gameObject); 

        //if its a charge and its disable enable continoues daamge but do not destroy
        } else if (this.CompareTag("Charge") && collision.CompareTag("Player"))
        {   
            PlayerController player = collision.GetComponent<PlayerController>(); 
            player.EnableConstantDamage();  
        }

    }

    //if the player exits the charge disable constante damage
    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if (CompareTag("Charge") && collision.CompareTag("Player"))
        {
            PlayerController player = collision.GetComponent<PlayerController>(); 
            player.DisableConstantDamage(); 
        }
    }



    private void Move()
    {   
        //check if the bullet has moved off the screen
        if (transform.position.x < leftBound)
        {
            Destroy(gameObject); 
        }
        //move bullets left across the screen
        transform.position -= new UnityEngine.Vector3(moveSpeed * Time.deltaTime, 0f, 0f); 
    }
    
}
