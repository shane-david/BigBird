using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    private Rigidbody2D rb;
    public int timeAlive = 5;

    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, timeAlive);
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
