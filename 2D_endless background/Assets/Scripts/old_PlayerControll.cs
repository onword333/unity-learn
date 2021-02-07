using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oldPlayerControll : MonoBehaviour
{

    private Collider2D myCollider;
    private Rigidbody2D rb2d;

    [SerializeField] private Animator animator;
    [SerializeField] private bool isGrounded;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private float jumpForce;

    private bool isJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<Collider2D>();
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

        if (isJumping && isGrounded)
        {
            Vector2 movement = Vector2.up * jumpForce;
            rb2d.AddForce(movement, ForceMode2D.Impulse);
            animator.SetBool("isJump", true);   // включаем анимацию прыжка
            isGrounded = false;
        }
    }

    private void FixedUpdate() {}    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // проверяем, что игрок действительно прикоснулся к земле
        // т.е. к определенному объекту слой которого ground
        isGrounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround); 
        animator.SetBool("isJump", !isGrounded);
    }
}
