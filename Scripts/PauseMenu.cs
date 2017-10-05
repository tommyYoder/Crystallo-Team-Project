using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public bool isPaused;

    public string mainMenu;

    public GameObject pauseMenuCanvas;

    void Update()
    {
        if (isPaused)                                     // If pause is true, then canvas is true and time scale is set to 0.
        {
            pauseMenuCanvas.SetActive(true);
            Time.timeScale = 0;
        }
        else                                              // If pause is false, then canvas is false and time scale is set to 1.
        {
            pauseMenuCanvas.SetActive(false);
            Time.timeScale = 1;
        }
        if (Input.GetKeyDown("p"))                       // Pause is called when P is pressed.
        {
            isPaused = !isPaused;
        }
    }
    public void Resume()                                // Will resume the game is player clicks on the resume button.
    {
        isPaused = false;
    }
        public void Quit()                             // Will end the game when the quit button is pressed.
    {
        Application.Quit();
    }
}


   
   

