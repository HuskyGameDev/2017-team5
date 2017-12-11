using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/* Change the text in the text box whenever the player presses a key by reading the next line 
 * from the text file */
public class ChangeText : MonoBehaviour {
    public Text text;               // The text object to be modified on screen
    public string filename;         // Name of the file to read the text from
    public string sceneToChangeTo;  // Scene to change to after all the text in the file has been read
    System.IO.StreamReader file;
    string line;                    // Current line in the file being read

	// Use this for initialization
	void Start () {
        /* Read the first line of the text file */
        file = new System.IO.StreamReader(filename);
        text.text = file.ReadLine();
	}
	
	// Update is called once per frame
	void Update () {
        /* Move to the next line of text when WASD, the arrow keys, or the left mouse button are pressed */
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || 
            Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow)
            || Input.GetMouseButtonDown(0)) {
            if ((line = file.ReadLine()) != null) {
                text.text = line;
            }
            else { /* After the last line of the text file has been read, change to the next scene */
                SceneManager.LoadScene(sceneToChangeTo);
            }
        }
	}
}