using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayerController : MonoBehaviour
{
    [Range(-10, 10f)] public float moveSpeed = 5f;
    public float maxSpeed = 10f; // 最大速度
    public float acceleration = 0.1f; // 加速度
    Rigidbody2D rb2D;
    private float v; // 当前垂直输入
    private float lastDirection = 0; // 最后的移动方向
    [HideInInspector] public float currentVerticalSpeed = 0.5f;

    // 计算屏幕的上下边界
    float screenTop;
    float screenBottom;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();

        // 计算屏幕的上下边界
        screenTop = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
        screenBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;

    }

    void Update()
    {
        float input = Input.GetAxis("Vertical");

        // 检测玩家是否有输入
        if (Mathf.Abs(input) > 0.01f)
        {
            lastDirection = Mathf.Sign(input); // 更新最后的方向
                                               // 逐渐增加速度，但不超过最大速度

            moveSpeed = Mathf.Min(moveSpeed + lastDirection*acceleration * Time.deltaTime, maxSpeed);
            //Debug.Log()
        }
        else
        {
            // 如果没有新的输入，保持当前速度和方向
            //moveSpeed = Mathf.Max(moveSpeed, 5f); // 可以调整为逐渐减速
        }

        // 使用最后的方向来更新速度
        v = lastDirection;
    }

    void FixedUpdate()
    {
        if (rb2D != null)
        {
            // 使用最后的方向和当前速度来设置Rigidbody的速度
            //rb2D.velocity = new Vector2(0, moveSpeed);

            if(rb2D.position.y >= screenTop || rb2D.position.y <= screenBottom)
            {

                // 获取角色的高度，以便在计算边界时考虑到角色的大小
                float playerHeight = GetComponent<SpriteRenderer>().bounds.size.y / 4;

                // 限制下一步位置，防止角色移出屏幕
                float nextVerticalPosition = Mathf.Clamp(rb2D.position.y, screenBottom + playerHeight, screenTop - playerHeight);

                // 应用计算后的位置
                rb2D.MovePosition(new Vector2(rb2D.position.x, nextVerticalPosition));
                //rb2D.velocity = new Vector2(0, 0);
                moveSpeed = 0;
            }
            else
            {
                rb2D.velocity = new Vector2(0, moveSpeed);

            }

        }
    }


}
