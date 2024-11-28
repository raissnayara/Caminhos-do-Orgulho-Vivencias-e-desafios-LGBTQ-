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
    public float tempoEntreLetras = 0.08f;

    private void Awake()
    {
        TryGetComponent(out ComponenteTexto);
        TryGetComponent(out _audioSource);
        mensagemOriginal = ComponenteTexto.text;
        ComponenteTexto.text = "";
    }

    private void OnEnable()
    {
        ImprimirMernsagem(mensagemOriginal);
    }

    private void OnDisable()
    {
        ComponenteTexto.text = mensagemOriginal;
        StopAllCoroutines();
    }

    public void ImprimirMernsagem(string mensagem)
    {
        if (gameObject.activeInHierarchy)
        {
            if (imprimindo) return;
            imprimindo = true;
            StartCoroutine(LetraPorLetra(mensagem));
        }

        IEnumerator LetraPorLetra(string mensagem)
        {
            string msg = "";
            foreach (var letra in mensagem)
            {
                msg += letra;
                ComponenteTexto.text = msg;
                _audioSource.Play();
                yield return new WaitForSeconds(tempoEntreLetras);
            }

            imprimindo = false;
            StopAllCoroutines();
        }   
    }
    
       
}
      

