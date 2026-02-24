using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    [SerializeField] GameObject Bullet;
    public float speed = 5.0f;
    public Rigidbody2D rb;

    float horizontalMovement;
    float verticalMovement;

    //health and max health and health bar 
    [SerializeField] private float health, maxHealth; 
    [SerializeField] private HealthBarUI healthBar; 

    //should the player be constantly damaged in update?
    private bool constantDamage = false; 
 

    // Update is called once per frame
    void Update()
    {

        rb.linearVelocity = new Vector2(horizontalMovement * speed, verticalMovement * speed);

        //damage him slightly if constant damage is enabled
        if (constantDamage)
        {
            ChangeHealth(-.01f);
        }
    }

    //initialize health and chekc that prefab exists
    private void Start()
    {   

        //make sure health bar exists and error if not 
        if (healthBar == null)
        {
            Debug.LogError("Must select health bar!"); 
            return; 
        }

        //set the maxhealth of the health bar for UI purposes
        healthBar.SetMaxHealth(maxHealth); 
        if (Input.GetButtonDown("FireBullet"))
        {
            Instantiate(Bullet, transform.position, Quaternion.identity);
        }

    }

    public void Move(InputAction.CallbackContext context)
    {
        verticalMovement = context.ReadValue<Vector2>().y;
        horizontalMovement = context.ReadValue<Vector2>().x;
    }

    //decrease player's health variable by the change
    //update the health bar to show changes
    public void ChangeHealth(float change)
    {
        health += change; 
        healthBar.SetHealth(health); 
    }

    public void EnableConstantDamage()
    {
        this.constantDamage = true; 
    }

    public void DisableConstantDamage()
    {
        this.constantDamage = false; 
    }

}