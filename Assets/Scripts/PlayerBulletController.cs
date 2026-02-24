using UnityEngine;

public class PlayerBulletController : MonoBehaviour
{

    [SerializeField] public float bulletSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(bulletSpeed, 0, 0) * Time.deltaTime;
    }
}
