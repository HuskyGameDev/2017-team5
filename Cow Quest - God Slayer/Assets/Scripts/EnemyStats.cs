using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour {

    int enemyHealth = 0;
    
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setEnemyHealth(int newHealth)
    {
        enemyHealth = newHealth;
    }

    public int getEnemyHealth()
    {
        return enemyHealth;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            setEnemyHealth(enemyHealth - 10);
        }
    }
}
