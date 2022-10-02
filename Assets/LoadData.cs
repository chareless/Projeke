using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class LoadData : MonoBehaviour
{
    public static float loadedScore;
    public static int loadedHealth;
    public static int loadedLevel;
    public static int loadedWave;
    public static int loadedTower;
    public static int loadedCoin;
    public static string loadedClass;
    public void towerCheck()
    {
        if (PlayerPrefs.GetInt("Tower")!=0)
        {
            loadedTower = PlayerPrefs.GetInt("Tower");
        }
        else
        {
            loadedTower = 0;
        }
    }

    public void classCheck()
    {
        if (PlayerPrefs.GetString("Class") != "")
        {
            loadedClass = PlayerPrefs.GetString("Class");
        }
        else
        {
            loadedClass = "";
        }
    }

    public void waveCheck()
    {
        if (PlayerPrefs.GetInt("Wave") != 0)
        {
            loadedWave = PlayerPrefs.GetInt("Wave");
        }
        else
        {
            loadedWave = 0;
        }
    }

    public void levelCheck()
    {
        if (PlayerPrefs.GetInt("Level") != 0)
        {
            loadedLevel = PlayerPrefs.GetInt("Level");
        }
        else
        {
            loadedLevel = 0;
        }
    }

    public void healthCheck()
    {
        if (PlayerPrefs.GetInt("Health") != 0)
        {
            loadedHealth = PlayerPrefs.GetInt("Health");
        }
        else
        {
            loadedHealth = 0;
        }
    }

    public void coinCheck()
    {
        if (PlayerPrefs.GetInt("Coin") != 0)
        {
            loadedCoin = PlayerPrefs.GetInt("Coin");
        }
        else
        {
            loadedHealth = 0;
        }
    }

    public void scoreCheck()
    {
        if (PlayerPrefs.GetFloat("Score") != 0)
        {
            loadedScore = PlayerPrefs.GetFloat("Score");
        }
        else
        {
            loadedScore = 0;
        }
    }

    public void loadData()
    {
        scoreCheck();
        classCheck();
        healthCheck();
        levelCheck();
        towerCheck();
        waveCheck();
        coinCheck();
    }

    public void Start()
    {
        loadData();
    }
}
