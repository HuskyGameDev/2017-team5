using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMove : MonoBehaviour {
    
    
    Vector3 pointA;
    Vector3 pointB;
    GameObject hero;
    bool set = false;

	bool startset;
    private float moveForce = 350f;
    private float maxSpeed = 5f;
    private bool moveRight = true;

    public float distMove;
    //private bool moveLeft = false;
    // Use this for initialization
    void Start () {
        hero = GameObject.FindGameObjectWithTag("Player");
		startset = false;

        
        
    }
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    private void Move()
    {
        keepUpright(this.gameObject);

        if (this.gameObject.CompareTag("Cat") || this.gameObject.CompareTag("BigBoy") || this.gameObject.CompareTag("EndDude"))
        {



            if (!set)
            {
                pointA = transform.position;
                set = true;
            }
			Vector3 pointB = new Vector3(pointA.x + distMove, pointA.y, pointA.z);

			startset = true;

				

          

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
            } else
            {
                transform.Translate(new Vector3(-.1f, 0, 0) * maxSpeed * Time.deltaTime);
            }


		} else if (this.gameObject.CompareTag("Dog"))
        {
            if (!set)
            {
                pointA = transform.position;
                set = true;
            }
            Vector3 pointB = new Vector3(pointA.x + distMove, pointA.y, pointA.z);

            startset = true;


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
		} else if (this.gameObject.CompareTag("Falcon"))
        {
            if (!set)
            {
                pointA = transform.position;
                set = true;
            }
            Vector3 pointB = new Vector3(pointA.x, pointA.y + distMove, pointA.z);
            startset = true;

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


		} else if (this.gameObject.CompareTag("Mummy"))
        {
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
		} else if (this.gameObject.CompareTag("Pharoh"))
        {
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

	Vector3 setStart(GameObject enemy){
		Vector3 vectorA;
		vectorA = enemy.transform.position;
		return vectorA;
	}

    void keepUpright(GameObject enemy)
    {
        Rigidbody2D rb2d;
        rb2d = enemy.GetComponent<Rigidbody2D>();
        rb2d.freezeRotation = true;
        
    }
}
