using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;

    public AudioSource Musicsource, SfxSource;

    public AudioClip clipPulo, clipColetavel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        AudioObserver.PlayMusicEvent += TocarMusica;
        AudioObserver.StopMusicEvent += PararMusica;
        AudioObserver.PlaySfxEvent += TocarEventoSonoro;
    }

    private void OnDisable()
    {
        AudioObserver.PlayMusicEvent -= TocarMusica;
        AudioObserver.StopMusicEvent -= PararMusica;
        AudioObserver.PlaySfxEvent -= TocarEventoSonoro;
    }
    
    

    void TocarEventoSonoro(string nomeDoClip)
    {
        switch (nomeDoClip)
        {
            case "pulo":
                SfxSource.PlayOneShot(clipPulo);
                break;
            case "coletavel":
                SfxSource.PlayOneShot(clipColetavel);
                break;
            default:
                Debug.Log($"efeito sonoro {nomeDoClip} nao encotrado");

                break;
        }
    }

    void TocarMusica()
    {
        Musicsource.Play();
    }

    void PararMusica()
    {
        Musicsource.Stop();
    }
}
