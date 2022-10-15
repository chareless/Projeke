using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEndScript : MonoBehaviour
{
    public float endScore;

    public Text scoreText;
    void Start()
    {
        Time.timeScale = 0;
    }

    void Update()
    {
        endScore = PlayerStats.score;
        scoreText.text = endScore.ToString();
    }

    void saveScore()
    {
        endScore = PlayerStats.score;
        scoreText.text = endScore.ToString();

        if (MainMenu.highScore<endScore)
        {
            PlayerPrefs.SetFloat("Highscore", endScore);
            PlayerPrefs.Save();
        }
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    public void quitButton()
    {
        saveScore();
        Application.Quit();
    }
}
