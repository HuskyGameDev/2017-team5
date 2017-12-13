using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag ("Mummy") || collision.gameObject.CompareTag ("Dog") || collision.gameObject.CompareTag ("Cat") || collision.gameObject.CompareTag ("Falcon") || collision.gameObject.CompareTag ("Plantboy") || collision.gameObject.CompareTag ("Pharoh")) {
			Destroy (collision.gameObject);
			Destroy (this.gameObject);
		} 
	}
}
