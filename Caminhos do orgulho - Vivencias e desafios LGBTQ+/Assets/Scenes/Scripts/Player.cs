using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 2f;

    private Rigidbody2D rb2d;

    private Vector2 movement;

    private float xVelocity;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        movement = new Vector2(horizontal, 0);
    }

    private void FixedUpdate()
    {
        xVelocity = movement.normalized.x * speed;
        rb2d.velocity = new Vector2(xVelocity, rb2d.velocity.y);
    }
}
  