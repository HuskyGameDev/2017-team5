using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttach : MonoBehaviour {


    weapon wpn;
    public GameObject activeweapon;
    public float delay = 5.0f;
	bool isTriggered = false;


	// Use this for initialization
	void Start () {
        wpn = activeweapon.GetComponent<weapon>();
        GetComponent<SpriteRenderer>().sprite = wpn.sprite;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(wpn.projMode == weapon.Modes.melee)
            {
               // OnCollisionEnter2D(wpn.GetComponent<Collision2D>());
            }
        }
        if(Input.GetKeyDown(KeyCode.F))
        {
            //Vector3 rotation = transform.parent.localScale.x==1 ? Vector3.zero : Vector3.forward*180;
            GameObject projectile = (GameObject)Instantiate(wpn.projectile, transform.position + activeweapon.transform.GetChild(0).localPosition*transform.parent.localScale.x, Quaternion.identity);
            //projectile.tag = "Clone";

            if(wpn.projMode == weapon.Modes.Straight)
            {
                projectile.GetComponent<Rigidbody2D>().velocity = transform.parent.localScale.x * Vector2.right * wpn.projspeed;
				//OnTriggerEnter2D (projectile.GetComponent<Collider2D>());
				if (isTriggered) {
					Destroy (projectile.gameObject);
				} else { 
					Destroy (projectile.gameObject, delay);
				}
            }
            else if(wpn.projMode == weapon.Modes.Throw)
            {
                projectile.GetComponent<Rigidbody2D>().isKinematic = false;
                projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.parent.localScale.x, 1) * wpn.projspeed;
				//OnTriggerEnter2D (projectile.GetComponent<Collider2D>());
				if (isTriggered) {
					Destroy (projectile.gameObject);
				} else { 
					Destroy (projectile.gameObject, delay);
				}
            }
        }
	}
}
