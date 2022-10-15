using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasementStats : MonoBehaviour
{
    public Image healthBar;

    public static int maxHealth = 1000;
    public static int health;

    public Text baseText;

    public GameObject gameOverCanvas;

    void Start()
    {
        health=maxHealth;
        if (MainMenu.saveGameFile == true)
        {
            health = LoadData.loadedHealth;
        }
    }

    public void Damage(int hasar)
    {
        health-=hasar;
    }
    public void Regen(int bonus)
    {
        health +=bonus;
    }
    void Update()
    {
        if(health>maxHealth)
        {
            health=maxHealth;
        }

        if(health<=0)
        {
            health = 0;
            gameOverCanvas.SetActive(true);
        }

        healthBar.fillAmount = (float)health / (float)maxHealth;

        baseText.text = "Basement HP : " + health.ToString();
    }
}
