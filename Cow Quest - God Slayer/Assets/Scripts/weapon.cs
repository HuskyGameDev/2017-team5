using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour {
    public enum Modes
    { melee, Straight, follow, Throw}



    public Sprite sprite;
    public GameObject projectile;
    public float projspeed;
    public float cd;
    public Modes projMode;





	// Use this for initialization
	void Start () {
		
	}
	
	
}
