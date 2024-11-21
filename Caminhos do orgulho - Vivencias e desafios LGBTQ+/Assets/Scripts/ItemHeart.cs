using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHeart : MonoBehaviour
{
   public int HealthValue;
   private AudioSource HeartSound;

   private void OnCollisionEnter2D(Collision2D collision)
   {
      if (collision.gameObject.tag == "Player")
      {
         HeartSound.Play();
         collision.gameObject.GetComponent<Player>().IncreaseLife(HealthValue);
         Destroy(gameObject,0.1f);
      }
   }
   
   void Start()
   {
      HeartSound = GetComponent<AudioSource>();
   }
}
