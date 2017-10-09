using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMove : MonoBehaviour {
    GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
    private float moveForce = 350f;
    private float maxSpeed = 5f;
    private bool moveRight = true;
    private bool moveLeft = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    private void Move()
    {
        if(true)
        {
            enemy.transform.Translate(new Vector2(maxSpeed, 0) * Time.deltaTime);
        }
        else
        {
            enemy.transform.Translate(new Vector2(-1 * maxSpeed, 0) * Time.deltaTime);
        }
    }
}
