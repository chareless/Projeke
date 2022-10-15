using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonFireStats : MonoBehaviour
{
    public int health=10;
    public int damage=50;

    public bool carpti=false;
    void Update()
    {
        if(health<=0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "towermermi")
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "mermi")
        {
            Destroy(collision.gameObject);
            health -= 10;
        }
        if (collision.gameObject.tag == "base")
        {
            Destroy(gameObject);
            if(health!=0)
            {
                BasementStats.health -= damage;
                carpti = true;
                health -= 10;
            }
        }
    }
}
