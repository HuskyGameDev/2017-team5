using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMove : MonoBehaviour {
    GameObject enemy;
    GameObject[] enemiesArray;
    Vector3 pointA;
    Vector3 pointB;
    public GameObject hero;
   
    private float moveForce = 350f;
    private float maxSpeed = 5f;
    private bool moveRight = true;
    //private bool moveLeft = false;
	// Use this for initialization
	void Start () {
        hero = GameObject.FindGameObjectWithTag("Player");
        Vector3 pointA = enemy.transform.position;
        
    }
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    private void Move()
    {
        // FindEnemies(30);
        if (gameObject.CompareTag("Cat"))
        {
            Vector3 pointB = new Vector3(pointA.x + 5, pointA.y, pointA.z);
            enemy = GameObject.FindGameObjectWithTag("Cat");
            
            if (enemy.transform.position.x > pointB.x)
            {
                moveRight = false;
                
            }
            else if (enemy.transform.position.x < pointA.x)
            {
                moveRight = true;
            }
            if (moveRight)
            {
                enemy.transform.Translate(new Vector3(.5f, 0, 0) * maxSpeed * Time.deltaTime);
            } else
            {
                enemy.transform.Translate(new Vector3(-.5f, 0, 0) * maxSpeed * Time.deltaTime);
            }


        } else if (gameObject.CompareTag("Dog"))
        {
            enemy = GameObject.FindGameObjectWithTag("Dog");
            Vector3 pointB = new Vector3(pointA.x + 5, pointA.y, pointA.z);


            if (Detection())
            {
                if (Direction())
                {

                    enemy.transform.Translate(new Vector3(-.5f, 0, 0) * maxSpeed * Time.deltaTime);

                }
                else
                {
                    enemy.transform.Translate(new Vector3(.5f, 0, 0) * maxSpeed * Time.deltaTime);
                }
            } else
            {
                if (enemy.transform.position.x > pointB.x)
                {
                    moveRight = false;

                }
                else if (enemy.transform.position.x < pointA.x)
                {
                    moveRight = true;
                }
                if (moveRight)
                {
                    enemy.transform.Translate(new Vector3(.5f, 0, 0) * maxSpeed * Time.deltaTime);
                }
                else
                {
                    enemy.transform.Translate(new Vector3(-.5f, 0, 0) * maxSpeed * Time.deltaTime);
                }
            }
        } else if (gameObject.CompareTag("Falcon"))
        {
            enemy = GameObject.FindGameObjectWithTag("Falcon");
            Vector3 pointB = new Vector3(pointA.x, pointA.y + 10, pointA.z);

            if (enemy.transform.position.y > pointB.y)
            {
                moveRight = false;

            }
            else if (enemy.transform.position.y < pointA.y)
            {
                moveRight = true;
            }
            if (moveRight)
            {
                enemy.transform.Translate(new Vector3(0, .5f, 0) * maxSpeed * Time.deltaTime);
            }
            else
            {
                enemy.transform.Translate(new Vector3(0, -.5f, 0) * maxSpeed * Time.deltaTime);
            }


        } else if (gameObject.CompareTag("Mummy"))
        {
            enemy = GameObject.FindGameObjectWithTag("Mummy");
            if (Detection())
            {
                if (Direction())
                {

                    enemy.transform.Translate( new Vector3(-.5f, 0, 0) * maxSpeed * Time.deltaTime);

                }
                else
                {
                    enemy.transform.Translate(new Vector3(.5f, 0, 0) * maxSpeed * Time.deltaTime);
                }
            }
        } else if (gameObject.CompareTag("Pharoh"))
        {
            enemy = GameObject.FindGameObjectWithTag("Pharoh");
            if (Detection())
            {
                if (Direction())
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

    //  GameObject[] FindEnemies(int l)
    // {
    //    enemiesArray = FindObjectsOfType(typeof(GameObject)) as GameObject[];
    //  var enemyList = new System.Collections.Generic.List<GameObject>();
    // for(int i = 0; i < enemiesArray.Length; i++)
    //{
    //   if(enemiesArray[i].layer == l)
    //  {
    //     enemyList.Add(enemiesArray[i]);
    //
    //            }
    //      }
    //    if(enemyList.Count == 0)
    //  {
    //    return null;
    //}
    //return enemyList.ToArray();
    //   }

    bool Detection()
    {
        if (Vector3.Distance(transform.position, hero.transform.position) < 5)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    bool Direction()
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
