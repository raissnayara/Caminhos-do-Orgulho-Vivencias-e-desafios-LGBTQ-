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
    public float tempTiroMax = 2;
    public GameObject prefabDeTiro;

    // Start is called before the first frame update
    void Start()
    {
        BossControler.instance.UpdateLives(health);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
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
        if (col != null && !col.collider.CompareTag("boss1") && !col.collider.CompareTag("chao"))
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
        BossControler.instance.UpdateLives(health);

        if (health <= 0)
        {
            SceneManager.LoadScene("level3");
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
    

}    
