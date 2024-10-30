using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2run : MonoBehaviour
{
    public float Speed = 2.5f;
    private Rigidbody2D Rb;
    private Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 target = new Vector2(Player.position.x, Rb.position.y);
        Vector2 newPosition = Vector2.MoveTowards(Rb.position, target, Speed * Time.fixedDeltaTime);
        Rb.MovePosition(newPosition);
    }
    
    
}
