using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossStats : MonoBehaviour
{
    public bool stop = false;
    public bool yasiyor = true;

    public string tur;

    public int maxHealth;
    public int health;
    public int coinValue;
    public int kulePuan;
    public int oyuncuPuan;
    public int damage;

    public float coinChance;
    public float attackSpeed;

    public Image healthBar;

    void Start()
    {
        switch(Spawner.gameLevel)
        {
            case 3:
                tur = "Cerberus";
                kulePuan = 25;
                oyuncuPuan = 50;
                maxHealth = 500;
                break;
            case 6:
                tur = "Spider";
                kulePuan = 25;
                oyuncuPuan = 50;
                maxHealth = 1000;
                break;
            case 9:
                tur = "Demon";
                kulePuan = 25;
                oyuncuPuan = 50;
                maxHealth = 3000;
                break;
            case 10:
                tur = "Dragon";
                kulePuan = 0;
                oyuncuPuan = 100;
                maxHealth = 10000;
                damage = 50;
                attackSpeed = 10f;
                break;
        }

        coinValue = 100;
        coinChance = 100;
        health = maxHealth;
        MiniSpawner.start = true;
    }

    void Update()
    {
        if (health <= 0)
        {
            yasiyor = false;
            PlayerStats.Kill();
            int rand = Random.Range(0, 100);
            if (rand <= coinChance)
            {
                PlayerStats.ParaKazan(coinValue);
                PlayerStats.Puanla(coinValue);
            }
            MiniSpawner.start = false;
            Spawner.bossAlive = false;
            Spawner.bossControl = false;
            stop = false;
            Destroy(gameObject);
        }

        if (Spawner.gameLevel == 3 || Spawner.gameLevel == 6 || Spawner.gameLevel == 9)
        {
            if (stop == false)
            {
                transform.position -= new Vector3(0, 5*Time.deltaTime, 0);
                if (transform.position.y <= 15.7f)
                {
                    transform.position = new Vector3(0, 14f, 0);
                    stop = true;
                }
            }
        }

        if (Spawner.gameLevel == 10)
        {
            if (stop == false)
            {
                transform.position -= new Vector3(0, 5 * Time.deltaTime, 0);
                if (transform.position.y <= 15.7f)
                {
                    transform.position = new Vector3(0f, 15.7f, 0);
                    stop = true;
                }
            }
        }
    }
    public void Damage(int hasar)
    {
        health -= hasar;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "mermi")
        {
            Damage(PlayerStats.damage);
            PlayerStats.Puanla(oyuncuPuan);
            healthBar.fillAmount = (float)health / (float)maxHealth;
           
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag=="enemi")
        {
            Destroy(collision.gameObject);
        }

        if(Spawner.gameLevel!=10)
        {
            if (collision.gameObject.tag == "towermermi")
            {
                Damage(ShootTowers.damage);
                PlayerStats.Puanla(kulePuan);
                healthBar.fillAmount = (float)health / (float)maxHealth;
                
                Destroy(collision.gameObject);
            }
        }
    }
}
