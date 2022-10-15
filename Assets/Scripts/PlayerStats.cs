using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static float attackSpeed= 0.6f;
    public static float score = 0;

    public static int level = 1;
    public static int damage;
    public static int coin = 0;
    public static int kills = 0;
    public static int waveKills = 0;

    public static string ourClass;

    public Text scoreText;
    public Text coinText;

    public GameObject archerButtonUI;
    public GameObject wizardButtonUI;
    public GameObject rogueButtonUI;
    public GameObject wizard;
    public GameObject archer;
    public GameObject rogue;

    public SpriteRenderer spriteRendererPlayer;

    public Sprite rogueLevel1;

    void Start()
    {
        Application.targetFrameRate = 60;

        if (MainMenu.saveGameFile == true)
        {
            BasementStats.health = LoadData.loadedHealth;
            ourClass = LoadData.loadedClass;
            score = LoadData.loadedScore;
            level = LoadData.loadedLevel;
            coin = LoadData.loadedCoin;
            Spawner.gameLevel = LoadData.loadedWave;
            ShootTowers.level = LoadData.loadedTower;
        }
        else
        {
            BasementStats.health = 1000;
            score = 0;
            level = 1;
            coin = 0;
            Spawner.gameLevel = 1;
            ShootTowers.level = 1;
        }

        playerUpdate();
        buttonActive();

        switch(ourClass)
        {
            case "Archer":
                archer.SetActive(true);
                rogue.SetActive(false);
                wizard.SetActive(false);
                break;
            case "Wizard":
                wizard.SetActive(true);
                rogue.SetActive(false);
                archer.SetActive(false);
                break;
            default:
                rogue.SetActive(true);
                archer.SetActive(false);
                wizard.SetActive(false);
                break;
        }
    }

    public static void levelUp2()
    {
        level = 2;
    }

    public static void levelUp3()
    {
        level = 3;
    }
    public void playerUpdate()
    {
        switch(level)
        {
            case 1:
                damage = 15;
                break;
            case 2:
                damage = 30;
                break;
            case 3:
                damage = 50;
                break;
        }
    }
    public static void Puanla(int puan)
    {
        score += puan;
    }

    public static void ParaKazan(int coins)
    {
        coin += coins;
    }

    public static void Kill()
    {
        kills ++;
        waveKills++;
    }
    
   
    public void buttonActive()
    {
        switch(ourClass)
        {
            case "Archer":
                archerButtonUI.SetActive(true);
                rogueButtonUI.SetActive(false);
                wizardButtonUI.SetActive(false);
                break;
            case "Wizard":
                wizardButtonUI.SetActive(true);
                archerButtonUI.SetActive(false);
                rogueButtonUI.SetActive(false);
                break;
            default:
                rogueButtonUI.SetActive(true);
                archerButtonUI.SetActive(false);
                wizardButtonUI.SetActive(false);
                break;
        }
    }
    void Update()
    {
        spriteRendererPlayer.sprite = rogueLevel1;
        playerUpdate();
        scoreText.text = score.ToString();
        coinText.text = coin.ToString();
    }
}
