using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonBreatheStats : MonoBehaviour
{
    public int health = 12;
    public int damage = 100;

    public bool control = false;
    public bool carpti = false;

    void Update()
    {
        if (health <= 0)
        {
            if (carpti == false)
            {
                Destroy(gameObject);
                control = true;
            }
            if (carpti == true && control != true)
            {
                Destroy(gameObject);
            }
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
            health -= 4;
        }
        if (collision.gameObject.tag == "base")
        {
            Destroy(gameObject);
            if (health != 0)
            {
                BasementStats.health -= damage;
                carpti = true;
                health -= 12;
            }
        }
    }
}
