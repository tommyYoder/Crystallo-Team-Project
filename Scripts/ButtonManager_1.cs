using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager_1 : MonoBehaviour
{
    public void GameOverBtn(string newGameLevel)                   // Loads game when game over button is pressed.
    {
        SceneManager.LoadScene(newGameLevel);
    }
    public void ExitGameBtn()                                      // Ends game application when quit button is pressed. 
    {
        Application.Quit();
    }
}
