using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/* Change the text in the text box whenever the player presses WASD, the arrow keys, the space bar, or the left mouse button
 * by reading the next line from the provided text file, and display buttons after the appropriate line has been read */
public class ChangeText_2Buttons2 : MonoBehaviour {
    public Text textObject;         // The text object to be modified in the text box on screen
    public TextAsset textFile;      // File to read the text from
    public string sceneToChangeTo;  // Scene to change to after all the text in the file has been read

    public GameObject button1, button2;  // Buttons to be displayed
    Button btn1, btn2;                   // Buttons must also be defined as Button types to use the onClick() function

    string[] fileLines;             // Array to store the lines of the text file being read
    int numOfLines;                 // Total number of lines in the text file being read
    int nextLine;                   // Line number of the next line to be read
 
    int linesUntilButtons;          // Number of lines of text until the buttons should be displayed
    int linesUntilYesNo;            // Number of lines of text until the Yes and No buttons should be displayed
    //int linesOfNoText;            // Number of lines of the "No" response text

	// Use this for initialization
	void Start () {
        /* Redefine buttons as Button types in order to use the onClick() function
        * and add listeners */
        btn1 = button1.GetComponent<Button>();
        btn1.onClick.AddListener(Button1Clicked);

        btn2 = button2.GetComponent<Button>();
        btn2.onClick.AddListener(Button2Clicked);

        /* Make the buttons inactive at the start of the scene */
        button1.SetActive(false);
        button2.SetActive(false);

        /* Split the lines of the text file at every newline character */
        string fileText = textFile.text;
        fileLines = Regex.Split(fileText, "\r\n|\n|\r");
        numOfLines = fileLines.Length;

        /* Read the first two lines of the text file to get the number of lines until the buttons should appear */
        nextLine = 0;
        linesUntilButtons = int.Parse(fileLines[nextLine++]);

        ///* Read the second line of the text file to get the number of lines between the "Yes" and "No" response text */
        //linesOfNoText = int.Parse(file.ReadLine());

        /* Read the first line of text to display in the on-screen text box */
        textObject.text = fileLines[nextLine++];
    }
	
	// Update is called once per frame
    /* Move to the next line of text when WASD, the arrow keys, the spacebar, or the left mouse button are pressed */
	void Update () {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) ||
            Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow)
            || Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
            /* If the appropriate line of text has been reached, display the first button */
            if (nextLine == linesUntilButtons) {
                button1.SetActive(true);
                button2.SetActive(true);
            }
            else { /* Move to the next line of text */
                if (nextLine < numOfLines) {
                    textObject.text = fileLines[nextLine++];
                }
                else { /* After the last line of the text file has been read, change to the next scene */
                    SceneManager.LoadScene(sceneToChangeTo);
                }
            }
        }
	}

    /* Display the text corresponding to the first option */
    void Button1Clicked() {
        button1.SetActive(false);
        button2.SetActive(false);
 
        /* Read the line of the text for the first option, then skip over the line for the second option */
        if (nextLine < numOfLines) {
            textObject.text = fileLines[nextLine++];
            nextLine++;
        }
        else { /* After the last line of the text file has been read, change to the next scene */
              SceneManager.LoadScene(sceneToChangeTo);
        }
    }

    /* Display the text corresponding to the second option */
    void Button2Clicked()
    {
        button1.SetActive(false);
        button2.SetActive(false);

        /* Skip over the line for the first option, then read the line for the second option */
        if (nextLine < numOfLines)
        {
            nextLine++;
            textObject.text = fileLines[nextLine++];
        }
        else
        { /* After the last line of the text file has been read, change to the next scene */
            SceneManager.LoadScene(sceneToChangeTo);
        }
    }
}