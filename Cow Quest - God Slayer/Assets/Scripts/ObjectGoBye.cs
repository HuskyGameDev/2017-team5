using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGoBye : MonoBehaviour {
    float delay = 5.0f;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, delay);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
