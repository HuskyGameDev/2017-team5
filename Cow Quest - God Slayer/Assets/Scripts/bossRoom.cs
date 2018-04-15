using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossRoom : MonoBehaviour {
    bool inBossRoom = false;
    GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (inBossRoom)
        {
            this.gameObject.SetActive(true);
        }
	}

    void Activate()
    {
        inBossRoom = player.GetComponent<CollisionDetection>().getInBossRoom();
    }
}
