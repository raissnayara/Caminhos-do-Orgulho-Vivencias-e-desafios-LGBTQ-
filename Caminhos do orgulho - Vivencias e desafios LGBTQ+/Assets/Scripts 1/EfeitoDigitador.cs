using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class NewBehaviourScript : MonoBehaviour
{
    private TextMeshProUGUI ComponenteTexto;
    private AudioSource _audioSource;
    private string mensagemOriginal;
    public bool imprimindo;

    private void Awake()
    {
        
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    public void ImprimirMernsagem(string msg)
    {
        
    }

    IEnumerator LetraPorLetra(string msg)
    {
        yield return null;
    }
}

