using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Text HealthText;
    

    public static GameController Instance;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdatesLives(int value)
    {
        HealthText.text = "X " + value.ToString();
    }
    
    public void Carregarcena(string level)
    {
        SceneManager.LoadScene("level-2");
    }
}
