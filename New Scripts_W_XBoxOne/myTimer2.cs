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
    public MonoBehaviour[] disableScripts;

    public int countDown = 10;
    public AudioSource TimerSound;

    public AudioSource deathLaugh;
    public AudioSource shatterNoise;
    public GameObject shatteredOrbart;
    public GameObject originalOrbart;
    public GameObject explosionParticle;

    public GameObject LoadingScreen;
    public float delay = 2.5f;
    public string newGameLevel;
    public Animator loadingScreen;
    public Animator Fade;
    public Animator fade;

    public Player player;


    // Looks for Timer text component.
    public void Start()
    {
        TimerText = GetComponent<Text>();                             // Looks for text UI.
        
    }
    protected virtual void ToggleScripts(bool value)
    {
        foreach(var scripts in disableScripts)
        {
            scripts.enabled = value;
        }
    }

    // Update is called once per frame
    public void Update()
    {
        if (isActivated == true)
        {
            myCoolTimer -= Time.deltaTime;                                 // Lowers time by one and will update text thru setTierText command.
                                                                           //TimerText.text = myCoolTimer.ToString("f0");
            setTimerText();
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
                if(myCoolTimer > 11)
                {
                    TimerSound.Stop();
                }
            }

            if(myCoolTimer <=0 && player.isDead == true)
            {
                StartCoroutine(loadLevel1(newGameLevel));
            }

            if (myCoolTimer <= 0 && player.isDead == false)
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

    // Will allow for the game over screen to activate and no shatter effect will occur.
    IEnumerator loadLevel1(string newGameLevel)
    {
        myCoolTimer = 0f;
        player.MoveSound.volume = 0f;
        TimerSound.Stop();
        ToggleScripts(false);
       

        isActivated = false;
        LoadingScreen.SetActive(true);
        /*   GetComponent<Animator>().SetTrigger("Fader");  */             // For loading screen.
        loadingScreen.SetTrigger("Fader");
        /*GetComponent<Animator>().SetTrigger("Fade"); */               // For main sound.
        Fade.SetTrigger("Fade");
        /* GetComponent<Animator>().SetTrigger("Fade");   */            // For lava sound.
        fade.SetTrigger("Fade");
        yield return new WaitForSeconds(delay);
        AudioListener.pause = true;
        SceneManager.LoadScene(newGameLevel);
    }
   

    // Will begin to load new game when timer hits zero. Orbart will shatter before the game over level loads.
    IEnumerator LoadLevel(string newGameLevel)
    {
        myCoolTimer = 0f;
        player.rb.isKinematic = true;
        player.rb.useGravity = false;
        player.MoveSound.volume = 0f;
        TimerSound.Stop();
        deathLaugh.Play();
        shatterNoise.Play();
        ToggleScripts(false);
        originalOrbart.SetActive(false);
        Instantiate(explosionParticle, player.transform.position, Quaternion.identity);
        Instantiate(shatteredOrbart, player.transform.position, Quaternion.identity);

        isActivated = false;
        LoadingScreen.SetActive(true);
     /*   GetComponent<Animator>().SetTrigger("Fader");  */             // For loading screen.
        loadingScreen.SetTrigger("Fader");
        /*GetComponent<Animator>().SetTrigger("Fade"); */               // For main sound.
        Fade.SetTrigger("Fade");
       /* GetComponent<Animator>().SetTrigger("Fade");   */            // For lava sound.
        fade.SetTrigger("Fade");
        yield return new WaitForSeconds(delay);
        AudioListener.pause = true;
        SceneManager.LoadScene(newGameLevel);
    }
  
}


