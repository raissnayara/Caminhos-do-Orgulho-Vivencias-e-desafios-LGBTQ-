using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHeart : MonoBehaviour
{
   public int HealthValue;

   private void OnCollisionEnter2D(Collision2D collision)
   {
      if (collision.gameObject.tag == "Player")
      {
         collision.gameObject.GetComponent<Player>().IncreaseLife(HealthValue);
         Destroy(gameObject);
      }
   }
}
