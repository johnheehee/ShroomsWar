using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Move : MonoBehaviour
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
        float horizontal = Input.GetAxis("Horizontal_2");
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
        if (Input.GetKeyDown(KeyCode.W) && isGrounded == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jump), ForceMode2D.Impulse);
            animator.SetBool("isJumping", true);
            SoundManagerScript.PlaySound ("jump");
        }
        else if (Input.GetKeyUp(KeyCode.W))
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

        if (Input.GetKeyDown(KeyCode.S) && isGrounded == true)
        {
            animator.SetBool("isCrouching", true);
            //crouchPos.y = -0.5f;
            //transform.position = crouchPos;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("isCrouching", false);
        }
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            animator.SetBool("isAttacking", true);
        }
        else if (Input.GetKeyUp(KeyCode.B))
        {
            animator.SetBool("isAttacking", false);
        }
    }
}



