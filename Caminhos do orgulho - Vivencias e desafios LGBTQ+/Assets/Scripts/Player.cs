using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private bool isJumping;
    private bool doubleJump;
    private bool isFire;
    public GameObject bow;
    public Transform FirePoint;
    private float movement;
    public int Health = 3;

    private Rigidbody2D rig;
    private Animator anim;
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
        GameController.Instance.UpdatesLives(Health);
    }

    private void Update()
    {
        
        Jump();
        BowFire();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        float movement = Input.GetAxisRaw("Horizontal");
        rig.velocity = new Vector2(movement * speed, rig.velocity.y);

        if (movement > 0 )
        {
            if (!isJumping)
            {
                anim.SetInteger("transition", 1);
            }
            
            transform.eulerAngles = new Vector3(0,0,0);
        }

        if (movement < 0)
        {
            if (!isJumping)
            {
                anim.SetInteger("transition", 1);
            }
            
            transform.eulerAngles = new Vector3(0,180,0);
        }

        if (movement == 0 && !isJumping && !isFire)
        {
            anim.SetInteger("transition",0);
        }
        
        
            
    }
    
    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (!isJumping)
            {
                anim.SetInteger("transition", 2);
                rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                isJumping = true;
                doubleJump = true;
                AudioObserver.OnPlaySfxEvent("Jump");
                ParticleObserver.OnParticleSpwnEvent(transform.position);
                
            }

            else
            {
                if (doubleJump)
                {
                    anim.SetInteger("transition", 2);
                    rig.AddForce(new Vector2(0, jumpForce * 2), ForceMode2D.Impulse);
                    doubleJump = false;
                    AudioObserver.OnPlaySfxEvent("Jump");
                    ParticleObserver.OnParticleSpwnEvent(transform.position);
                }
            }
            
        }

        
    }

    public void IncreaseLife(int value)
    {
        Health += value;
        GameController.Instance.UpdatesLives(Health);
    }
    
    void BowFire()
    {
        StartCoroutine("Fire");
    }

    IEnumerator Fire()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            isFire = true;
            anim.SetInteger("transition", 3);
            GameObject Bow = Instantiate(bow,FirePoint.position,FirePoint.rotation);

            if (transform.rotation.y == 0)
            {
                Bow.GetComponent<Bow>().isRight = true;
            }

            if (transform.rotation.y == 180)
            {
                Bow.GetComponent<Bow>().isRight = false;
            }
            
            
            yield return new WaitForSeconds(0.2f);
            isFire = false;
            anim.SetInteger("transition", 0);
        }
    }

    public void Damage(int dmg)
    {
        Health -= dmg;
        GameController.Instance.UpdatesLives(Health);
        anim.SetTrigger("morrendo");
        
        if (Health <= 0)
        {
            
        }
        
        Debug.Log("bateu");
        if (transform.rotation.y == 0)
        {
            transform.position += new Vector3(-1, 1, 1);
        }
        
        if (transform.rotation.y == 180)
        {
            transform.position += new Vector3(1, 1, 1);
        }
        

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.layer == 8)
        {
            isJumping = false;

            transform.parent = coll.transform;
        }
         
        
    }

    private void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.layer == 8)
        {
            transform.parent = null;
        }
    }
}
    
    
          