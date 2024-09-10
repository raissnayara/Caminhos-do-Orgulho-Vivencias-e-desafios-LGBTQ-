using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeController : MonoBehaviour
{
    // Evento que será disparado quando o volume mudar
    public static event Action<float> OnVolumeChanged;

    private float _currentVolume = 1.0f; // Volume inicial (100%)

    // Método para alterar o volume
    public void SetVolume(float newVolume)
    {
        // Atualiza o volume apenas se o valor mudar
        if (Math.Abs(newVolume - _currentVolume) > Mathf.Epsilon)
        {
            _currentVolume = newVolume;
            Debug.Log($"Volume alterado para: {newVolume}");
            OnVolumeChanged?.Invoke(newVolume); // Notifica todos os ouvintes sobre a mudança de volume
        }
    }

    // Método para obter o volume atual
    public float GetCurrentVolume()
    {
        return _currentVolume;
    }
}
