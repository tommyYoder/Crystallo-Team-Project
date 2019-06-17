﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager1 : MonoBehaviour
{
 
    //Use for main menu.
    public GameObject LoadingScreen;
    public Slider slider;
    public Text percText;
    public Animator loadingScreen;
    public float delay = 2.5f;
    public Animator Fade;


    public int Level;
    public Image Image;
    private string LevelString;

    // Looks to see if the level button is unlocked or not. 
    void Start()
    {
        if (LevelSelect.releasedLevelStatic >= Level)
        {
            Levelunlocked();
        }
        else
        {
            Levellocked();
        }
    }


    // Sets score to 0, sets deaths to 0, and starts game function when button is clicked.
    public void NewGameBtn(string newGameLevel)                     
    {      
        PlayerPrefs.SetInt("DeathCurrentLives", 0);
        PlayerPrefs.SetInt("CurrentScore", 0);
        LevelString = newGameLevel;
        StartCoroutine(LoadAsynchronously(newGameLevel));
        

    }
    // Will load the game in the background while screen fades with animator animation on UI image, music fades to 0 with animator animator, and slider will updates with loading progress.
    IEnumerator LoadAsynchronously(string newGameLevel)
    {
            LoadingScreen.SetActive(true);
            //GetComponent<Animator>().SetTrigger("Fade1");
            loadingScreen.SetTrigger("Fade1");
            //GetComponent<Animator>().SetTrigger("Fade");
            Fade.SetTrigger("Fade");
            yield return new WaitForSeconds(delay);
            AsyncOperation operation = SceneManager.LoadSceneAsync(newGameLevel);
           
            
         
        // While loop that allows the game to load in the background. Perfect for loading bars or animations!
        while (!operation.isDone)
            {
                float progress = Mathf.Clamp01(operation.progress / .9f);
                slider.value = progress;
                percText.text = progress * 100f + "%";
                yield return null;
              
        }
    }

    // Will disable button and display the key locking image.
    void Levellocked()
    {
        GetComponent<Button>().interactable = false;
        Image.enabled = true;
    }

    // Will enable the button and disable the key locking image.
    void Levelunlocked()
    {
        GetComponent<Button>().interactable = true;
        Image.enabled = false;
    }



    // Ends game application when quit button is pressed. 
    public void ExitGameBtn()                                     
    {
        Application.Quit();
        GetComponent<Animator>().SetTrigger("Fade");
        Fade.SetTrigger("Fade");
    }
}
