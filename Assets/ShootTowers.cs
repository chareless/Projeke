using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTowers : MonoBehaviour
{
    public Transform firePoint;
    public Transform firePoint2;
    public Transform firePoint3;

    public GameObject bulletPrefab;

    public float Sayac;
    public float bulletForce = 10f;
    public static float attackSpeed;

    public static int level = 1;
    public static int damage;

    public AudioClip towerSound;

    AudioSource sourceAudio;
    void Start()
    {
        sourceAudio = gameObject.GetComponent<AudioSource>();
        if (MainMenu.saveGameFile == true)
        {
            level = LoadData.loadedTower;
        }
        towerUpdate();
    }

    void Shooting()
    {
        sourceAudio.PlayOneShot(towerSound);
        GameObject bullet1 = Instantiate(bulletPrefab,firePoint.position,firePoint.rotation);
        Rigidbody2D rb = bullet1.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up*bulletForce,ForceMode2D.Impulse);
        Destroy(bullet1,2f);

        GameObject bullet2 = Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);
        Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
        rb2.AddForce(firePoint2.up * bulletForce, ForceMode2D.Impulse);
        Destroy(bullet2, 2f);

        GameObject bullet3 = Instantiate(bulletPrefab, firePoint3.position, firePoint3.rotation);
        Rigidbody2D rb3 = bullet3.GetComponent<Rigidbody2D>();
        rb3.AddForce(firePoint3.up * bulletForce, ForceMode2D.Impulse);
        Destroy(bullet3, 2f);
    }

    static void towerUpdate()
    {
        if(level==1)
        {
            damage = 5;
            attackSpeed = 2f;
        }
        if (level == 2)
        {
            damage = 15;
            attackSpeed = 2f;
        }
        if (level == 3)
        {
            damage = 30;
            attackSpeed = 2f;
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
    void Update()
    {
        towerUpdate();
        Sayac -=Time.deltaTime;
        if(Sayac<=0)
        {
            if(Spawner.gameLevel!=10)
            {
                Shooting();
                Sayac = attackSpeed;
            }
        }
    }
}
