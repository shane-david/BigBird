using System.Numerics;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    //private data
    //-------------
    [SerializeField] private float moveSpeed = 0f; 

    //private methods
    //----------------
    private void Update()
    {
        Move(); 
    }

    private void Move()
    {   
        //move bullets left across the screen
        transform.position -= new UnityEngine.Vector3(moveSpeed * Time.deltaTime, 0f, 0f); 
    }

    
}
