using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid;
    bool isJump = false;
    public float JP;
    // Start is called before the first frame update
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Jump
        if (Input.GetButtonDown("Jump"))
        {
            isJump = true;
        }
    }
    private void FixedUpdate()
    {
        Jump();
    }
    void Jump()
    {
        if (!isJump)
            return;

        rigid.velocity = Vector2.zero;

        Vector2 jumpVelocity = new Vector2(0, JP);
        rigid.AddForce(jumpVelocity, ForceMode2D.Impulse);

        isJump = false;
    }
}
