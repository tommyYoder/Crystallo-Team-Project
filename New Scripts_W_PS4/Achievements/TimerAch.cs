using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Steamworks;

public class TimerAch : MonoBehaviour
{

    //General Variables
    public GameObject imagePanel;
    public AudioSource achSound;
    public bool achActive = false;
    public GameObject achTitle;
    public GameObject achDesc;

    //First Level Timer Specifics
    public GameObject achImage;
    public int timerTrigger = 150;
    public static int timerCount;
    public int timerCode;

    //Second Level Timer Specifics
    public int timerTrigger1 = 65;
    public static int timerCount1;
    public int timerCode1;

    //Third Level Timer Specifics
    public int timerTrigger2 = 150;
    public static int timerCount2;
    public int timerCode2;

    //Fourth Level Timer Specifics
    public int timerTrigger3 = 150;
    public static int timerCount3;
    public int timerCode3;

    //Final Level Timer Specifics Normal Modes
    public int timerTrigger4 = 150;
    public static int timerCount4;
    public int timerCode4;

    // Hard Mode

    //First Level Timer Specifics
    public int timerTrigger5 = 200;
    public static int timerCount5;
    public int timerCode5;

    //Second Level Timer Specifics
    public int timerTrigger6 = 80;
    public static int timerCount6;
    public int timerCode6;

    //Third Level Timer Specifics
    public int timerTrigger7 = 200;
    public static int timerCount7;
    public int timerCode7;

    //Fourth Level Timer Specifics
    public int timerTrigger8 = 200;
    public static int timerCount8;
    public int timerCode8;

    //Final Level Timer Specifics Normal Modes
    public int timerTrigger9 = 200;
    public static int timerCount9;
    public int timerCode9;

    // Update is called once per frame
    void Update()
    {
        //NormalModeLockAch
        LockAch.valueTimedDungeon = PlayerPrefs.GetInt("Timed");
        LockAch.valueTimedSecond = PlayerPrefs.GetInt("Timed1");
        LockAch.valueTimedWater = PlayerPrefs.GetInt("Timed2");
        LockAch.valueTimedFire = PlayerPrefs.GetInt("Timed3");
        LockAch.valueTimedFinal = PlayerPrefs.GetInt("Timed4");

        //HardModeTimerAch
        LockAch.valueTimedDungeon1 = PlayerPrefs.GetInt("Timed5");
        LockAch.valueTimedSecond1 = PlayerPrefs.GetInt("Timed6");
        LockAch.valueTimedWater1 = PlayerPrefs.GetInt("Timed7");
        LockAch.valueTimedFire1 = PlayerPrefs.GetInt("Timed8");
        LockAch.valueTimedFinal1 = PlayerPrefs.GetInt("Timed9");

        //PlayerPrefs.DeleteAll();
        //Normal Mode
        timerCode = PlayerPrefs.GetInt("TimerScore");
        timerCode1 = PlayerPrefs.GetInt("TimerScore1");
        timerCode2 = PlayerPrefs.GetInt("TimerScore2");
        timerCode3 = PlayerPrefs.GetInt("TimerScore3");
        timerCode4 = PlayerPrefs.GetInt("TimerScore4");

        //Hard Mode
        timerCode5 = PlayerPrefs.GetInt("TimerScore5");
        timerCode6 = PlayerPrefs.GetInt("TimerScore6");
        timerCode7 = PlayerPrefs.GetInt("TimerScore7");
        timerCode8 = PlayerPrefs.GetInt("TimerScore8");
        timerCode9 = PlayerPrefs.GetInt("TimerScore9");

        //Normal Mode If Statements

        if (timerCount == timerTrigger && timerCode != 150)
        {
            StartCoroutine(TimerAch());
        }

        if (timerCount1 == timerTrigger1 && timerCode1 != 65)
        {
            StartCoroutine(TimerAch1());
        }

        if (timerCount2 == timerTrigger2 && timerCode2 != 150)
        {
            StartCoroutine(TimerAch2());
        }

        if (timerCount3 == timerTrigger3 && timerCode3 != 150)
        {
            StartCoroutine(TimerAch3());
        }

        if (timerCount4 == timerTrigger4 && timerCode4 != 150)
        {
            StartCoroutine(TimerAch4());
        }

        //Hard Mode If Statements
        if (timerCount5 == timerTrigger5 && timerCode5 != 200)
        {
            StartCoroutine(TimerAch5());
        }

        if (timerCount6 == timerTrigger6 && timerCode6 != 80)
        {
            StartCoroutine(TimerAch6());
        }

        if (timerCount7 == timerTrigger7 && timerCode7 != 200)
        {
            StartCoroutine(TimerAch7());
        }

        if (timerCount8 == timerTrigger8 && timerCode8 != 200)
        {
            StartCoroutine(TimerAch8());
        }

        if (timerCount9 == timerTrigger9 && timerCode9 != 200)
        {
            StartCoroutine(TimerAch9());
        }

        //Normal Mode
        IEnumerator TimerAch()
        {
            achActive = true;
            timerCode = 150;
            PlayerPrefs.SetInt("TimerScore", timerCode);
            PlayerPrefs.SetInt("Timed", 1);
            achSound.Play();
            achImage.SetActive(true);
            achTitle.GetComponent<Text>().text = "Timer";
            achDesc.GetComponent<Text>().text = "Look at you swift runner!";
            imagePanel.SetActive(true);

            SteamUserStats.SetAchievement("Achievement_16");
            SteamUserStats.StoreStats();

            yield return new WaitForSeconds(4);
            achImage.SetActive(false);
            imagePanel.SetActive(false);
            achTitle.GetComponent<Text>().text = "";
            achDesc.GetComponent<Text>().text = "";
            achActive = false;
        }
        IEnumerator TimerAch1()
        {
            achActive = true;
            timerCode1 = 65;
            PlayerPrefs.SetInt("TimerScore1", timerCode1);
            PlayerPrefs.SetInt("Timed1", 1);
            achSound.Play();
            achImage.SetActive(true);
            achTitle.GetComponent<Text>().text = "Timer";
            achDesc.GetComponent<Text>().text = "Look at you swift runner!";
            imagePanel.SetActive(true);

            SteamUserStats.SetAchievement("Achievement_17");
            SteamUserStats.StoreStats();

            yield return new WaitForSeconds(4);
            achImage.SetActive(false);
            imagePanel.SetActive(false);
            achTitle.GetComponent<Text>().text = "";
            achDesc.GetComponent<Text>().text = "";
            achActive = false;
        }
        IEnumerator TimerAch2()
        {
            achActive = true;
            timerCode2 = 150;
            PlayerPrefs.SetInt("TimerScore2", timerCode2);
            PlayerPrefs.SetInt("Timed2", 1);
            achSound.Play();
            achImage.SetActive(true);
            achTitle.GetComponent<Text>().text = "Timer";
            achDesc.GetComponent<Text>().text = "Look at you swift runner!";
            imagePanel.SetActive(true);

            SteamUserStats.SetAchievement("Achievement_18");
            SteamUserStats.StoreStats();

            yield return new WaitForSeconds(4);
            achImage.SetActive(false);
            imagePanel.SetActive(false);
            achTitle.GetComponent<Text>().text = "";
            achDesc.GetComponent<Text>().text = "";
            achActive = false;
        }
        IEnumerator TimerAch3()
        {
            achActive = true;
            timerCode3 = 150;
            PlayerPrefs.SetInt("TimerScore3", timerCode3);
            PlayerPrefs.SetInt("Timed3", 1);
            achSound.Play();
            achImage.SetActive(true);
            achTitle.GetComponent<Text>().text = "Timer";
            achDesc.GetComponent<Text>().text = "Look at you swift runner!";
            imagePanel.SetActive(true);

            SteamUserStats.SetAchievement("Achievement_19");
            SteamUserStats.StoreStats();

            yield return new WaitForSeconds(4);
            achImage.SetActive(false);
            imagePanel.SetActive(false);
            achTitle.GetComponent<Text>().text = "";
            achDesc.GetComponent<Text>().text = "";
            achActive = false;
        }
        IEnumerator TimerAch4()
        {
            achActive = true;
            timerCode4 = 150;
            PlayerPrefs.SetInt("TimerScore4", timerCode4);
            PlayerPrefs.SetInt("Timed4", 1);
            achSound.Play();
            achImage.SetActive(true);
            achTitle.GetComponent<Text>().text = "Timer";
            achDesc.GetComponent<Text>().text = "Look at you swift runner!";
            imagePanel.SetActive(true);

            SteamUserStats.SetAchievement("Achievement_20");
            SteamUserStats.StoreStats();

            yield return new WaitForSeconds(4);
            achImage.SetActive(false);
            imagePanel.SetActive(false);
            achTitle.GetComponent<Text>().text = "";
            achDesc.GetComponent<Text>().text = "";
            achActive = false;
        }

        //Hard Mode
        IEnumerator TimerAch5()
        {
            achActive = true;
            timerCode5 = 200;
            PlayerPrefs.SetInt("TimerScore5", timerCode5);
            PlayerPrefs.SetInt("Timed5", 1);
            achSound.Play();
            achImage.SetActive(true);
            achTitle.GetComponent<Text>().text = "Timer";
            achDesc.GetComponent<Text>().text = "Look at you swift runner!";
            imagePanel.SetActive(true);

            SteamUserStats.SetAchievement("Achievement_21");
            SteamUserStats.StoreStats();

            yield return new WaitForSeconds(4);
            achImage.SetActive(false);
            imagePanel.SetActive(false);
            achTitle.GetComponent<Text>().text = "";
            achDesc.GetComponent<Text>().text = "";
            achActive = false;
        }
        IEnumerator TimerAch6()
        {
            achActive = true;
            timerCode6 = 80;
            PlayerPrefs.SetInt("TimerScore6", timerCode6);
            PlayerPrefs.SetInt("Timed6", 1);
            achSound.Play();
            achImage.SetActive(true);
            achTitle.GetComponent<Text>().text = "Timer";
            achDesc.GetComponent<Text>().text = "Look at you swift runner!";
            imagePanel.SetActive(true);

            SteamUserStats.SetAchievement("Achievement_22");
            SteamUserStats.StoreStats();

            yield return new WaitForSeconds(4);
            achImage.SetActive(false);
            imagePanel.SetActive(false);
            achTitle.GetComponent<Text>().text = "";
            achDesc.GetComponent<Text>().text = "";
            achActive = false;
        }
        IEnumerator TimerAch7()
        {
            achActive = true;
            timerCode7 = 200;
            PlayerPrefs.SetInt("TimerScore7", timerCode7);
            PlayerPrefs.SetInt("Timed7", 1);
            achSound.Play();
            achImage.SetActive(true);
            achTitle.GetComponent<Text>().text = "Timer";
            achDesc.GetComponent<Text>().text = "Look at you swift runner!";
            imagePanel.SetActive(true);

            SteamUserStats.SetAchievement("Achievement_23");
            SteamUserStats.StoreStats();

            yield return new WaitForSeconds(4);
            achImage.SetActive(false);
            imagePanel.SetActive(false);
            achTitle.GetComponent<Text>().text = "";
            achDesc.GetComponent<Text>().text = "";
            achActive = false;
        }
        IEnumerator TimerAch8()
        {
            achActive = true;
            timerCode8 = 200;
            PlayerPrefs.SetInt("TimerScore8", timerCode8);
            PlayerPrefs.SetInt("Timed8", 1);
            achSound.Play();
            achImage.SetActive(true);
            achTitle.GetComponent<Text>().text = "Timer";
            achDesc.GetComponent<Text>().text = "Look at you swift runner!";
            imagePanel.SetActive(true);

            SteamUserStats.SetAchievement("Achievement_24");
            SteamUserStats.StoreStats();

            yield return new WaitForSeconds(4);
            achImage.SetActive(false);
            imagePanel.SetActive(false);
            achTitle.GetComponent<Text>().text = "";
            achDesc.GetComponent<Text>().text = "";
            achActive = false;
        }
        IEnumerator TimerAch9()
        {
            achActive = true;
            timerCode9 = 200;
            PlayerPrefs.SetInt("TimerScore9", timerCode9);
            PlayerPrefs.SetInt("Timed9", 1);
            achSound.Play();
            achImage.SetActive(true);
            achTitle.GetComponent<Text>().text = "Timer";
            achDesc.GetComponent<Text>().text = "Look at you swift runner!";
            imagePanel.SetActive(true);

            SteamUserStats.SetAchievement("Achievement_25");
            SteamUserStats.StoreStats();

            yield return new WaitForSeconds(4);
            achImage.SetActive(false);
            imagePanel.SetActive(false);
            achTitle.GetComponent<Text>().text = "";
            achDesc.GetComponent<Text>().text = "";
            achActive = false;
        }
    }
}

