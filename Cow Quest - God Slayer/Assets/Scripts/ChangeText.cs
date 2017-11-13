using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Change the text in the text box whenever the player presses a key by reading the next line 
 * from the text file */
public class ChangeText : MonoBehaviour {
    public Text text;
    System.IO.StreamReader file = new System.IO.StreamReader("Assets/Text/anubis_dialogue.txt");
    string line;

	// Use this for initialization
    /* Read the first line of the text file */
	void Start () {
        text.text = file.ReadLine();
	}
	
	// Update is called once per frame
    /* Move to the next line of text when WASD or the arroy keys are pressed */
	void Update () {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || 
            Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow)) {
            if ((line = file.ReadLine()) != null) {
                text.text = line;
            }
        }
	}
}
