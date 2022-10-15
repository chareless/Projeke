using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : MonoBehaviour
{
    public float Sayac;
    public float timer;

    public static float bulletForce;

    public Transform firePointL;
    public Transform firePointM;
    public Transform firePointR;
    public Transform firePoint;

    public GameObject fire;
    public GameObject ball;
    public GameObject breathe;

    public int randShoot;
    public int randFire;
    public int randPoint;

    public AudioClip bossShotSound;

    AudioSource sourceAudio; 
    void Start()
    {
        Sayac = 10f;
        timer = 0f;
        sourceAudio = gameObject.GetComponent<AudioSource>();
    }
    void randomPoint()
    {
        int randomForPoint = Random.Range(0, 3);

        switch(randomForPoint)
        {
            case 0:
                firePoint = firePointL;
                break;
            case 1:
                firePoint = firePointM;
                break;
            case 2:
                firePoint = firePointR;
                break;
        }
    }

    void randomFire()
    {
        int randomForFire = Random.Range(0, 10);
       
        if (randomForFire <= 8)
        {
            bulletForce = -8f;
            timer = 5f;
            fire = ball;
            Sayac = 2f;
        }
        else
        {
            bulletForce = -4f;
            timer = 7f;
            fire = breathe;
            Sayac = 4f;
        }

        sourceAudio.PlayOneShot(bossShotSound);
        GameObject dfire = Instantiate(fire, firePoint.position, Quaternion.Euler(-180, 0, 0));
        Rigidbody2D rgbr = dfire.GetComponent<Rigidbody2D>();
        rgbr.velocity = new Vector2(0, bulletForce);
        Destroy(dfire, timer);
    }

    void Shoot()
    {
        randomPoint();
        randomFire();
    }
    void Update()
    {
        Sayac -= Time.deltaTime;
        if(Sayac<=0)
        {
            Shoot();
        }
    }
}