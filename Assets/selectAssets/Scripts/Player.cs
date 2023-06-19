using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    bool isJumping = false;
    bool canDoubleJump = false;
    float jumpPower = 3.5f;
     Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();
    }


    private void FixedUpdate()
    {
        if (rb.velocity.magnitude > 0)
        {
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.zero);
        }

 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            canDoubleJump = false;
            animator.SetBool("Ground", true);
            animator.SetTrigger("Ground");
           
        }
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isJumping)
            {
                Jump();
                canDoubleJump = true;
            }
            else if (canDoubleJump && isJumping)
            {
               
               Jump();
                canDoubleJump = false;
            }
        }
    }

    void Jump()
    {
        animator.SetTrigger("Jump");
        animator.SetBool("Ground", false);
        rb.velocity = Vector2.up * jumpPower;
        isJumping = true;

    }

}
