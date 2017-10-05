using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void NewGameBtn(string newGameLevel)                     // Loads game when new game button is pressed.
    {
        SceneManager.LoadScene(newGameLevel);
    }
    public void ExitGameBtn()                                      // Ends game application when quit button is pressed. 
    {
        Application.Quit();
    }
}
