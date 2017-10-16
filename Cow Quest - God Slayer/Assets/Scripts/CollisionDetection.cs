using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour {

    bool left = false;
    bool right = true;
    bool top = false;
    bool bottom = false;
    bool enemyCollide = false;
    bool throwCollide = false;
    GameObject hero;
    //life counter for enemy and throwable collision
    LifeCounter lc = new LifeCounter();
    // Use this for initialization
	void Start () {
        hero = GameObject.FindGameObjectWithTag("Player");
	}
	

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //checks to see if the player is collising with an enemey.
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemyCollide = true;
            lc.RemoveFromLives();
            //Debug.Log("The mummy hit you.");
        } else
        {
            enemyCollide = false;
        }
        if (collision.gameObject.CompareTag("Throwables"))
        {
           
            throwCollide = true;
            lc.RemoveFromLives();
            //Debug.Log("Throw hit you.");
        } else
        {
            throwCollide = false;
        }
       
    }

    public bool cannotLeft()
    {
        return right;
    }
     public bool cannotRight()
    {
        return left;
    }
    public bool onTop()
    {
        return top;
    }
    public bool belowThing()
    {
        return bottom;
    }
}
