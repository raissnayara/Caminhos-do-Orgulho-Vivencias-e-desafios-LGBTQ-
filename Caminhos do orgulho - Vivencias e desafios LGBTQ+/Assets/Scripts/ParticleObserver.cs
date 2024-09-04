using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ParticleObserver
{
  public static event Action<Vector3> particleSpwnEvent;

  public static void OnParticleSpwnEvent(Vector3 obj)
  {
    particleSpwnEvent?.Invoke(obj);
  }
  
}
