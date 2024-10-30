using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowWeb : MonoBehaviour
{
    public float slowSpeed = 2f;      // Velocidade do personagem ao tocar na teia
    public float normalSpeed = 5f;    // Velocidade normal do personagem

    private float currentSpeed;       // Armazena a velocidade atual do personagem
    private bool isInWeb = false;     // Verifica se o personagem está na teia

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentSpeed = normalSpeed;  // Define a velocidade inicial como normal
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * currentSpeed, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Web"))   // Certifique-se de que a teia tenha a tag "Web"
        {
            Debug.Log("entrou na teia");
            currentSpeed = slowSpeed;
            isInWeb = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Web"))
        {
            Debug.Log("saiu da teia");
            currentSpeed = normalSpeed;
            isInWeb = false;
        }
    }
}
