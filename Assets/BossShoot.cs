using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : MonoBehaviour
{
    public float Sayac;

    public static float bulletForce;

    public Transform firePointL;
    public Transform firePointM;
    public Transform firePointR;
    public Transform firePoint;

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
        sourceAudio = gameObject.GetComponent<AudioSource>();
    }
    void randomPoint()
    {
        int randomForPoint = Random.Range(0, 3);
        if(randomForPoint==0)
        {
            firePoint = firePointL;
        }
        if (randomForPoint == 1)
        {
            firePoint = firePointM;
        }
        if (randomForPoint == 2)
        {
            firePoint = firePointR;
        }
    }

    void randomFire()
    {
        int randomForFire = Random.Range(0, 10);
        if (randomForFire <= 8)
        {
            sourceAudio.PlayOneShot(bossShotSound);
            bulletForce = -8f;
            GameObject dball = Instantiate(ball, firePoint.position, Quaternion.Euler(-180,0,0));
            Rigidbody2D rgbr = dball.GetComponent<Rigidbody2D>();
            rgbr.velocity = new Vector2(0, bulletForce);
            Destroy(dball, 5f);
            Sayac = 2f;
        }
        if (randomForFire > 8)
        {
            sourceAudio.PlayOneShot(bossShotSound);
            bulletForce = -4f;
            GameObject dbreathe = Instantiate(breathe, firePoint.position, Quaternion.Euler(-180,0,0));
            Rigidbody2D rgbr2 = dbreathe.GetComponent<Rigidbody2D>();
            rgbr2.velocity = new Vector2(0, bulletForce);
            Destroy(dbreathe, 7f);
            Sayac = 4f;
        }
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
