using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private VolumeController volumeController; // Referência ao VolumeController

    private void Start()
    {
        // Define o volume inicial do slider para o valor atual
        volumeSlider.value = volumeController.GetCurrentVolume();

        // Adiciona um listener para detectar mudanças no valor do slider
        volumeSlider.onValueChanged.AddListener(HandleSliderValueChanged);
    }

    private void HandleSliderValueChanged(float value)
    {
        // Atualiza o volume no VolumeController
        volumeController.SetVolume(value);
    }
}
