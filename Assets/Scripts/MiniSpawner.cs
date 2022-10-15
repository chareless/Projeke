using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniSpawner : MonoBehaviour
{
    public GameObject enemy;
    public GameObject goblin;
    public GameObject spider;
    public GameObject imp;

    public static float spawnRate = 2f;
    public float nextSpawn = 0.0f;
    public float nextStepSayac = 2;
    public float yon = 0f;
    public float sol = 4f;
    public float orta = 0f;
    public float sag = -4f;

    public static bool start = false;
    void Update()
    {
        if (start == true  && Spawner.gameLevel < 10)
        {
            if (Time.time > nextSpawn)
            {
                nextStepSayac -= Time.deltaTime;

                if (nextStepSayac < 0)
                {
                    nextSpawn = Time.time + spawnRate;
                    int random = Random.Range(0, 3);

                    switch(Spawner.gameLevel)
                    {
                        case 3:
                            enemy = goblin;
                            break;
                        case 6:
                            enemy = spider;
                            break;
                        case 9:
                            enemy = imp;
                            break;
                    }

                    switch(random)
                    {
                        case 0:
                            yon = sol;
                            break;
                        case 1:
                            yon = orta;
                            break;
                        case 2:
                            yon = sag;
                            break;
                    }

                    Instantiate(enemy, transform.position + new Vector3(yon, 0f, 0f), transform.rotation);
                }
            }
        }
    }
}