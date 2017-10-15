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
 
    // Use this for initialization
	void Start () {
        hero = GameObject.FindGameObjectWithTag("Player");
	}
	

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemyCollide = true;
            Debug.Log("We hit things");
        } else
        {
            enemyCollide = false;
        }
        if (collision.gameObject.CompareTag("Throwables"))  
        {
            throwCollide = true;
            Debug.Log("Throwable hit you.");
        } else
        {
            throwCollide = false;
        }
      /*  if(collision.transform.position.x < hero.transform.position.x)
        {
            right = true;
        } else
        {
            right = false;
        }
        if(collision.transform.position.x > hero.transform.position.x)
        {
            left = true;
        } else
        {
            left = false;
        }
        if( collision.transform.position.y < hero.transform.position.y)
        {
            bottom = true;
        } else
        {
            bottom = false;
        }
        if( collision.transform.position.y > hero.transform.position.y)
        {
            top = true;
        } else
        {
            top = false;
        }
        */
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
