using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public static bool GamePaused = false;

    public GameObject pauseMenuUI;
    public GameObject pauseButtonUI;
    public GameObject archerButtonMenuUI;
    public GameObject rogueButtonMenuUI;
    public GameObject wizardButtonMenuUI;
    public GameObject buttonMenuUI;
    void Start()
    {
        switch(PlayerStats.ourClass)
        {
            case "Wizard":
                buttonMenuUI = wizardButtonMenuUI;
                break;
            case "Archer":
                buttonMenuUI = archerButtonMenuUI;
                break;
            case "Rogue":
                buttonMenuUI = rogueButtonMenuUI;
                break;
        }
    }
    public void Pause()
    {
        if (GamePaused == false)
        {
            pauseMenuUI.SetActive(true);
            pauseButtonUI.SetActive(false);
            buttonMenuUI.SetActive(false);
            Time.timeScale = 0f;
            GamePaused = true;
        }
        else
        {
            pauseMenuUI.SetActive(false);
            pauseButtonUI.SetActive(true);
            buttonMenuUI.SetActive(true);
            Time.timeScale = 1f;
            GamePaused = false;
        }
    }
    public void MenuButton()
    {
        Time.timeScale = 1f;
        GamePaused = false;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
