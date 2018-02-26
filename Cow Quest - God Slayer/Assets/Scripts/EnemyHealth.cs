using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {


    public int health;

    public int getHealth()
    {
        return health;
    }

    public void takeDamage(int dmg)
    {
        health -= dmg;
        if(health == 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("boom");
        takeDamage(10);

    }
}
