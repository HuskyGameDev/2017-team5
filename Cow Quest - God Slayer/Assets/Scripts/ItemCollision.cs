using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollision : MonoBehaviour {

    // item counter for keeping track of collected items
    ItemCounter ic;

    void Start () 
    {
        ic = FindObjectOfType<ItemCounter>();
    }

	// Update is called once per frame
	public void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
        {
            //ic.addPiece();
            Debug.Log("You collected an item piece!");
            //Debug.Log("Pieces Collected: " + ic.getPieces());
            Destroy(this.gameObject);
        }
	}
}


