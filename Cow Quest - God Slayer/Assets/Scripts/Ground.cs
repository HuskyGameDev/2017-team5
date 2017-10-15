using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour {

    public GameObject ground;
    public float verticalAxis = 0f;
    public float horizontalAxis = 0;

    private Vector2 origin;

	// Use this for initialization
	void Start () {
        origin = transform.position;
        CreateGround();
	}
	
	// Update is called once per frame
	void CreateGround () {
        Instantiate(ground, origin, Quaternion.identity);
	}
}
