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
    ChangeScene chgscn = new ChangeScene();
    //life counter for enemy and throwable collision
    LifeCounter lc;
    // Use this for initialization
	void Start () {
        lc = FindObjectOfType<LifeCounter>();
        hero = GameObject.FindGameObjectWithTag("Player");
	}
	

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //checks to see if the player is collising with an enemey.
        if (collision.gameObject.CompareTag("Cat") || collision.gameObject.CompareTag("Dog") || collision.gameObject.CompareTag("Mummy") || collision.gameObject.CompareTag("Falcon") || collision.gameObject.CompareTag("Pharoh") || collision.gameObject.CompareTag("Plantboy"))
        {
            enemyCollide = true;
            lc.RemoveFromLives();
            hero.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            hero.transform.position = new Vector3(0, 0, 0);
            //Debug.Log("The mummy hit you.");
        } else
        {
            enemyCollide = false;
        }
        if (collision.gameObject.CompareTag("bossprojectile"))
        {
           
            throwCollide = true;
            lc.RemoveFromLives();
            hero.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            hero.transform.position = new Vector3(0, 0, 0);
            //Debug.Log("Throw hit you.");
        } else
        {
            throwCollide = false;
        }
       
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("teleporter"))
        {
            hero.transform.position = collision.transform.GetChild(0).transform.position;
            
        }

        if (collision.gameObject.CompareTag("darkSide"))
        {
            chgscn.ChangeToScene("Text_Prelevel_Anubis");
        }
        if (collision.gameObject.CompareTag("lightSide"))
        {
            chgscn.ChangeToScene("Text_Prelevel_Ra");
        }

	    if (collision.gameObject.CompareTag("toBeContinued")){
	    chgscn.ChangeToScene("To_Be_Continued");
        }
        else if (collision.gameObject.CompareTag("TextDarkLevel1")) {
            chgscn.ChangeToScene("Text_Dark_Level1");
        }
        else if (collision.gameObject.CompareTag("TextLightLevel1"))
        {
            chgscn.ChangeToScene("Text_Light_Level1");
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
