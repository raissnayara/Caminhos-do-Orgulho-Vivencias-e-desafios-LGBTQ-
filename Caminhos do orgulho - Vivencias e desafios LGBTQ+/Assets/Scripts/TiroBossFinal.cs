using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroBoss : MonoBehaviour
{
    public int speed;
    public float TempVida = 2;

// Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, TempVida);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            //Chamar scrip de jogador para dano
            col.GetComponent<Player>().Damage(1);
            Destroy(gameObject);
        }
    }

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    
    }
}
