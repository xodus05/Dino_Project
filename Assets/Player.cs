using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpPower = 5f;    //점프 높이
    public bool isGrounded = false;
    public int jumpCount = 2; //점프횟수    2를 3으로 바꾸면 3단 점프
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        jumpCount = 0;
        isGrounded = true;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "Ground") //충돌처리
        {
            isGrounded = true;
            jumpCount = 2;
            anim.SetBool("isJump", false);

        }

    }

    void Update()
    {
        //수그리기
        if (Input.GetKey(KeyCode.DownArrow))
        {
            anim.SetBool("isDown", true);
        }
        else
        {
            anim.SetBool("isDown", false);
        }

    }

    void FixedUpdate()
    {
        //무한점프 막기
        if (isGrounded)
        {
            if (jumpCount > 0)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    rb.AddForce(new Vector2(0, 1) * jumpPower, ForceMode2D.Impulse); //위로 점프
                    anim.SetBool("isJump", true);
                    jumpCount--;    //점프할때 마다 점프횟수 감소
                }
            }
        }
    }
}