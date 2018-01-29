using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/* Change the text in the text box whenever the player presses WASD, the arrow keys, the space bar, or the left mouse button
 * by reading the next line from the provided text file, and display buttons after the appropriate line has been read */
public class ChangeText_1Button : MonoBehaviour
{
    public Text textObject;         // The text object to be modified in the text box on screen
    public TextAsset textFile;      // File to read the text from
    public string sceneToChangeTo;  // Scene to change to after all the text in the file has been read

    public GameObject Button;       // Button to be displayed
    Button Btn;                     // Button must also be defined as Button type to use the onClick() function

    string[] fileLines;             // Array to store the lines of the text file being read
    int numOfLines;                 // Total number of lines in the text file being read
    int nextLine;                   // Line number of the next line to be read

    int linesUntilButton;           // Number of lines of text until the button should be displayed

    // Use this for initialization
    void Start()
    {
        /* Redefine button as Button type in order to use the onClick() function
        * and add listener */
        Btn = Button.GetComponent<Button>();
        Btn.onClick.AddListener(ContinueText);

        /* Make the button inactive at the start of the scene */
        Button.SetActive(false);

        /* Split the lines of the text file at every newline character */
        string fileText = textFile.text;
        fileLines = Regex.Split(fileText, "\r\n|\n|\r");
        numOfLines = fileLines.Length;

        /* Read the first line of the text file to get the number of lines until the button should appear */
        nextLine = 0;
        linesUntilButton = int.Parse(fileLines[nextLine++]);

        /* Read the first line of text to display in the on-screen text box */
        textObject.text = fileLines[nextLine++];
    }

    // Update is called once per frame
    /* Move to the next line of text when WASD, the arrow keys, the spacebar, or the left mouse button are pressed */
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) ||
            Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow)
            || Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            /* If the appropriate line of text has been reached, display the button */
            if (nextLine == linesUntilButton)
            {
                Button.SetActive(true);
            }
            else
            { /* Move to the next line of text */
                if (nextLine < numOfLines)
                {
                    textObject.text = fileLines[nextLine++];
                }
                else
                { /* After the last line of the text file has been read, change to the next scene */
                    SceneManager.LoadScene(sceneToChangeTo);
                }
            }
        }
    }

    /* Continue reading through text for the current scene */
    void ContinueText()
    {
        Button.SetActive(false);

        /* Read the next line of text */
        if (nextLine < numOfLines)
        {
            textObject.text = fileLines[nextLine++];
        }
        else
        { /* After the last line of the text file has been read, change to the next scene */
            SceneManager.LoadScene(sceneToChangeTo);
        }
    }
}