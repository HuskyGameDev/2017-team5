﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour {
	
	// Update is called once per frame
	public void ChangeToScene(string sceneToChangeTo) {
		Time.timeScale = 1;
		Application.LoadLevel(sceneToChangeTo);
	}
}
