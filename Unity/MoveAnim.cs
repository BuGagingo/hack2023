using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAnim : MonoBehaviour
{
    
    public float speed = 5;
    public float jumpForce = 4;

    //���ҧ�٧ѧ�֧ݧ�ߧ� �է�ҧѧӧ��� ��ӧ�֧ާ� ��֧���ߧѧا� ��ݧ֧է���ڧ� �ܧ�ާ��ߧ֧ߧ��:
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public GroundDetection gr;
    public Animator anim;

    void Update()
    {
        anim.SetBool("Running", false);
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * speed *  Time.deltaTime );
            sr.flipX = true;
            anim.SetBool("Running", true);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            sr.flipX = false;
            anim.SetBool("Running", true);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            Attack();
        }
        anim.SetBool("IsGrounded", gr.isGrounded);
        anim.SetFloat("SpeedY", rb.velocity.y);
    }
    public void Jump()
    {
        if (gr.isGrounded == true)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    public void Attack()
    {
        anim.SetTrigger("Attack");
    }
}
