using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeCounter : MonoBehaviour 
{
    private int lives;
    public int startlives;
    private Text lifeText;

    private void Start()
    {
            lifeText = GetComponent<Text>();
            lives = startlives;
    }

<<<<<<< HEAD
    private void Update()
    {
=======
    private void Update(){
>>>>>>> 9af39300d26a0939acfb1d960f6d680018d56ca0
        lifeText.text = "Lives: " + lives;
    }

    public void RemoveFromLives()
    {
        lives--;
		if (lives <= 0)
        {
            //lifeText.text = "Game Over";
            SceneManager.LoadScene("death");
        }
    }

    public void AddLife()
    {
        lives++;
    }

}
