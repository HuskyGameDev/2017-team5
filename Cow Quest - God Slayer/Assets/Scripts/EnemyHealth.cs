using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    bool bossDead = false;
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
            if(this.gameObject.CompareTag("Pharoh") || this.gameObject.CompareTag("BigBoy") || this.gameObject.CompareTag("EndDude")){
                bossDead = true;
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("boom");
        takeDamage(10);

    }

    public bool getBossDead()
    {
        return bossDead;
    }
}
