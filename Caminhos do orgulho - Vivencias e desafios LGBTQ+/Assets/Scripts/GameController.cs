using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Text HealthText;
    

    public static GameController Instance;

    public int score;

    public Text ScoreText;

    public GameObject PausedGame;
    private bool isPaused;
    public GameObject Gameover;
    public string ProxLevel;
    
    // Start is called before the first frame update
    void Awake()
    {
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
        PauseGame();
    }

   public void UpdateScore(int value)
   {
       score += value;
       ScoreText.text = score.ToString();
   }

    public void UpdatesLives(int value)
    {
        HealthText.text = "X " + value.ToString();
    }
    
    public void Carregarcena(string level)
    {
        SceneManager.LoadScene("Level Boss 1");
    }

    public void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            PausedGame.SetActive(isPaused);
        }

        if (isPaused)
        {
            Time.timeScale = 0f;
        }

        else
        {
            Time.timeScale = 1f;
        }
    }

    public void GameOver()
    {
        Gameover.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
        Gameover.SetActive(false);
    }
}
