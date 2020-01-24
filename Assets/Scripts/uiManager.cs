using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class uiManager : MonoBehaviour
{

    //game score
    public Text scoreText;
    int score;
    bool gameOver;
    // buttons
    public Button[] buttons;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        // Initialize score
        score = 0; 
        // Invoke scoreUpdate function
        InvokeRepeating("scoreUpdate", 1.0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name != ("menuScene"))
        {
            scoreText.text = "Score: " + score;
        }
    }

    // Start the game
    public void Play()
    {
        // Call the game scene
        //Application.LoadLevel("level1"); //obsolete
        SceneManager.LoadScene("level1");
        //Debug.Log("Scene: " + SceneManager.GetActiveScene().name);
    }

    // Pause the game
    public void Pause()
    {
        // if the game is running
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        // if the game is paused
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }

    // Increase score
    void scoreUpdate()
    {
        if (gameOver == false)
        {
            score += 1;
        }
    }

    // if the car is destroyed - game over
     public void gameOverActivated()
     {
         gameOver = true;
         // if the gamer over, open then menu
        foreach (Button button in buttons)
        {
            button.gameObject.SetActive(true);
        }
     }

     // menus
    public void Restart()
    {
        //Application.LoadLevel(Application.loadedLevel); //obsolete
        SceneManager.LoadScene("level1");
    }

    public void Menu()
    {
        SceneManager.LoadScene("menuScene");
    }

    public void Exit()
    {
        Application.Quit();
    }

}
