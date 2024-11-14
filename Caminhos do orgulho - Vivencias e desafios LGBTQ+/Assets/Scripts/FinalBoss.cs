using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FinalBoss : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rig;
    private bool faceflip;

    public string Level3;

    public int damage = 1;

    public int health;

    
    
    private float tempTiro;
    public float tempTiroMax = 2f;
    public GameObject prefabDeTiro;

    public Transform tiroSpawnPoint; // Ponto onde o tiro será instanciado
    public float velocidadeDoTiro = 5f;

    // Start is called before the first frame update
    void Start()
    {
        BossControler.instance.UpdateLives(health);
        
        BossControler.instance.UpdateLives(health);
        tempTiro = tempTiroMax; 
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        
        // Movimento do inimigo
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        // Controle de tiro
        tempTiro -= Time.deltaTime;
        if (tempTiro <= 0)
        {
            Atirar();
            tempTiro = tempTiroMax; // Reinicia o contador de tiro
        }
    }
    
    

    private void Flipenemy()
    {
        if (faceflip)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    
    
    
    

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col != null && !col.collider.CompareTag("bossFinal") && !col.collider.CompareTag("chao"))
        {
            faceflip = !faceflip;
        }

        Flipenemy();

        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<Player>().Damage(damage);
        }

    }

    public void Damage(int dmg)
    {
        health -= dmg;
        //BossControler.instance.UpdateLives(health);

        if (health <= 0)
        {
            SceneManager.LoadScene("cutsceneFinal");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.StartsWith("Player"))
        {
            Damage(1);
            Destroy(col.gameObject);
        }
    }

    private void Atirar()
    {
        if (prefabDeTiro != null && tiroSpawnPoint != null)
        {
            GameObject tiro = Instantiate(prefabDeTiro, tiroSpawnPoint.position, tiroSpawnPoint.rotation);
            Rigidbody2D rbTiro = tiro.GetComponent<Rigidbody2D>();

            // Define a direção e velocidade do tiro
            Vector2 direcao = faceflip ? Vector2.left : Vector2.right;
            rbTiro.velocity = direcao * velocidadeDoTiro;
        }


    }

}    
