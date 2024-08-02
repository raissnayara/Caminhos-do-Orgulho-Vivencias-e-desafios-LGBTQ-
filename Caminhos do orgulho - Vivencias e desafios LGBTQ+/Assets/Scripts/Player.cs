using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Ground Properties")] 
    public LayerMask groundLayer;

    public float groundDistance;
    public bool isGrounded;
    public Vector3[] footOffset;

    public float speed = 2f;
    public float jumpForce = 2f;
    private Rigidbody2D rb2d;
    private Vector2 movement;
    private float xVelocity;

    private int direction =1;
    private float originalXScale;

    RaycastHit2D leftCheck;
    RaycastHit2D rightCheck;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        originalXScale = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        movement = new Vector2(horizontal, 0);

        if (xVelocity * direction < 0)
        {
            Flip();
        }

        PhysicCheck();
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

    }

    private void FixedUpdate()
    {
        xVelocity = movement.normalized.x * speed;
        rb2d.velocity = new Vector2(xVelocity, rb2d.velocity.y);
    }

    private void Flip()
    {
        direction *= -1;
        Vector3 scale = transform.localScale;

        scale.x = originalXScale * direction;
        transform.localScale = scale;
    }

    private void PhysicCheck()
    {
        isGrounded = false;
        leftCheck = Raycast(new Vector2(footOffset[0].x, footOffset[0].y), Vector2.down, groundDistance, groundLayer);
       rightCheck = Raycast(new Vector2(footOffset[0].x, footOffset[0].y), Vector2.down, groundDistance, groundLayer);
       
       if (leftCheck || rightCheck)
       {
           isGrounded = true;
       }
       
    }

    private RaycastHit2D Raycast(Vector3 origin, Vector2 rayDirection, float length, LayerMask mask)
    {
        Vector3 pos = transform.position;
        RaycastHit2D hit = Physics2D.Raycast(pos + origin, rayDirection, length, mask);
        Color color = hit ? Color.red : Color.green;
        Debug.DrawRay(pos + origin, rayDirection * length, color);
        return hit;
    }
}
  