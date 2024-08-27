using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySnake : MonoBehaviour
{
    public float speed;
    public float WalkTime;
    public float timer;
    public bool WalkRight = true;
    public int Health;
    public int damage = 1;

    private Rigidbody2D rig;
    public Transform playerPos;
    public Rigidbody2D groundRb;
    public float distance;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
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
        
        
        distance = Vector2.Distance(transform.position, playerPos.position);

        if (distance < 4)
        {
            Seguir();
        }

    }
    
    
    
    
    
    private void Seguir()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
    }

    public void Damamge(int dmg)
    {
        Health -= dmg;
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("bateu");
            collision.gameObject.GetComponent<Player>().Damage(damage);
        }


    }
    

}    
