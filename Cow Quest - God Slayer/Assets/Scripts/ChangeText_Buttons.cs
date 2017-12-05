using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/* Change the text in the text box whenever the player presses a key by reading the next line 
 * from the text file, and display buttons after the appropriate line has been read */
public class ChangeText_Buttons : MonoBehaviour {
    public Text text;               // The text object to be modified on screen
    public string filename;         // Name of the file to read the text from
    public string sceneChangeYes;   // Scene to change to if the player selects the "Yes" option
    public string sceneChangeNo;    // Scene to change to if the player selects the "No" option

    public GameObject firstButton;  // Buttons to be displayed
    public GameObject yesButton;    // Buttons must be defined as GameObject types to use the SetActive() function
    public GameObject noButton;
    Button firstBtn;                // Buttons must also be defined as Button types to use the onClick() function
    Button yesBtn; Button noBtn;    

    System.IO.StreamReader file;
    string line;                    // Current line in the file being read
    int linesRead = 1;              // Number of lines that have been read
    int linesUntilFirstButton;      // Number of lines of text until the first button should be displayed
    int linesUntilYesNo;            // Number of lines of text until the Yes and No buttons should be displayed; does not include the first two lines containing integers
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

        /* Read the first two lines of the text file to get the number of lines until the buttons should appear */
        file = new System.IO.StreamReader(filename);
        linesUntilFirstButton = int.Parse(file.ReadLine());
        linesUntilYesNo = int.Parse(file.ReadLine());

        ///* Read the second line of the text file to get the number of lines between the "Yes" and "No" response text */
        //linesOfNoText = int.Parse(file.ReadLine());

        /* Read the first line of text to display in the on-screen text box */
        text.text = file.ReadLine();
    }
	
	// Update is called once per frame
    /* Move to the next line of text when WASD, the arrow keys, or the left mouse button are pressed */
	void Update () {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) ||
            Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow) 
            || Input.GetMouseButtonDown(0)) {
            /* If the appropriate line of text has been reached, display the first button */
            if (linesRead == linesUntilFirstButton) {
                firstButton.SetActive(true);
            }
            /* If the appropriate line of text has been reached, display the Yes and No buttons */
            else if (linesRead == linesUntilYesNo) {
                yesButton.SetActive(true);
                noButton.SetActive(true);              
            }
            else { /* Move to the next line of text */
                if ((line = file.ReadLine()) != null) {
                    text.text = line;
                    linesRead++;
                }
                else { /* After the last line of the text file has been read, change to the next scene */
                    SceneManager.LoadScene(sceneChangeYes);
                }
            }
        }
	}

    /* Continue reading through text for the current scene */
    void ContinueText()
    {
        firstButton.SetActive(false);

        /* Read the next line of text */
        if ((line = file.ReadLine()) != null)
        {
            text.text = line;
            linesRead++;
        }
        else
        { /* After the last line of the text file has been read, change to the next scene */
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
        if ((line = file.ReadLine()) != null) {
            text.text = line;
            linesRead++;
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