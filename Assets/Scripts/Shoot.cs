using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform firePoint;

    public GameObject[] knifePrefabs;
    public GameObject[] magicPrefabs;
    public GameObject[] arrowPrefabs;

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
        sourceAudio = GetComponent<AudioSource>();
    }

    public void Shooting()
    {
        GameObject prefab;
        switch(PlayerStats.ourClass)
        {
            case "Rogue":
                sourceAudio.PlayOneShot(rogueSound);
                prefab = knifePrefabs[PlayerStats.level - 1];
                break;
            case "Wizard":
                sourceAudio.PlayOneShot(magicSound);
                prefab = magicPrefabs[PlayerStats.level - 1];
                break;
            case "Archer":
                sourceAudio.PlayOneShot(archerSound);
                prefab = arrowPrefabs[PlayerStats.level - 1];
                break;
            default:
                sourceAudio.PlayOneShot(rogueSound);
                prefab = knifePrefabs[PlayerStats.level - 1];
                break;
        }

        GameObject bullet = Instantiate(prefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        Destroy(bullet, 1f);

        shooted = true;
        Sayac = PlayerStats.attackSpeed;
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
            animatorSayac = 0.5f;
        }
    }
}
