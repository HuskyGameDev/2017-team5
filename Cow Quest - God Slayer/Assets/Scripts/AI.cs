using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {
    private Rigidbody2D rb2d;
    public GameObject enemy;
    
    private float maxSpeed = 5f;
    private float moveForce = 350f;
	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        
      
	}
	
	// Update is called once per frame
	void Update () {
	
	}

   



}
