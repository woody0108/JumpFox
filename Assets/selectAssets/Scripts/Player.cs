using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    #region ΩÃ±€≈Ê
    private static Player instance;
    public static Player Instance
    {
        get { return instance; }
    }
    #endregion

    public int health = 100;
    public int maxHealth = 100;
    Rigidbody2D rb;
    bool isJumping = false;
    bool canDoubleJump = false;
    float jumpPower = 3.5f;
     Animator animator;

    private void Awake()
    {
        if (null == instance)
        {
            instance = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

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
