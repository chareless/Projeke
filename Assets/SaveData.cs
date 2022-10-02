using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public static float currentScore;
    public static int currentHealth;
    public static int currentLevel;
    public static int currentWave;
    public static int currentTower;
    public static int currentCoin;
    public static string currentClass;

    static void saveScore()
    {
        currentScore = PlayerStats.score;
        PlayerPrefs.SetFloat("Score",currentScore);
        PlayerPrefs.Save();
    }

    static void saveTower()
    {
        currentTower = ShootTowers.level;
        PlayerPrefs.SetInt("Tower", currentTower);
        PlayerPrefs.Save();
    }

    static void saveClass()
    {
        currentClass = PlayerStats.ourClass;
        PlayerPrefs.SetString("Class", currentClass);
        PlayerPrefs.Save();
    }

    static void saveHealth()
    {
        currentHealth = BasementStats.health;
        PlayerPrefs.SetInt("Health", currentHealth);
        PlayerPrefs.Save();
    }

    static void saveLevel()
    {
        currentLevel = PlayerStats.level;
        PlayerPrefs.SetInt("Level", currentLevel);
        PlayerPrefs.Save();
    }

    static void saveWave()
    {
        currentWave = Spawner.gameLevel;
        PlayerPrefs.SetInt("Wave", currentWave);
        PlayerPrefs.Save();
    }

    static void saveCoin()
    {
        currentCoin = PlayerStats.coin;
        PlayerPrefs.SetInt("Coin", currentCoin);
        PlayerPrefs.Save();
    }

    public static void saveData()
    {
        saveHealth();
        saveLevel();
        saveWave();
        saveScore();
        saveTower();
        saveCoin();
        saveClass();
        PlayerPrefs.Save();
    }
}
