using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour {

    public bool isPaused;

    public string mainMenu;

    public Animator[] disableAnim;

    public MonoBehaviour[] disableScripts;

    public GameObject firstObject;
    public GameObject LoadingImage;
    public Slider slider;
    public Text percText;
    public float delay = 2.5f;
    public string newGameLevel;
    public Animator loadingScreen;

    public GameObject pauseMenuCanvas;

    // Will disable/enable the animator on each gameobject assigned. 
    protected virtual void ToggleAnim(bool anim)
    {
        foreach(var animations in disableAnim)
        {
            animations.enabled = anim;
        }
    }

    // Will disable the camera script when player hits the return button.
    protected virtual void ToggleCamera(bool value)
    {
        foreach(var scripts in disableScripts)
        {
            scripts.enabled = value;
        }
    }

    // If pause is true, then canvas is true, sound is paused, Camera script is disabeled, and time scale is set to 0.
    void Update()
    {
        if (Input.GetKeyDown("joystick button 7"))                                  
        {
            Paused();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Paused1();
        }
    }

    public void Paused()
    {
        pauseMenuCanvas.SetActive(true);
        AudioListener.pause = true;
        Time.timeScale = 0;
        ToggleCamera(false);
        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(firstObject, null);
    }

    public void Paused1()
    {
        ToggleCamera(false);
        pauseMenuCanvas.SetActive(true);
        AudioListener.pause = true;
        Time.timeScale = 0;
    }

    // Will resume the game is player clicks on the resume button, sound willl unpause, Camera script will be enabled, and time set to 1.
    public void Resume()                               
    {
        pauseMenuCanvas.SetActive(false);
        AudioListener.pause = false;
        Time.timeScale = 1;
       
        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(null);

        StartCoroutine(EnableJump());
    }

    // Will enable the scripts in the inspector when the timer hits .1 seconds.
    public IEnumerator EnableJump()
    {
        yield return new WaitForSeconds(.1f);
        ToggleCamera(true);
    }

    // Will take you back to the main menu when you hit the return button. Disabled scripts and animators on the assigned gameobects in the inspector.
    public void ReturnToMenu(string newGameLevel)
    {
        Time.timeScale = 1;
        ToggleCamera(false);
        ToggleAnim(false);
        StartCoroutine(LoadScene(newGameLevel));
    }

    // Will load the game in the background after animations are completed, screen fades with animator animation on UI image, music fades to 0 with animator animator, and slider will updates with loading progress.
    public IEnumerator LoadScene(string newGameLevel)
    {
        LoadingImage.SetActive(true);
        //GetComponent<Animator>().SetTrigger("Fader");
        loadingScreen.SetTrigger("Fade1");
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

    // Will end the game when the quit button is pressed.
    public void Quit()                           
    {
            Application.Quit();
        }
    }





