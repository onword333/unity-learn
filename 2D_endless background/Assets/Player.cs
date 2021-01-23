using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField] private float jumpForce;
    [SerializeField] private Animator animator;

    private Rigidbody2D rb2d;
    private bool isJumping;
    private bool onGround = true;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // для PC
        isJumping = Input.GetButtonDown("Jump");

        // для mobile
        if (Input.touchCount > 0)
        {
            isJumping = true;
        }
    
        jump();
    }

    private void jump() 
    {
        if (isJumping && onGround)
        {
            Vector2 movement = Vector2.up * jumpForce;
            rb2d.AddForce(movement, ForceMode2D.Impulse);
            onGround = false;
            animator.SetBool("isJump", true);
        }        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        onGround = true;
        animator.SetBool("isJump", false);
    }
}
