using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {
    private Rigidbody2D rb2d;
    public GameObject enemy;
    public GameObject hero;
    private float maxSpeed = 5f;
    private float moveForce = 350f;
	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        hero = GameObject.FindGameObjectWithTag("Hero");
      bool detected = Detection();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    bool Detection()
    {
        if (Mathf.Abs(hero.transform.position.x - enemy.transform.position.x) < 30)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


}
