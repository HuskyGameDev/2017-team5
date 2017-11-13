using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeAttacc : MonoBehaviour {
    int wait = 60;
    public Collider2D weaponCollider;
    //Transform player = GameObject.FindGameObjectWithTag("Player").transform;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //setparent(player);
        if (Input.GetButtonDown("Fire1"))
        {
          //  transform.Rotate(90, 0, 0);
           // while(wait > 0)
            //{
             //   wait--;
            //}
            //wait = 60;
            //transform.Rotate(-90, 0, 0);

        }


    }
  public void setparent(Transform newparent)
    {
        transform.SetParent(newparent);
    }
}
