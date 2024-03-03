using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayController : MonoBehaviour
{
    [Range(0, 10f)] public float moveSpeed = 5f;
    Rigidbody2D rb2D;
    private float v, h;
    [HideInInspector] public float currentHorizontalSpeed = 05f;
    [HideInInspector] public float currentVerticalSpeed = 05f;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        currentHorizontalSpeed = Mathf.Max(0, moveSpeed * h);
        currentVerticalSpeed = Mathf.Max(0, moveSpeed * h);

        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        float temp_speed = Mathf.Max(Mathf.Abs(h), Mathf.Abs(v));
    }
    private void FixedUpdate()
    {
        if(rb2D != null)
        {
            rb2D.velocity = new Vector2(moveSpeed * h, moveSpeed * v);
        }
    }
}
