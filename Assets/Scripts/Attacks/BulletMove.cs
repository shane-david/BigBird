using System.Numerics;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    //private data
    //-------------
    [SerializeField] private float moveSpeed = 0f; 
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
