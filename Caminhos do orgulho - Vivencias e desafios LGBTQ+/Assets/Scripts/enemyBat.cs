using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemyBat : MonoBehaviour
{
    public float distance;
    public float speed;
    public Transform playerPos;
    public Rigidbody2D flyRb;
    public int Health;
    public int damage;


    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, playerPos.position);

        if (distance < 6)
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
