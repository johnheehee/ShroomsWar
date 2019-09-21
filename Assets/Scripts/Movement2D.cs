using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jump = 7f;
    public bool isGrounded = false;
    public bool facingRight;
    public Animator animator;
    Vector3 crouchPos;

    void Start()
    {
        facingRight = true;
        crouchPos = transform.position;
    }

    void Update()
    {
        Jump();
        Crouch();
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontal, 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;
        if (horizontal > 0 && !facingRight)
        {
            Flip();
        }
        else if (horizontal < 0 && facingRight)
        {
            Flip();
        }
        Attack();
    }

    // allows the character to jump
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jump), ForceMode2D.Impulse);
            animator.SetBool("isJumping", true);
            SoundManagerScript.PlaySound ("jump");
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            animator.SetBool("isJumping", false);
        }
    }

    // allows the character to flip 
    void Flip()
    {
        //if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight) {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
        //Vector3 theScale = transform.localScale;
        // theScale.x *= -1;
        //  transform.localScale = theScale;
    }


    void Crouch()
    {

        if (Input.GetKeyDown(KeyCode.DownArrow) && isGrounded == true)
        {
            animator.SetBool("isCrouching", true);
            //crouchPos.y = -0.5f;
            //transform.position = crouchPos;
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            animator.SetBool("isCrouching", false);
        }
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.L) && Input.GetKeyDown(KeyCode.DownArrow) == false)
        {
            animator.SetBool("isAttacking", true);
        }
        else if (Input.GetKeyUp(KeyCode.L) && Input.GetKeyDown(KeyCode.DownArrow) == false)
        {
            animator.SetBool("isAttacking", false);
        }
    }
    // getting hit animation
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet2") {
            animator.SetBool("isHit", true);
        }
        else 
        animator.SetBool("isHit", false);
    }
}



