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

    private void Update()
    {
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
