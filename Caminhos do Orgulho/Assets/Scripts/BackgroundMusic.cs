using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        // Inscreve-se para ouvir o evento de mudança de volume
        VolumeController.OnVolumeChanged += UpdateVolume;
    }

    private void UpdateVolume(float newVolume)
    {
        // Atualiza o volume do áudio
        _audioSource.volume = newVolume;
    }

    private void OnDestroy()
    {
        // Cancela a inscrição do evento quando o objeto for destruído
        VolumeController.OnVolumeChanged -= UpdateVolume;
    }
}
