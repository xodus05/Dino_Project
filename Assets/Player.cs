using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpSpeed = 5f;    //점프 속도
    public bool isGrounded = false;
    public int jumpCount = 2; //점프횟수    2를 3으로 바꾸면 3단 점프
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //컴포넌트를 불러옴
        jumpCount = 0;
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = true;    //Ground에 닿으면 isGround는 true
            jumpCount = 2;          //Ground에 닿으면 점프횟수가 2로 초기화됨

        }

    }

    void Update()
    {
        if (isGrounded)
        {
            if (jumpCount > 0)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))   //입력키가 위화살표면 실행함
                {
                    rb.AddForce(new Vector2(0, 1) * jumpSpeed, ForceMode2D.Impulse); //위방향으로 올라가게함
                    jumpCount--;    //점프할때 마다 점프횟수 감소
                }
            }
        }
    }
}
