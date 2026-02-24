using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class BulletHome : MonoBehaviour
{
    //private variables 
    //-----------------
    [SerializeField] private float moveSpeed = 5; 
    [SerializeField] private float lifeSpan = 0f; 
    [SerializeField] private float damage = -2f; 

    //public variables
    //-----------------
    public Transform target; 

    //private methods
    //----------------

    private void Update()
    {
        Move(); 
        sLifespan(); 
    }

    //destroy and decrase player health 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {   
            PlayerController player = collision.GetComponent<PlayerController>(); 
            player.ChangeHealth(damage); 
            Destroy(gameObject); 
        }
    }

    private void Move()
    {   

        //get direction towards target
        Vector2 targetDirection = (target.position - transform.position).normalized; 

        //move towards target
        transform.position += (Vector3)(targetDirection*moveSpeed*Time.deltaTime); 
    }

    private void sLifespan()
    {
        if (lifeSpan > 0)
        {
            lifeSpan -= Time.deltaTime; 
        } else
        {
            Destroy(gameObject); 
        }
    }
    
}
