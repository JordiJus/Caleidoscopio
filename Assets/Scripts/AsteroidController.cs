using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    [Range(0, 10f)] public float MinMoveSpeed = 1f;
    [Range(0, 10f)] public float MaxMoveSpeed = 10f;
    float moveSpeed;
    Rigidbody2D rb2D;
    private AsteroidSpawner Spawner;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        moveSpeed = UnityEngine.Random.Range(MinMoveSpeed, MaxMoveSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb2D.MovePosition(new Vector2(rb2D.position.x - moveSpeed * Time.fixedDeltaTime, rb2D.position.y));
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Asteroid in");
        if (collision.CompareTag("Hay"))
        {
            Destroy(gameObject);
        }
    }
    public void SetSpawner(AsteroidSpawner spawner)
    {
        Spawner = spawner;
    }
}
