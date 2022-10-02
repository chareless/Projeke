using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniSpawner : MonoBehaviour
{
    public GameObject goblin;
    public GameObject spider;
    public GameObject imp;

    public static float spawnRate = 2f;
    public float nextSpawn = 0.0f;
    public float nextStepSayac = 2;
    public float sol = 4.85f;
    public float orta = 0.85f;
    public float sag = -3.15f;

    public static bool start = false;
    void Update()
    {
        if (start == true)
        {
            if (Time.time > nextSpawn)
            {
                nextStepSayac -= Time.deltaTime;

                if (nextStepSayac < 0)
                {
                    nextSpawn = Time.time + spawnRate;
                    int random = Random.Range(0, 3);
                    if (Spawner.gameLevel == 3)
                    {
                        if (random == 0)
                        {
                            Instantiate(goblin, transform.position + new Vector3(sol, 0f, 0f), transform.rotation);
                        }
                        if (random == 1)
                        {
                            Instantiate(goblin, transform.position + new Vector3(orta, 0f, 0f), transform.rotation);
                        }
                        if (random == 2)
                        {
                            Instantiate(goblin, transform.position + new Vector3(sag, 0f, 0f), transform.rotation);
                        }
                    }
                    if (Spawner.gameLevel ==6)
                    {
                        if (random == 0)
                        {
                            Instantiate(spider, transform.position + new Vector3(sol, 0f, 0f), transform.rotation);
                        }
                        if (random == 1)
                        {
                            Instantiate(spider, transform.position + new Vector3(orta, 0f, 0f), transform.rotation);
                        }
                        if (random == 2)
                        {
                            Instantiate(spider, transform.position + new Vector3(sag, 0f, 0f), transform.rotation);
                        }
                    }
                    if (Spawner.gameLevel ==9)
                    {
                        if (random == 0)
                        {
                            Instantiate(imp, transform.position + new Vector3(sol, 0f, 0f), transform.rotation);
                        }
                        if (random == 1)
                        {
                            Instantiate(imp, transform.position + new Vector3(orta, 0f, 0f), transform.rotation);
                        }
                        if (random == 2)
                        {
                            Instantiate(imp, transform.position + new Vector3(sag, 0f, 0f), transform.rotation);
                        }
                    }
                }
            }
        }
    }
}