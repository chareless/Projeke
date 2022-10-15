using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShootTowers : MonoBehaviour
{
    public Transform firePoint;

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
        int temp = 0;
        sourceAudio.PlayOneShot(towerSound);
        for (int i=0;i<3;i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position + new Vector3(temp, 0, 0), firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            Destroy(bullet, 2f);
            temp += 4;
        }
        Sayac = attackSpeed;
    }

    static void towerUpdate()
    {
        attackSpeed = 2f;
        switch(level)
        {
            case 1:
                damage = 5;
                break;
            case 2:
                damage = 15;
                break;
            case 3:
                damage = 30;
                break;
        }
    }
    public static void levelUp2()
    {
        level = 2;
        towerUpdate();
    }

    public static void levelUp3()
    {
        level = 3;
        towerUpdate();
    }
    void Update()
    {
        Sayac -=Time.deltaTime;
        if(Sayac<=0)
        {
            if(Spawner.gameLevel<10)
            {
                Shooting();
            }
        }
    }
}
