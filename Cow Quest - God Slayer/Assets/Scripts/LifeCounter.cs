using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCounter : MonoBehaviour {
    private int lives;
    public int startlives;

    private Text t;

 

    private void Start()
    {
         
            t = GetComponent<Text>();
            lives = startlives;
        
    }

    private void Update()
    {
        t.text = "X " + lives;
    }

    public void RemoveFromLives()
    {
        lives--;

        if ( lives == 0 )
        {
            t.text = "Game Over";
			Application.LoadLevel ("death");
            //UnityEditor.EditorApplication.isPlaying = false;
        }

    }
}
