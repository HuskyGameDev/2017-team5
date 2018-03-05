using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCounter : MonoBehaviour {
    private int lives;
    public int startlives;
    private Text lifeText;
	//public ChangeScene SceneChanger;
    private void Start(){
            lifeText = GetComponent<Text>();
            lives = startlives;
    }

    private void Update(){
        lifeText.text = "Lives: " + lives;
    }

    public void RemoveFromLives(){
        lives--;
		if (lives <= 0){
            //lifeText.text = "Game Over";
			Application.LoadLevel("death");
        }

    }
}
