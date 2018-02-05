using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/* Change the text in the text box whenever the player presses WASD, the arrow keys, the spacebar,
 *  or the left mouse button by reading the next line from the provided text file */
public class ChangeText : MonoBehaviour
{
    // The text object to be modified in the text box on screen
    public Text textObject;

    // File to read the text from
    public TextAsset textFile;

    // Scene to change to after all the text in the file has been read
    public string sceneToChangeTo;

    // Array to store the lines of the text file being read
    string[] fileLines;

    // Total number of lines in the text file being read
    int numOfLines;

    // Line number of the next line to be read
    int nextLine;

	// Use this for initialization
	void Start ()
	{
        /* Split the lines of the text file at every newline character */
        string fileText = textFile.text;
        fileLines = Regex.Split(fileText, "\r\n|\n|\r");
        numOfLines = fileLines.Length;

        /* Read the first line of the text file */
        nextLine = 0;
        textObject.text = fileLines[nextLine++];
    }
	
	// Update is called once per frame
	void Update ()
	{
		/* Move to the next line of text when WASD, the arrow keys, the spacebar, or the left mouse button are pressed */
		if (Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.A) || Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown (KeyCode.D) ||
		    Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown (KeyCode.DownArrow) || Input.GetKeyDown (KeyCode.RightArrow)
		    || Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (0))
        {
            if (nextLine < numOfLines)
            {
                textObject.text = fileLines[nextLine++];
            } else { /* After the last line of the text file has been read, change to the next scene */
				SceneManager.LoadScene (sceneToChangeTo);
			}
		}
	}
}