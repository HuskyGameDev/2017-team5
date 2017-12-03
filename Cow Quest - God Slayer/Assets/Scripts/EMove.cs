using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMove : MonoBehaviour {
    GameObject enemy;
    GameObject[] enemiesArray;
    public GameObject hero;
   
    private float moveForce = 350f;
    private float maxSpeed = 5f;
    private bool moveRight = true;
    private bool moveLeft = false;
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
        // FindEnemies(30);
        if (gameObject.CompareTag("Cat"))
        {
            enemy = GameObject.FindGameObjectWithTag("Cat");
            Vector3 pointA = enemy.transform.position;
            Vector3 pointB = new Vector3(transform.position.x + 5, transform.position.y, transform.position.z);
            if (enemy.transform.position.x < pointB.x)
            {
                enemy.transform.Translate(new Vector3(1, 0, 0) * maxSpeed * Time.deltaTime);
            }
            else if (enemy.transform.position.x > pointA.x)
            {
                enemy.transform.Translate(new Vector3(-1, 0, 0) * maxSpeed * Time.deltaTime);
            }

        } else if (gameObject.CompareTag("Dog"))
        {
            enemy = GameObject.FindGameObjectWithTag("Dog");
            Vector3 pointA = enemy.transform.position;
            Vector3 pointB = new Vector3(transform.position.x + 5, transform.position.y, transform.position.z);

            if (Detection())
            {
                if (Direction())
                {

                    enemy.transform.Translate(new Vector3(-1, 0, 0) * maxSpeed * Time.deltaTime);

                }
                else
                {
                    enemy.transform.Translate(new Vector3(1, 0, 0) * maxSpeed * Time.deltaTime);
                }
            } else
            {
                if(enemy.transform.position.x < pointB.x)
                {
                    enemy.transform.Translate(new Vector3(1, 0, 0) * maxSpeed * Time.deltaTime);
                } else if( enemy.transform.position.x > pointA.x)
                {
                    enemy.transform.Translate(new Vector3(-1, 0, 0) * maxSpeed * Time.deltaTime);
                }
            }
        } else if (gameObject.CompareTag("Falcon"))
        {
            enemy = GameObject.FindGameObjectWithTag("Falcon");

            Vector3 pointA = enemy.transform.position;
            Vector3 pointB = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
            if (enemy.transform.position.y < pointB.y)
            {
                enemy.transform.Translate(new Vector3(0, 1, 0) * maxSpeed * Time.deltaTime);
            }
            else if (enemy.transform.position.y > pointA.y)
            {
                enemy.transform.Translate(new Vector3(0, -1, 0) * maxSpeed * Time.deltaTime);
            }


        } else if (gameObject.CompareTag("Mummy"))
        {
            enemy = GameObject.FindGameObjectWithTag("Mummy");
            if (Detection())
            {
                if (Direction())
                {

                    enemy.transform.Translate( new Vector3(-1, 0, 0) * maxSpeed * Time.deltaTime);

                }
                else
                {
                    enemy.transform.Translate(new Vector3(1, 0, 0) * maxSpeed * Time.deltaTime);
                }
            }
        } else if (gameObject.CompareTag("Pharoh"))
        {
            enemy = GameObject.FindGameObjectWithTag("Pharoh");
            if (Detection())
            {
                if (Direction())
                {

                    enemy.transform.Translate(new Vector3(-1, 0, 0) * maxSpeed * Time.deltaTime);

                }
                else
                {
                    enemy.transform.Translate(new Vector3(1, 0, 0) * maxSpeed * Time.deltaTime);
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
        if (Vector3.Distance(transform.position, hero.transform.position) < 30)
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
