using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bow : MonoBehaviour
{
    private Rigidbody2D rig;
    public bool isRight;
    public int damage;
    public EnemySnake snake;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        snake = GetComponent<EnemySnake>();
        Destroy(gameObject,1.5f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isRight)
        {
            rig.velocity = Vector2.right * speed;
        }

        else
        {
            rig.velocity = Vector2.left * speed;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        
        if (collision.gameObject.tag == "enemyBat")
        {
            collision.GetComponent<enemyBat>().Damamge(1);
            Destroy(gameObject);
        }
        
        if (collision.gameObject.tag == "enemySpider")
        {
            collision.GetComponent<enemySpider>().Damamge(1);
            Destroy(gameObject);
        }
        
        if (collision.gameObject.tag == "enemySnake")
        {
            collision.GetComponent<EnemySnake>().Damamge(1);
            Destroy(gameObject);
        }
        
        if (collision.gameObject.tag == "boss1")
        {
            collision.GetComponent<Boss1>().Damage(2);
            Destroy(gameObject);
        }
        
        if (collision.gameObject.tag == "boss2")
        {
            collision.GetComponent<Boss2>().Damage(2);
            Destroy(gameObject);
        }
        
        
        
    }
    
}
