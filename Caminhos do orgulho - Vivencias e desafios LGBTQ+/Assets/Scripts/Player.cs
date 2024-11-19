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
    private AudioSource SoundJump;
    private AudioSource SoundWalk;

    public Vector3 posInicial;
    

    private Rigidbody2D rig;
    private Animator anim;
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
        GameController.Instance.UpdatesLives(Health);
        posInicial = new Vector3(-6.91f, -3.22f, 0);
        transform.position = posInicial;
        SoundJump = GetComponent<AudioSource>();
        SoundWalk = GetComponent<AudioSource>();

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
        movement = Input.GetAxisRaw("Horizontal");
        rig.velocity = new Vector2(movement * speed, rig.velocity.y);
        

        if (movement > 0 )
        {
            if (!isJumping)
            {
                anim.SetInteger("Transition", 1);
                
            }
            
            transform.eulerAngles = new Vector3(0,0,0);
            
        }

        if (movement < 0)
        {
            if (!isJumping)
            {
                anim.SetInteger("Transition", 1);
                
            }
            
            transform.eulerAngles = new Vector3(0,180,0);
            
        }

        if (movement == 0 && !isJumping && !isFire)
        {
            anim.SetInteger("Transition",0);
        }
        
        
            
    }
    
   
    
    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (!isJumping)
            {
                anim.SetInteger("Transition", 2);
                rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                isJumping = true;
                doubleJump = true;
                SoundJump.Play();
                AudioObserver.OnPlaySfxEvent("Jump");
                ParticleObserver.OnParticleSpwnEvent(transform.position);
                
            }

            else
            {
                if (doubleJump)
                {
                    anim.SetInteger("Transition", 2);
                    rig.AddForce(new Vector2(0, jumpForce * 2), ForceMode2D.Impulse);
                    doubleJump = false;
                    SoundJump.Play();
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
            anim.SetInteger("Transition", 3);
            GameObject Bow = Instantiate(bow, FirePoint.position, FirePoint.rotation);

            if (transform.rotation.y == 0)
            {
                Bow.GetComponent<Bow>().isRight = true;
            }

            if (transform.rotation.y == 180)
            {
                Bow.GetComponent<Bow>().isRight = false;
            }
            
            
            yield return new WaitForSeconds(0.5f);
            isFire = false;
            anim.SetInteger("Transition", 0);
        }
    }

    public void Damage(int dmg)
    {
        Health -= dmg;
        GameController.Instance.UpdatesLives(Health);
        anim.SetTrigger("morrendo");
        
        if (Health <= 0)
        {
            GameController.Instance.GameOver();
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

        if (coll.gameObject.layer == 9)
        {
           
            GameController.Instance.GameOver();
        }
        
    }

    private void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.layer == 8)
        {
            transform.parent = null;
        }
        
        
        
        
    }

    private void OnTriggerEnter2D(Collider2D Collider)
    {
        if (Collider.gameObject.tag == "BlazePoint")
        {
            posInicial = Collider.gameObject.transform.position;
            Destroy(Collider.gameObject);
        } 
        if (Collider.gameObject.CompareTag("Web"))
        {
            speed = 1;
        }
        
        if (Collider.gameObject.CompareTag("Thorns"))
        {
            
        }

        if (Collider.gameObject.CompareTag("boss2"))
        {
            Damage(1);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Web"))
        {
            speed = 5;
        }

        
    }
}
    
    
          