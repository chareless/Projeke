using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public GameObject goblin;
    public GameObject spider;
    public GameObject imp;
    public GameObject boss1;
    public GameObject boss2;
    public GameObject boss3;
    public GameObject boss4;
    public GameObject marketButtonUI;
    public GameObject gameOverCanvas;
    public GameObject gameEndCanvas;

    public Text enemyText;
    public Text changingText;

    public static float spawnRate =3f;
    public float nextSpawn = 0.0f;
    public float nextStepSayac = 0;
    public float sol = 4.85f;
    public float orta = 0.85f;
    public float sag = -3.15f;

    public static int waveCount;
    public static int destroyedEnemy = 0;
    public static int spawnedEnemy = 0;
    public static int gameLevel = 1;

    public static bool bossAlive = false;
    public static bool bossControl = true;
    public static bool gameEnd = false;
    void Start()
    {
        nextStepSayac = 5;
        destroyedEnemy = 0;
        spawnedEnemy = 0;
        waveCounts();
    }

    void waveCounts()
    {
        if (gameLevel == 1)
        {
            waveCount = 20;
        }
        if (gameLevel == 2)
        {
            waveCount = 30;
        }
        if (gameLevel == 3)
        {
            waveCount = 40;
        }
        if (gameLevel == 4)
        {
            waveCount = 30;
        }
        if (gameLevel == 5)
        {
            waveCount = 40;
        }
        if (gameLevel == 6)
        {
            waveCount = 50;
        }
        if (gameLevel == 7)
        {
            waveCount = 40;
        }
        if (gameLevel == 8)
        {
            waveCount = 50;
        }
        if (gameLevel == 9)
        {
            waveCount = 60;
        }
        if (gameLevel == 10)
        {
            waveCount = 0;
        }

        changingText.text = gameLevel.ToString();
        enemyText.text = spawnedEnemy + "/" + waveCount;

        if (gameLevel==11)
        {
            gameEndCanvas.SetActive(true);
            gameEnd = true;
            changingText.text = ((gameLevel)-1).ToString();
        }
    }

    void Update()
    {
        if(gameEnd!=true)
        {
            waveCounts();
            if (Time.time > nextSpawn)
            {
                nextStepSayac -= Time.deltaTime;
                if (destroyedEnemy >= waveCount)
                {
                    if (gameLevel == 3 && bossAlive == false && bossControl == true)
                    {
                        Instantiate(boss1, new Vector3(0.85f, 22.2f, 0f), transform.rotation);
                        bossAlive = true;
                        nextStepSayac = 10000f;
                    }
                    if (gameLevel == 6 && bossAlive == false && bossControl == true)
                    {
                        Instantiate(boss2, new Vector3(0.85f, 22.2f, 0f), transform.rotation);
                        bossAlive = true;
                        nextStepSayac = 10000f;
                    }
                    if (gameLevel == 9 && bossAlive == false && bossControl == true)
                    {
                        Instantiate(boss3, new Vector3(0.85f, 22.2f, 0f), transform.rotation);
                        bossAlive = true;
                        nextStepSayac = 10000f;
                    }
                    if (gameLevel == 10 && bossAlive == false && bossControl == true)
                    {
                        Instantiate(boss4, new Vector3(0.85f, 22.2f, 0f), transform.rotation);
                        bossAlive = true;
                        nextStepSayac = 10000f;
                    }
                    if (bossAlive == false)
                    {
                        bossControl = true;
                        nextStepSayac = 7.5f;
                        gameLevel++;
                        destroyedEnemy = 0;
                        spawnedEnemy = 0;
                        SaveData.saveData();
                        waveCounts();
                        marketButtonUI.SetActive(true);
                    }
                    if (nextStepSayac <= 0 && bossAlive == true)
                    {
                        gameOverCanvas.SetActive(true);
                    }
                }

                if (nextStepSayac < 0 && bossAlive == false)
                {
                    marketButtonUI.SetActive(false);
                    nextSpawn = Time.time + spawnRate;
                    int random = Random.Range(0, 3);
                    if (gameLevel <= 3)
                    {
                        if (random == 0)
                        {
                            if (spawnedEnemy <= waveCount)
                            {
                                Instantiate(goblin, transform.position + new Vector3(sol, 0f, 0f), transform.rotation);
                                spawnedEnemy++;
                            }
                        }
                        if (random == 1)
                        {
                            if (spawnedEnemy <= waveCount)
                            {
                                Instantiate(goblin, transform.position + new Vector3(orta, 0f, 0f), transform.rotation);
                                spawnedEnemy++;
                            }
                        }
                        if (random == 2)
                        {
                            if (spawnedEnemy <= waveCount)
                            {
                                Instantiate(goblin, transform.position + new Vector3(sag, 0f, 0f), transform.rotation);
                                spawnedEnemy++;
                            }
                        }
                    }
                    if (gameLevel <= 6 && gameLevel > 3)
                    {
                        if (random == 0)
                        {
                            if (spawnedEnemy <= waveCount)
                            {
                                Instantiate(spider, transform.position + new Vector3(sol, 0f, 0f), transform.rotation);
                                spawnedEnemy++;
                            }
                        }
                        if (random == 1)
                        {
                            if (spawnedEnemy <= waveCount)
                            {
                                Instantiate(spider, transform.position + new Vector3(orta, 0f, 0f), transform.rotation);
                                spawnedEnemy++;
                            }
                        }
                        if (random == 2)
                        {
                            if (spawnedEnemy <= waveCount)
                            {
                                Instantiate(spider, transform.position + new Vector3(sag, 0f, 0f), transform.rotation);
                                spawnedEnemy++;
                            }
                        }
                    }
                    if (gameLevel <= 9 && gameLevel > 6)
                    {
                        if (random == 0)
                        {
                            if (spawnedEnemy <= waveCount)
                            {
                                Instantiate(imp, transform.position + new Vector3(sol, 0f, 0f), transform.rotation);
                                spawnedEnemy++;
                            }
                        }
                        if (random == 1)
                        {
                            if (spawnedEnemy <= waveCount)
                            {
                                Instantiate(imp, transform.position + new Vector3(orta, 0f, 0f), transform.rotation);
                                spawnedEnemy++;
                            }
                        }
                        if (random == 2)
                        {
                            if (spawnedEnemy <= waveCount)
                            {
                                Instantiate(imp, transform.position + new Vector3(sag, 0f, 0f), transform.rotation);
                                spawnedEnemy++;
                            }
                        }
                    }
                   
                    if (spawnedEnemy == waveCount)
                    {
                        nextStepSayac = 1000f;
                    }
                }
            }
        }
    }
}
