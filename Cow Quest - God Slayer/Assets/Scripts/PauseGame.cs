using UnityEngine;
using UnityEngine.UI;
<<<<<<< HEAD
using UnityEngine.SceneManagement;
=======
>>>>>>> 9af39300d26a0939acfb1d960f6d680018d56ca0
using System.Collections;
using System.Collections.Generic;

public class PauseGame : MonoBehaviour {

	// window objects
	public Transform PauseMenu;
	public Transform HelpMenu;
	public Transform QuitMenu;
<<<<<<< HEAD
	public Transform HUD;
=======
	public Transform UI;
>>>>>>> 9af39300d26a0939acfb1d960f6d680018d56ca0

	// pause menu buttons
	public Button PauseResumeButton;
	public Button HelpButton;
	public Button QuitButton;

	// help menu buttons
	public Button HelpResumeButton;
	public Button ToMenu;

	// quit menu buttons
	public Button YesQuit;
	public Button NoQuit;

 	void Start()
    {
		// pause menu button events
        Button pauseResume = PauseResumeButton.GetComponent<Button>();
        pauseResume.onClick.AddListener(Pause);

		Button help = HelpButton.GetComponent<Button>();
		help.onClick.AddListener(ShowHelp);

		Button quit = QuitButton.GetComponent<Button>();
		quit.onClick.AddListener(Quit);

		// help menu button events
		Button helpResume = HelpResumeButton.GetComponent<Button>();
        helpResume.onClick.AddListener(Pause);

		Button menu = ToMenu.GetComponent<Button>();
        menu.onClick.AddListener(ShowHelp);

		// quit menu buttons
		Button yes = YesQuit.GetComponent<Button>();
        yes.onClick.AddListener(Quit);

		Button no = NoQuit.GetComponent<Button>();
        no.onClick.AddListener(Pause);

    }

	void Update() 
	{
		if (Input.GetKeyDown(KeyCode.Escape)) 
		{
			Pause();
		}
	}
	
	public void Pause()
	{
		if (PauseMenu.gameObject.activeInHierarchy == false && HelpMenu.gameObject.activeInHierarchy == false && QuitMenu.gameObject.activeInHierarchy == false) 
		{
			Time.timeScale = 0;
			PauseMenu.gameObject.SetActive(true);
			HelpMenu.gameObject.SetActive(false);
			QuitMenu.gameObject.SetActive(false);
<<<<<<< HEAD
			HUD.gameObject.SetActive(false);
=======
			UI.gameObject.SetActive(false);
>>>>>>> 9af39300d26a0939acfb1d960f6d680018d56ca0
		}
		else if (PauseMenu.gameObject.activeInHierarchy == false && QuitMenu.gameObject.activeInHierarchy == true) 
		{
			PauseMenu.gameObject.SetActive(true);
			QuitMenu.gameObject.SetActive(false);
		}
		else if (PauseMenu.gameObject.activeInHierarchy == false && HelpMenu.gameObject.activeInHierarchy == true) 
		{
			PauseMenu.gameObject.SetActive(false);
			HelpMenu.gameObject.SetActive(false);
<<<<<<< HEAD
			HUD.gameObject.SetActive(true);
=======
			UI.gameObject.SetActive(true);
>>>>>>> 9af39300d26a0939acfb1d960f6d680018d56ca0
			Time.timeScale = 1;
		}
		else
		{
			PauseMenu.gameObject.SetActive(false);
			HelpMenu.gameObject.SetActive(false);
<<<<<<< HEAD
			HUD.gameObject.SetActive(true);
=======
			UI.gameObject.SetActive(true);
>>>>>>> 9af39300d26a0939acfb1d960f6d680018d56ca0
			Time.timeScale = 1;
		}
	}

	public void ShowHelp()
	{
		if (HelpMenu.gameObject.activeInHierarchy == false)
		{
			PauseMenu.gameObject.SetActive(false);
			HelpMenu.gameObject.SetActive(true);
		}
		else
		{
			PauseMenu.gameObject.SetActive(true);
			HelpMenu.gameObject.SetActive(false);
		}
	}

	public void Quit()
	{
		if (QuitMenu.gameObject.activeInHierarchy == false)
		{
			PauseMenu.gameObject.SetActive(false);
			QuitMenu.gameObject.SetActive(true);
		}
		else
		{
			PauseMenu.gameObject.SetActive(false);
			QuitMenu.gameObject.SetActive(false);
			Time.timeScale = 1;
<<<<<<< HEAD
			SceneManager.LoadScene("Menu");
=======
			Application.LoadLevel("Menu");
>>>>>>> 9af39300d26a0939acfb1d960f6d680018d56ca0
		}
	}
}