using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyGoblin : MonoBehaviour
{
    Rigidbody2D enemyRb;

    public float speed;
    public float attackSpeed;
    public float coinChance;
    public static float Sayac;

    public int maxHealth;
    public int health;
    public int damage;
    public int coinValue;
    public int kulePuan;
    public int oyuncuPuan;

    public string tur;

    public bool yasiyor = true;
    public bool carpti = false;
    public bool mini;
    
    public Image healthBar;
    public Animator animator;

    public AudioClip hitSound;
    public AudioClip hitBaseSound;
  
     AudioSource sourceAudio;  
    void Start()
    {
        animator = GetComponent<Animator>();
        sourceAudio = gameObject.GetComponent<AudioSource>();
        enemyRb = GetComponentInParent<Rigidbody2D>();
        DusmanOlustur();
    }
    public void DusmanOlustur()
    {
        if(MiniSpawner.start!=true)
        {
            tur = "Goblin";
            damage = 5;
            attackSpeed = 2f;
            coinValue = 10;
            coinChance = 20;
            kulePuan = 5;
            oyuncuPuan = 15;
            speed = -2.5f;
            maxHealth = 50 + (10 * Spawner.gameLevel);
            health = maxHealth;
            mini = false;
        }
        else
        {
            tur = "Goblin";
            damage = 5;
            attackSpeed = 2f;
            coinValue = 10;
            coinChance = 1;
            kulePuan = 5;
            oyuncuPuan = 5;
            speed = -3f;
            maxHealth = 20;
            health = maxHealth;
            mini = true;
        }
    }

    public void Damage(int hasar)
    {
        health -= hasar;
        sourceAudio.PlayOneShot(hitSound);
    }

    public void HasarVur(int hasar)
    {
        BasementStats.health -= damage;
        sourceAudio.PlayOneShot(hitBaseSound);
        animator.SetFloat("baseVurma",0);
    }
    public void AfterBoss()
    {
        if (mini == true && Spawner.bossAlive == false)
        {
            Destroy(gameObject);
        }
    }
    public void Update()
    {
        AfterBoss();
        enemyRb.velocity = new Vector2(0, speed);

        if (carpti == true && yasiyor == true)
        {
            Sayac -= Time.deltaTime;
            if (Sayac <= 0)
            {
                HasarVur(damage);
                Sayac = attackSpeed;
            }
        }

        if (health <= 0)
        {
            Destroy(gameObject);
            if (mini != true)
            {
                Spawner.destroyedEnemy++;
            }
            yasiyor = false;
            PlayerStats.Kill();
            int rand = Random.Range(0, 100);
            if (rand <= coinChance)
            {
                PlayerStats.ParaKazan(coinValue);
                PlayerStats.Puanla(coinValue);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "mermi")
        {
            Damage(PlayerStats.damage);
            PlayerStats.Puanla(oyuncuPuan);
            healthBar.fillAmount = (float)health / (float)maxHealth;
           
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "towermermi")
        {
            Damage(ShootTowers.damage);
            PlayerStats.Puanla(kulePuan);
            healthBar.fillAmount = (float)health / (float)maxHealth;
            
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "base")
        {
            HasarVur(damage);
            carpti = true;
            Sayac = attackSpeed;
        }
    }
}
