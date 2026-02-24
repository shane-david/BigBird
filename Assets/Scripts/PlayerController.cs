using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public Rigidbody2D rb;

    float horizontalMovement;
    float verticalMovement;
 

    // Update is called once per frame
    void Update()
    {

        rb.linearVelocity = new Vector2(horizontalMovement * speed, verticalMovement * speed);

    }

    public void Move(InputAction.CallbackContext context)
    {
        verticalMovement = context.ReadValue<Vector2>().y;
        horizontalMovement = context.ReadValue<Vector2>().x;
    }

}