using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NextLevel : MonoBehaviour
{
    public string ProxLevel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameController.Instance.Carregarcena("level-2");
        }
    }
}
