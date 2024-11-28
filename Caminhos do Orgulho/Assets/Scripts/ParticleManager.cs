using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
   public GameObject PrefabFumacinha;


   private void OnEnable()
   {
      ParticleObserver.particleSpwnEvent += SpawnarParticulas;
   }

   private void OnDisable()
   {
      ParticleObserver.particleSpwnEvent -= SpawnarParticulas;
   }

   public void SpawnarParticulas(Vector3 posicao)
   {
      Instantiate(PrefabFumacinha, posicao, Quaternion.identity);
   }



}
