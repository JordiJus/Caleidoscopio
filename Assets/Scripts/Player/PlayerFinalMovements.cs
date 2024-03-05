using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFinalMovements : MonoBehaviour
{
    Rigidbody2D rb2D;
    SpriteRenderer spriteRenderer;
    public GameObject FirePrefab;
    private GameObject fireball;
    private SpriteRenderer fbSpriteRenderer;
    
    private float start;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb2D = GetComponent<Rigidbody2D>();

        
        
        fireball = Instantiate(FirePrefab, transform);
        
        fireball.transform.position = new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z);
        fbSpriteRenderer = fireball.GetComponent<SpriteRenderer>();
        

        start = Time.time;

    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Rotate(Vector3.forward * 0.1f);
        fireball.transform.Rotate(Vector3.forward * -0.1f);
        //fireball.transform.Rotate (Vector3.forward * -0.1f);
        if(spriteRenderer.color.a > 0.0f){
            spriteRenderer.color = new Color(1f, 1f, 1f, 1f-(Time.time-start)/20.0f);
        }
        if(Time.time-start >= 10.0f){
            if(fbSpriteRenderer.color.a < 1.0f){
            fbSpriteRenderer.color = new Color(1f, 1f, 1f, (Time.time-start-10.0f)/20.0f);
        }
        }
        
        if (rb2D != null)
        {
            // 使用最后的方向和当前速度来设置Rigidbody的速度
            rb2D.velocity = new Vector2(1*((Time.time-start)/20.0f), 0);
        }
        fireball.transform.position = new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z);
    }
}
