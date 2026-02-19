using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public Rigidbody2D rb;

    float horizontalMovement;
    float verticalMovement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        rb.linearVelocity = new Vector3(horizontalMovement * speed, verticalMovement * speed, rb.linearVelocity.y);

    }

    public void Move(InputAction.CallbackContext context)
    {
        verticalMovement = context.ReadValue<Vector2>().y;
        horizontalMovement = context.ReadValue<Vector2>().x;
    }

}