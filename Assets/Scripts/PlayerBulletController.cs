using UnityEngine;

public class PlayerBulletController : MonoBehaviour
{

    //speed and damage the bullet does 
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float damage = -2f; 



    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(bulletSpeed, 0, 0) * Time.deltaTime;
    }

    //damage enemy when collide
    private void OnTriggerEnter2D(Collider2D collision)
    {   

        //if we are are colling with the enemy decrease health and break
        if (collision.CompareTag("Enemy"))
        {   
            EnemyAI enemy = collision.GetComponent<EnemyAI>(); 
            enemy.SetHealth(damage); 
            Destroy(gameObject); 
        }
    }
}
