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
        transform.position += new Vector3(speed, 0, 0) * Time.deltaTime *1;
    }

    public void SagaGit()
    {
        if(PlayerStats.level==1)
        {
            speed = 10f;
            animator.SetFloat("speed",10);
            animator.SetFloat("attacktime",0);
            animator.SetFloat("Vertical",1);    
        }
        if (PlayerStats.level == 2)
        {
            speed = 12f;
            animator.SetFloat("speed",10);
            animator.SetFloat("attacktime",0);
            animator.SetFloat("Vertical",1);
        }
        if (PlayerStats.level == 3)
        {
            speed = 15f;
            animator.SetFloat("speed",10);
            animator.SetFloat("attacktime",0);
            animator.SetFloat("Vertical",1);
        }
    }
    public void SolaGit()
    {
        if (PlayerStats.level == 1)
        {
            animator.SetFloat("Vertical",-1);
            animator.SetFloat("speed",10);
            animator.SetFloat("attacktime",0);
            speed = -10f;
        }
        if (PlayerStats.level == 2)
        {
            animator.SetFloat("speed",10);
            animator.SetFloat("attacktime",0);
            animator.SetFloat("Vertical",-1);
            speed = -12f;
        }
        if (PlayerStats.level == 3)
        {
            animator.SetFloat("speed",10);
            animator.SetFloat("attacktime",0);
            animator.SetFloat("Vertical",-1);
            speed = -15f;
        }
    }
    public void Dur()
    {
        animator.SetFloat("attacktime",0);
        animator.SetFloat("speed",0);
        speed = 0;
    }
}
