using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int ScoreValue;
    private AudioSource CoinSound;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CoinSound.Play();
            GameController.Instance.UpdateScore(ScoreValue);
           
            Destroy(gameObject, 0.1f);
            
            
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        CoinSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
