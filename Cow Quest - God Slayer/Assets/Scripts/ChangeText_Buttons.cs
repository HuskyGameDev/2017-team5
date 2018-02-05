using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/* Change the text in the text box whenever the player presses WASD, the arrow keys, the space bar, or the left mouse button
 * by reading the next line from the provided text file, and display buttons after the appropriate line has been read */
public class ChangeText_Buttons : MonoBehaviour {
    public Text textObject;               // The text object to be modified in the text box on screen
    public TextAsset textFile;      // File to read the text from
    public string sceneChangeYes;   // Scene to change to if the player selects the "Yes" option
    public string sceneChangeNo;    // Scene to change to if the player selects the "No" option

    public GameObject firstButton;  // Buttons to be displayed
    public GameObject yesButton;    // Buttons must be defined as GameObject types to use the SetActive() function
    public GameObject noButton;
    Button firstBtn;                // Buttons must also be defined as Button types to use the onClick() function
    Button yesBtn; Button noBtn;


    string[] fileLines; // Array to store the lines of the text file being read
    int numOfLines;     // Total number of lines in the text file being read
    int nextLine;       // Line number of the next line to be read
 
    int linesUntilFirstButton;      // Number of lines of text until the first button should be displayed
    int linesUntilYesNo;            // Number of lines of text until the Yes and No buttons should be displayed
    //int linesOfNoText;            // Number of lines of the "No" response text

	// Use this for initialization
	void Start () {
        /* Redefine buttons as Button types in order to use the onClick() function
        * and add listeners */
        firstBtn = firstButton.GetComponent<Button>();
        firstBtn.onClick.AddListener(ContinueText);

        yesBtn = yesButton.GetComponent<Button>();
        yesBtn.onClick.AddListener(YesButtonClicked);

        noBtn = noButton.GetComponent<Button>();
        noBtn.onClick.AddListener(NoButtonClicked);

        /* Make the buttons inactive at the start of the scene */
        firstButton.SetActive(false);
        yesButton.SetActive(false);
        noButton.SetActive(false);

        /* Split the lines of the text file at every newline character */
        string fileText = textFile.text;
        fileLines = Regex.Split(fileText, "\r\n|\n|\r");
        numOfLines = fileLines.Length;

        /* Read the first two lines of the text file to get the number of lines until the buttons should appear */
        nextLine = 0;
        linesUntilFirstButton = int.Parse(fileLines[nextLine++]);
        linesUntilYesNo = int.Parse(fileLines[nextLine++]);
        print("linesUntilFirstButton = " + linesUntilFirstButton + ", linesUntilYesNo = " + linesUntilYesNo);

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
            if (nextLine == linesUntilFirstButton) {
                firstButton.SetActive(true);
            }
            /* If the appropriate line of text has been reached, display the Yes and No buttons */
            else if (nextLine == linesUntilYesNo) {
                yesButton.SetActive(true);
                noButton.SetActive(true);              
            }
            else { /* Move to the next line of text */
                if (nextLine < numOfLines) {
                    textObject.text = fileLines[nextLine++];
                }
                else { /* After the last line of the text file has been read, change to the next scene */
                    SceneManager.LoadScene(sceneChangeYes);
                }
            }
        }
	}

    /* Continue reading through text for the current scene */
    void ContinueText() {
        firstButton.SetActive(false);

        /* Read the next line of text */
        if (nextLine < numOfLines) {
            textObject.text = fileLines[nextLine++];
        }
        else { /* After the last line of the text file has been read, change to the next scene */
            SceneManager.LoadScene(sceneChangeYes);
        }
    }

    /* Continue reading through text for the current scene */
    void YesButtonClicked() {
        yesButton.SetActive(false);
        noButton.SetActive(false);

        ///* Read over the appropriate number of lines to skip the text for the "No" option */
        //for (int i = 1; i <= linesOfNoText; i++) {
        //    file.ReadLine();
        //    linesRead++;
        //
        ///* If there was no text for the "No" option, read the first line of the text for the "Yes" option */
 
        /* Read the first line of the text for the "Yes" option */
        if (nextLine < numOfLines) {
            textObject.text = fileLines[nextLine++];
        }
        else { /* After the last line of the text file has been read, change to the next scene */
              SceneManager.LoadScene(sceneChangeYes);
        }
    }

    /* Change to the scene for the "No" option */
    void NoButtonClicked() {
        SceneManager.LoadScene(sceneChangeNo);
    }
}