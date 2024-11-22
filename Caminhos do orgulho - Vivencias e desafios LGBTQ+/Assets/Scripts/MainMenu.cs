using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   [SerializeField] private GameObject painelMainMenu;
   [SerializeField] private GameObject painelOpçoes;
   public void LoadGame()
   {
      SceneManager.LoadScene(2);
   }
   
}
