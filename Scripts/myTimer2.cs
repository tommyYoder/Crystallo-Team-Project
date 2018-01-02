using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class myTimer2 : MonoBehaviour {

    
    public float myCoolTimer = 200;
    public Text TimerText;
    public bool isActivated = true;

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
        setTimerText();                                              // setTimerText is called.
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        if (isActivated == true)
        {
            myCoolTimer -= Time.deltaTime;                                 // Lowers time by one and will update text thru setTierText command.
            TimerText.text = myCoolTimer.ToString("f0");
            print(myCoolTimer);
            setTimerText();

            if (myCoolTimer <= 10)                 // If time is less than or equal to 10 seconds, then sound will play.
               
                TimerSound.Play();

            if (myCoolTimer <= .5f)
                                                  // If time is less than or equal to 5, then game over screen gets set to true.
                TimerSound.Stop();
            
            if (myCoolTimer <= 0)
            
            StartCoroutine(LoadLevel(newGameLevel));
        }
    }
    // Sets timer text and updates timer when time decreases.
    public void setTimerText()                                    
    {
        TimerText.text = "Time:" + myCoolTimer.ToString("f0");       
    }
    // Will begin to load new game when timer hits zero.
    IEnumerator LoadLevel(string newGameLevel)
    {
        myCoolTimer = 0f;
        isActivated = false;
        LoadingScreen.SetActive(true);
        GetComponent<Animator>().SetTrigger("Fader");               // For loading screen.
        loadingScreen.SetTrigger("Fader");
        GetComponent<Animator>().SetTrigger("Fade");                // For main sound.
        Fade.SetTrigger("Fade");
        GetComponent<Animator>().SetTrigger("Fade");               // For lava sound.
        fade.SetTrigger("Fade");
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(newGameLevel);
    }
}


