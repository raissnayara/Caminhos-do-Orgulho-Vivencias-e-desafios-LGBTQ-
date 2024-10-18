using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boss1 : MonoBehaviour
{
    public float DashSpeed = 10f;
    public float dashDuration = 0.5f;
    public float CoolDawn = 2f;
    public float RaioBoss = 5f;
    private bool IsDashing = false;
    private bool CanDash = true;
    
    private Rigidbody2D Rb;
    private Transform Player;
    
    public int Health;
    public int damage;
        
        
    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, Player.position);
        
        if (distanceToPlayer <= RaioBoss && CanDash)
        {
            StartCoroutine(Dash());
        }
        
        {
            
        }
    }

    IEnumerator Dash()
    {
        CanDash = false;
        IsDashing = true;

        Vector2 dashDirection = (Player.position - transform.position).normalized;
        Rb.velocity = dashDirection * DashSpeed;

        yield return new WaitForSeconds(dashDuration);
        
        Rb.velocity = Vector2.zero;
        IsDashing = false;

        yield return new WaitForSeconds(CoolDawn);
        CanDash = true;



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
