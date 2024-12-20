using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySnake : MonoBehaviour
{
    public float speed;
    public float WalkTime;
    public float timer;
    public bool WalkRight = true;
    public int Health = 2;
    public int damage = 1;
    private AudioSource SnakeDie;

    private Rigidbody2D rig;
   
    void Start()
    {
       
        rig = GetComponent<Rigidbody2D>();
        SnakeDie = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (timer >= WalkTime)
        {
            WalkRight = !WalkRight;
            timer = 0f;
        }

        if (WalkRight)
        {
            transform.eulerAngles = new Vector2(0, 180);
            rig.velocity = Vector2.right * speed;
        }
        else
        {
            transform.eulerAngles = new Vector2(0, 0);
            rig.velocity = Vector2.left * speed;
        }
        
        
        

    }
    
    
    
    
    
    

    public void Damamge(int dmg)
    {
        Health -= dmg;
        SnakeDie.Play();
        
        if (Health <= 0)
        {
            SnakeDie.Play();
            Destroy(gameObject,  SnakeDie.clip.length);
            
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("bateu");
            collision.gameObject.GetComponent<Player>().Damage(damage);
        }
        if (collision.gameObject.tag == "Tiro")
        {
            Damamge(1);
            
        }

    }
    

}    
