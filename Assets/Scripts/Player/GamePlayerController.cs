using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayerController : MonoBehaviour
{
    public PlayerStats playerStats;
    [Range(-10, 10f)] public float moveSpeed = 5f;
    public float maxSpeed = 10f; 
    public float acceleration = 0.1f; 
    Rigidbody2D rb2D;
    private float v; 
    private float lastDirection = 0; 
    [HideInInspector] public float currentVerticalSpeed = 0.5f;
    public Animator animator;


    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        animator.SetBool("GoingUp", true);
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float input = Input.GetAxis("Vertical");

        if (Mathf.Abs(input) > 0.01f)
        {
            lastDirection = Mathf.Sign(input); 

            moveSpeed = Mathf.Min(moveSpeed + lastDirection*acceleration * Time.deltaTime, maxSpeed);
            //Debug.Log()
        }

        v = lastDirection;

        if (lastDirection > 0.0f) {
            animator.SetBool("GoingUp", true);
        } else {
            animator.SetBool("GoingUp", false);
        }

        transform.Rotate (Vector3.forward * 0.1f);
    }

    void FixedUpdate()
    {
        if (rb2D != null)
        {
            // 使用最后的方向和当前速度来设置Rigidbody的速度
            rb2D.velocity = new Vector2(0, moveSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Asteroid in");
        if (collision.CompareTag("Asteroid"))
        {
            playerStats.health--;
            Debug.Log(playerStats.health);
            Destroy(collision.gameObject);
        }
    }


}
