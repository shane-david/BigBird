using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class BulletHome : MonoBehaviour
{
    //private variables 
    //-----------------
    [SerializeField] private float moveSpeed = 5; 
    [SerializeField] private float lifeSpan = 0f; 

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
