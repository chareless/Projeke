using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform firePoint;

    public GameObject knifePrefab;
    public GameObject knifePrefab2;
    public GameObject knifePrefab3;
    public GameObject magicPrefab;
    public GameObject magicPrefab2;
    public GameObject magicPrefab3;
    public GameObject arrowPrefab;
    public GameObject arrowPrefab2;
    public GameObject arrowPrefab3;

    public float bulletForce = 15f;
    public float Sayac;

    public AudioClip magicSound;
    public AudioClip archerSound;
    public AudioClip rogueSound;

    public Animator animator;

     AudioSource sourceAudio;

    public bool shooted;
    public float animatorSayac;
    void Start()
    {
        animator = GetComponent<Animator>(); 
        sourceAudio = gameObject.GetComponent<AudioSource>();
    }

    public void Shooting()
    {
        if(PlayerStats.ourClass=="Rogue" || PlayerStats.ourClass==null)
        {
            if (PlayerStats.level == 1)
            {
                sourceAudio.PlayOneShot(rogueSound);
                GameObject bullet = Instantiate(knifePrefab, firePoint.position, firePoint.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
                Destroy(bullet, 1f);
            }
            if (PlayerStats.level == 2)
            {
                sourceAudio.PlayOneShot(rogueSound);
                GameObject bullet = Instantiate(knifePrefab2, firePoint.position, firePoint.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
                Destroy(bullet, 1f);
            }
            if (PlayerStats.level == 3)
            {
                sourceAudio.PlayOneShot(rogueSound);
                GameObject bullet = Instantiate(knifePrefab3, firePoint.position, firePoint.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
                Destroy(bullet, 1f);
            }
        }
        if(PlayerStats.ourClass=="Wizard")
        {
            if (PlayerStats.level == 1)
            {
                sourceAudio.PlayOneShot(magicSound);
                GameObject bullet = Instantiate(magicPrefab, firePoint.position, firePoint.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
                Destroy(bullet, 1f);
            }
            if (PlayerStats.level == 2)
            {
                sourceAudio.PlayOneShot(magicSound);
                GameObject bullet = Instantiate(magicPrefab2, firePoint.position, firePoint.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
                Destroy(bullet, 1f);
            }
            if (PlayerStats.level == 3)
            {
                sourceAudio.PlayOneShot(magicSound);
                GameObject bullet = Instantiate(magicPrefab3, firePoint.position, firePoint.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
                Destroy(bullet, 1f);
            }
        }
        if(PlayerStats.ourClass=="Archer")
        {
            if (PlayerStats.level == 1)
            {
                sourceAudio.PlayOneShot(archerSound);
                GameObject bullet = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
                Destroy(bullet, 1f);
            }
            if (PlayerStats.level == 2)
            {
                sourceAudio.PlayOneShot(archerSound);
                GameObject bullet = Instantiate(arrowPrefab2, firePoint.position, firePoint.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
                Destroy(bullet, 1f);
            }
            if (PlayerStats.level == 3)
            {
                sourceAudio.PlayOneShot(archerSound);
                GameObject bullet = Instantiate(arrowPrefab3, firePoint.position, firePoint.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
                Destroy(bullet, 1f);
            }
        }
    }

    void Update()
    {
        Sayac -= Time.deltaTime;
        if (shooted == true)
        {
            animatorSayac -= Time.deltaTime;
            if (animatorSayac <= 0)
            {
                shooted = false;
                animator.SetFloat("attacktime", 0);
            }

        }
    }

    public void ShootButton()
    {
        if (Sayac <= 0)
        {
            animator.SetFloat("attacktime",1);
            Shooting();
            Sayac = PlayerStats.attackSpeed;
            shooted = true;
            animatorSayac = 0.5f;
        }
        
    }
}
