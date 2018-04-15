using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossDead : MonoBehaviour {
    GameObject pharoh;
    GameObject bigBoy;
    GameObject endDude;
    bool bossIdDead = false;
	// Use this for initialization
	void Start () {
        pharoh = GameObject.FindGameObjectWithTag("Pharoh");
        bigBoy = GameObject.FindGameObjectWithTag("BigBoy");
        endDude = GameObject.FindGameObjectWithTag("EndDude");
	}
	
	// Update is called once per frame
	void Update () {
        if (bossIdDead)
        {
            this.gameObject.SetActive(true);
        }
	}

    void bossIsDead()
    {
        if (pharoh != null)
        {
            pharoh.GetComponent<EnemyHealth>().getBossDead();
            bossIdDead = true;
        }
        if (bigBoy != null)
        {
            endDude.GetComponent<EnemyHealth>().getBossDead();
            bossIdDead = true;
        }
        if (endDude != null)
        {
            endDude.GetComponent<EnemyHealth>().getBossDead();
            bossIdDead = true;
        }
    }
}
