using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMove : MonoBehaviour {
    
    
    Vector3 pointA;
    Vector3 pointB;
    public GameObject hero;
   
    private float moveForce = 350f;
    private float maxSpeed = 5f;
    private bool moveRight = true;
    public float distMove;
    //private bool moveLeft = false;
    // Use this for initialization
    void Start () {
        hero = GameObject.FindGameObjectWithTag("Player");
        
        
        
    }
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    private void Move()
    {
        GameObject enemy;
        Vector3 pointA = transform.position;
        
        if (gameObject.CompareTag("Cat"))
        {
            
           
            enemy = GameObject.FindGameObjectWithTag("Cat");
           
            Vector3 pointB = new Vector3(pointA.x + distMove, pointA.y, pointA.z);
            if (transform.position.x > pointB.x)
            {
                moveRight = false;
                
            }
            else if (transform.position.x < pointA.x)
            {
                moveRight = true;
            }
            if (moveRight)
            {
                transform.Translate(new Vector3(.5f, 0, 0) * maxSpeed * Time.deltaTime);
            } else
            {
                transform.Translate(new Vector3(-.5f, 0, 0) * maxSpeed * Time.deltaTime);
            }


        } else if (gameObject.CompareTag("Dog"))
        {
            enemy = GameObject.FindGameObjectWithTag("Dog");
            Vector3 pointB = new Vector3(pointA.x + distMove, pointA.y, pointA.z);


            if (Detection())
            {
				if (Direction(this.gameObject))
                {

                    transform.Translate(new Vector3(-.5f, 0, 0) * maxSpeed * Time.deltaTime);

                }
                else
                {
                    transform.Translate(new Vector3(.5f, 0, 0) * maxSpeed * Time.deltaTime);
                }
            } else
            {
                if (transform.position.x > pointB.x)
                {
                    moveRight = false;

                }
                else if (transform.position.x < pointA.x)
                {
                    moveRight = true;
                }
                if (moveRight)
                {
                   transform.Translate(new Vector3(.1f, 0, 0) * maxSpeed * Time.deltaTime);
                }
                else
                {
                    transform.Translate(new Vector3(-.1f, 0, 0) * maxSpeed * Time.deltaTime);
                }
            }
        } else if (gameObject.CompareTag("Falcon"))
        {
            enemy = GameObject.FindGameObjectWithTag("Falcon");
            Vector3 pointB = new Vector3(pointA.x, pointA.y + distMove, pointA.z);

            if (transform.position.y > pointB.y)
            {
                moveRight = false;

            }
            else if (transform.position.y < pointA.y)
            {
                moveRight = true;
            }
            if (moveRight)
            {
                transform.Translate(new Vector3(0, .1f, 0) * maxSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(new Vector3(0, -.1f, 0) * maxSpeed * Time.deltaTime);
            }


        } else if (gameObject.CompareTag("Mummy"))
        {
            enemy = GameObject.FindGameObjectWithTag("Mummy");
            if (Detection())
            {
				if (Direction(this.gameObject))
                {

                    transform.Translate( new Vector3(-.1f, 0, 0) * maxSpeed * Time.deltaTime);

                }
                else
                {
                    transform.Translate(new Vector3(.1f, 0, 0) * maxSpeed * Time.deltaTime);
                }
            }
        } else if (gameObject.CompareTag("Pharoh"))
        {
            enemy = GameObject.FindGameObjectWithTag("Pharoh");
            if (Detection())
            {
				if (Direction(this.gameObject))
                {

                    enemy.transform.Translate(new Vector3(-.5f, 0, 0) * maxSpeed * Time.deltaTime);

                }
                else
                {
                    enemy.transform.Translate(new Vector3(.5f, 0, 0) * maxSpeed * Time.deltaTime);
                }
            }
        }
    }

    bool Detection()
    {
        if (Vector3.Distance(transform.position, hero.transform.position) < 2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    bool Direction(GameObject enemy)
    {
        if(hero.transform.position.x - enemy.transform.position.x < 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
