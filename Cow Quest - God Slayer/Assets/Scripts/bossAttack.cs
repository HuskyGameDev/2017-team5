using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossAttack : MonoBehaviour
{


    weapon boss;
    public GameObject bossweapon;
    public float deletedelay = 5.0f;
    bool isTriggered = false;
    int cd = 0;
    GameObject hero;
    bool right;


    // Use this for initialization
    void Start()
    {
        boss = bossweapon.GetComponent<weapon>();
        GetComponent<SpriteRenderer>().sprite = boss.sprite;
        hero = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Detection())
        {
            if (cd == 0)
            {
                cd = 60;
                //Vector3 rotation = transform.parent.localScale.x==1 ? Vector3.zero : Vector3.forward*180;
                GameObject projectile = (GameObject)Instantiate(boss.projectile, transform.position + bossweapon.transform.GetChild(0).localPosition * transform.parent.localScale.x, Quaternion.identity);
                //projectile.tag = "Clone";
                right = Direction(this.gameObject);

                if (boss.projMode == weapon.Modes.Straight)
                {
                    if (right)
                    {
                        projectile.GetComponent<Rigidbody2D>().velocity = transform.parent.localScale.x * Vector2.right * boss.projspeed;
                    }
                    else
                    {
                        projectile.GetComponent<Rigidbody2D>().velocity = -1 * transform.parent.localScale.x * Vector2.right * boss.projspeed;
                    }
                    Destroy(projectile.gameObject, deletedelay);

                }
                else if (boss.projMode == weapon.Modes.Throw)
                {
                    projectile.GetComponent<Rigidbody2D>().isKinematic = false;
                    if (right)
                    {
                        projectile.GetComponent<Rigidbody2D>().velocity = transform.parent.localScale.x * Vector2.right * boss.projspeed;
                    }
                    else
                    {
                        projectile.GetComponent<Rigidbody2D>().velocity = -1 * transform.parent.localScale.x * Vector2.right * boss.projspeed;
                    }
                    Destroy(projectile.gameObject, deletedelay);

                }
            }
            else
            {
                cd--;
            }
        }
    }

    bool Direction(GameObject enemy)
    {
        if (hero.transform.position.x - enemy.transform.position.x < 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    bool Detection()
    {
        if (Vector3.Distance(transform.position, hero.transform.position) < 4)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
