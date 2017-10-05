using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager_2 : MonoBehaviour
{
    public void PlayAgainBtn(string newGameLevel)                  // Loads game when play again button is pressed.
    {
        SceneManager.LoadScene(newGameLevel);
    }
    public void ExitGameBtn()                                      // Ends game application when quit button is pressed. 
    {
        Application.Quit();
    }
}
