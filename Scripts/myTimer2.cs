using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class myTimer2 : MonoBehaviour {

    public int timeInSeconds;
    public float myCoolTimer = 200;
    public Text TimerText;
    public bool isActivated = true;

    public int countDown = 10;
    public AudioSource TimerSound;


    public GameObject LoadingScreen;
    public float delay = 2.5f;
    public string newGameLevel;
    public Animator loadingScreen;
    public Animator Fade;
    public Animator fade;


    // Use this for initialization
    public void Start()
    {
        TimerText = GetComponent<Text>();                             // Looks for text UI.
        
    }

    // Update is called once per frame
    public void Update()
    {
        if (isActivated == true)
        {
            myCoolTimer -= Time.deltaTime;                                 // Lowers time by one and will update text thru setTierText command.
            //TimerText.text = myCoolTimer.ToString("f0");
            print(myCoolTimer);
            TimerText.text = "Time: " + FormateTime(myCoolTimer);


            // Looks to see if the timer is above 0. Looks to see if the timer is below 10 seconds. If the timer is below 10 seconds, then the sound gets player once every time the countdown time goes down by one. 
            //  Sets the timer sound volume to .50. If the timer hits 0, then the game begins to load the game over scene.
            if (myCoolTimer > 0.0f)
            {
                if (myCoolTimer < (float)countDown)
                {
                    TimerSound.Play();
                    TimerSound.volume = .50f;
                    countDown--;
                }
            }
            if (myCoolTimer <= 0)
            {
                StartCoroutine(LoadLevel(newGameLevel));
            }
        }
    }
    
     //Sets timer text and updates timer when time decreases.
    public void setTimerText()
    {
        TimerText.text = "Time:" + myCoolTimer.ToString("f0");
    }

    // Formates the time in minutes.
    string FormateTime(float value)
    {
        TimeSpan t = TimeSpan.FromSeconds(value);


        return string.Format("{0:D2}:{1:D2}", t.Minutes, t.Seconds);
    }

    // Will begin to load new game when timer hits zero.
    IEnumerator LoadLevel(string newGameLevel)
    {
        myCoolTimer = 0f;
        TimerSound.Stop();
        isActivated = false;
        LoadingScreen.SetActive(true);
     /*   GetComponent<Animator>().SetTrigger("Fader");  */             // For loading screen.
        loadingScreen.SetTrigger("Fader");
        /*GetComponent<Animator>().SetTrigger("Fade"); */               // For main sound.
        Fade.SetTrigger("Fade");
       /* GetComponent<Animator>().SetTrigger("Fade");   */            // For lava sound.
        fade.SetTrigger("Fade");
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(newGameLevel);
    }
  
}


