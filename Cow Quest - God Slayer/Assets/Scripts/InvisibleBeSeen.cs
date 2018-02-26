using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleBeSeen : MonoBehaviour {
    GameObject hero;
    SpriteRenderer spriteRenderer;
    
    public bool inRange()
    {
        if(Vector3.Distance(transform.position, hero.transform.position) < 5)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void Start()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        hero = GameObject.FindGameObjectWithTag("Player");
        this.spriteRenderer.enabled = false;
    }
    private void Update()
    {
        checkRange();
    }

    public void checkRange()
    {
        if(inRange() && Input.GetKeyDown(KeyCode.F))
        {
            getLit();
        }
        
    }

    public void getLit()
    {
        Debug.Log("Lit");
        this.spriteRenderer.enabled = true;
    }

}
