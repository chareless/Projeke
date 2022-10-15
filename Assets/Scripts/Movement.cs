using System.Collections;
using System.Collections.Generic;
using UnityEngine;

   
public class Movement : MonoBehaviour
{
    public Animator animator;

    public float speed;

    void Start()
    {
         animator = GetComponent<Animator>(); 
    }
    
    void Update()
    {
        transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
    }

    public void SagaGit()
    {
        switch(PlayerStats.level)
        {
            case 1:
                speed = 10f;
                break;
            case 2:
                speed = 12f;
                break;
            case 3:
                speed = 15f;
                break;
        }

        animator.SetFloat("speed", 10);
        animator.SetFloat("attacktime", 0);
        animator.SetFloat("Vertical", 1);
    }
    public void SolaGit()
    {
        switch (PlayerStats.level)
        {
            case 1:
                speed = -10f;
                break;
            case 2:
                speed = -12f;
                break;
            case 3:
                speed = -15f;
                break;
        }

        animator.SetFloat("Vertical", -1);
        animator.SetFloat("speed", 10);
        animator.SetFloat("attacktime", 0);
    }
    public void Dur()
    {
        animator.SetFloat("attacktime",0);
        animator.SetFloat("speed",0);
        speed = 0;
    }
}
