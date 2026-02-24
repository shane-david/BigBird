using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement; 
public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    [SerializeField] GameObject Bullet;
    public Rigidbody2D rb;

    float horizontalMovement;
    float verticalMovement;

    //health and max health and health bar 
    [SerializeField] private float health, maxHealth; 
    [SerializeField] private HealthBarUI healthBar; 

    //should the player be constantly damaged in update?
    private bool constantDamage = false; 

    //cooldown and time for player to not shoot constantly
    [SerializeField] private float shootCooldown;
    private float timer = 0f; 

 

    // Update is called once per frame
    void Update()
    {

        rb.linearVelocity = new Vector2(horizontalMovement * speed, verticalMovement * speed);

        //damage him slightly if constant damage is enabled
        if (constantDamage)
        {
            ChangeHealth(-.01f);
        }

        if (Input.GetButtonDown("FireBullet") && timer == 0)
        {   
            Instantiate(Bullet, transform.position, Quaternion.identity);
            timer = shootCooldown; 
        }

        if (timer > 0)
        {
            timer -= Time.deltaTime; 
        } else
        {
            timer = 0; 
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

        //check for health and go to game over if 0 
        if (health <= 0)
        {
            SceneManager.LoadScene("GameOver"); 
        }
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