using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PauseGame : MonoBehaviour {

	// window objects
	public Transform PauseMenu;
	public Transform HelpMenu;
	public Transform QuitMenu;
	public Transform UI;

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
			UI.gameObject.SetActive(false);
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
			UI.gameObject.SetActive(true);
			Time.timeScale = 1;
		}
		else
		{
			PauseMenu.gameObject.SetActive(false);
			HelpMenu.gameObject.SetActive(false);
			UI.gameObject.SetActive(true);
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
			Application.LoadLevel("Menu");
		}
	}
}