using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarketScript : MonoBehaviour
{
    public static bool GameMarket = false;

    public GameObject pauseButtonUI;
    public GameObject buttonMenuUI;
    public GameObject marketButtonUI;
    public GameObject marketMenuUI;
    public GameObject archerButtonMenuUI;
    public GameObject wizardButtonMenuUI;
    public GameObject rogueButtonMenuUI;

    public Button pl2Button;
    public Button pl3Button;
    public Button tl2Button;
    public Button tl3Button;

    public Text pl2PriceText;
    public Text pl3PriceText;
    public Text tl2PriceText;
    public Text tl3PriceText;

    public static int pl2Price=150;
    public static int pl3Price=300;
    public static int tl2Price=150;
    public static int tl3Price=300;

    public static bool pl2 = false;
    public static bool tl2 = false;
    void Start()
    {
        tl2Button.interactable = false;
        pl2Button.interactable = false;
        pl3Button.interactable = false;
        tl3Button.interactable = false;

        pl2PriceText.text = pl2Price.ToString();
        pl3PriceText.text = pl3Price.ToString();
        tl2PriceText.text = tl2Price.ToString();
        tl3PriceText.text = tl3Price.ToString();

        if(PlayerStats.ourClass=="Wizard")
        {
            buttonMenuUI=wizardButtonMenuUI;
        }
        if(PlayerStats.ourClass=="Archer")
        {
            buttonMenuUI=archerButtonMenuUI;
        }
        if(PlayerStats.ourClass=="Rogue")
        {
            buttonMenuUI=rogueButtonMenuUI;
        }
    }

    public void Pause()
    {
        if (GameMarket== false)
        {
            pauseButtonUI.SetActive(false);
            buttonMenuUI.SetActive(false);
            marketMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GameMarket = true;
        }
        else
        {
            pauseButtonUI.SetActive(true);
            buttonMenuUI.SetActive(true);
            marketMenuUI.SetActive(false);
            Time.timeScale = 1f;
            GameMarket = false;
        }
    }

    public void playerLevel2Button()
    {
        PlayerStats.levelUp2();
        PlayerStats.coin -= pl2Price;
        pl2Button.interactable = false;
        marketControl();
    }

    public void playerLevel3Button()
    {
        PlayerStats.levelUp3();
        PlayerStats.coin -= pl3Price;
        pl3Button.interactable = false;
        marketControl();
    }

    public void towerLevel2Button()
    {
        ShootTowers.levelUp2();
        PlayerStats.coin -= tl2Price;
        tl2Button.interactable = false;
        marketControl();
    }

    public void towerLevel3Button()
    {
        ShootTowers.levelUp3();
        PlayerStats.coin -= tl3Price;
        tl3Button.interactable = false;
        marketControl();
    }

    public void marketControl()
    {
        if (PlayerStats.coin >= pl2Price && PlayerStats.level == 1)
        {
            pl2Button.interactable = true;
            pl2 = true;
        }
        else
        {
            pl2Button.interactable = false;
        }
        if (PlayerStats.coin >= pl3Price && pl2 == true && PlayerStats.level == 2)
        {
            pl3Button.interactable = true;
        }
        else
        {
            pl3Button.interactable = false;
        }
        if (PlayerStats.coin >= tl2Price && ShootTowers.level == 1)
        {
            tl2Button.interactable = true;
            tl2 = true;
        }
        else
        {
            tl2Button.interactable = false;
        }
        if (PlayerStats.coin >= tl3Price && tl2 == true && ShootTowers.level == 2)
        {
            tl3Button.interactable = true;
        }
        else
        {
            tl3Button.interactable = false;
        }
    }
    void Update()
    {
        marketControl();
    }
}
