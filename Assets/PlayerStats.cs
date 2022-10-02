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
    public Sprite rogueLevel2;
    public Sprite rogueLevel3;
    public Sprite archerLevel1;
    public Sprite archerLevel2;
    public Sprite archerLevel3;
    public Sprite wizardLevel1;
    public Sprite wizardLevel2;
    public Sprite wizardLevel3;

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
        if(ourClass!="Wizard" || ourClass!="Archer")
        {
            rogue.SetActive(true);
            archer.SetActive(false);
            wizard.SetActive(false);
         
        }
        if (ourClass == "Archer")
        {
             archer.SetActive(true);
             rogue.SetActive(false);
             wizard.SetActive(false);
        }
        if (ourClass == "Wizard")
        {
             wizard.SetActive(true);
             rogue.SetActive(false);
             archer.SetActive(false);
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
        if (level == 1)
        {
            damage = 15;
        }
        if (level == 2)
        {
            damage = 30;
        }
        if (level == 3)
        {
            damage = 50;
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
        if(ourClass== "Archer")
        {
            archerButtonUI.SetActive(true);
            rogueButtonUI.SetActive(false);
            wizardButtonUI.SetActive(false);
        }
        if(ourClass== "Rogue")
        {
            rogueButtonUI.SetActive(true);
             archerButtonUI.SetActive(false);
            wizardButtonUI.SetActive(false);
        }
        if(ourClass== "Wizard")
        {
            wizardButtonUI.SetActive(true);
            archerButtonUI.SetActive(false);
             rogueButtonUI.SetActive(false);
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
