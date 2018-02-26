using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour {
	public Transform PauseMenu;

	void Update() 
	{
		if (Input.GetKeyDown(KeyCode.Escape)) 
		{
			Pause();
		}
	}
	
	public void Pause()
	{
		if (PauseMenu.gameObject.activeInHierarchy == false) 
		{
			Time.timeScale = 0;
			PauseMenu.gameObject.SetActive (true);
		} 
		else 
		{
			PauseMenu.gameObject.SetActive (false);
			Time.timeScale = 1;
		}
	}
}