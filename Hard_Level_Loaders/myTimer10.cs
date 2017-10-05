using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class myTimer10 : MonoBehaviour {

    public float myCoolTimer = 200;
    public Text TimerText;
    public AudioSource TimerSound;

    LoadingScreen 15

    // Use this for initialization
     void Start()
    {


        TimerText = GetComponent<Text>();                              // Looks for text UI.
        setTimerText();                                                // setTimerText is called.
    }

    // Update is called once per frame
    void Update()
    {
        myCoolTimer -= Time.deltaTime;                                // Lowers time by one and will update text thru setTierText command.
        TimerText.text = myCoolTimer.ToString("f0");
        print(myCoolTimer);
        setTimerText();

        if (myCoolTimer <= 10)                                      // If time is less than or equal to 10 seconds, then sound will play.
            TimerSound.PlayDelayed(-1f);
        if (myCoolTimer <= .5)                                      // If time is less than or equal to .5 seconds, then sound will stop.
            TimerSound.Stop();
        if (myCoolTimer <= 0)                                      // If time is less than or equal to 0, then game over screen gets set to true.
            SceneManager.LoadScene("LoadingScreen 15");

    }

    void setTimerText()                                   // Updates timer text when time decreases
    {
        TimerText.text = "Time:" + myCoolTimer.ToString("f0");

    }
}
