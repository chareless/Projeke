using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text highScoreText;

    public GameObject continueButton;

    public static float highScore;

    public static bool saveGameFile = false;

    public void scoreCheck()
    {
        if (PlayerPrefs.GetFloat("Highscore") != 0)
        {
            highScore = PlayerPrefs.GetFloat("Highscore");
        }
        else
        {
            highScore = 0;
        }
        highScoreText.text = highScore.ToString();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Menu");
        saveGameFile = false;
    }

    public void Continue()
    {
        SceneManager.LoadScene("SampleScene");
        saveGameFile = true;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    

    public void Update()
    {
        scoreCheck();
        if (LoadData.loadedWave == 0 || LoadData.loadedWave == 1)
        {
            continueButton.SetActive(false);
        }
        else
        {
            continueButton.SetActive(true);
        }
    }

}
