using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Change the text in the text box whenever the player presses a key by reading the next line 
 * from the text file */
public class ChangeText : MonoBehaviour {
    public Text text;               // The text object to be modified on screen
    public string filename;         // Name of the file to read the text from
    public string sceneToChangeTo;  // Scene to change to after all the text in the file has been read
    System.IO.StreamReader file;
    string line;

	// Use this for initialization
    /* Read the first line of the text file */
	void Start () {
        file = new System.IO.StreamReader(filename);
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