using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float force;
    bool isGround = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Wall.isGame)
        {
            if(Input.GetKeyDown(KeyCode.Space) && isGround)
            {
                isGround = false;
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, force));
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGround = true;
        }
    }
}
