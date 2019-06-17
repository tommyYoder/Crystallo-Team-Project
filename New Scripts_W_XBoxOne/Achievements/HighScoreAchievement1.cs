using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Steamworks;

public class HighScoreAchievement1 : MonoBehaviour
{
    //General Variables
    public GameObject imagePanel;
    public AudioSource achSound;
    public bool achActive = false;
    public GameObject achTitle;
    public GameObject achDesc;

    //HighScore HardMode Specifics
    public GameObject achImage;
    public static int scoreCount1;
    public int scoreTrigger = 5;
    public int scoreCode1;

    //Death General Variables
    public GameObject imagePanel1;
    public bool achActive1 = false;
    public GameObject achTitle1;
    public GameObject achDesc1;

    //Death Score Hard Mode
    public GameObject achImage1;
    public static int deathCount1;
    public int deathTrigger = 3;
    public int deathCode1;


    // Update is called once per frame
    void Update()
    {
        //PlayerPrefs.DeleteAll();
        LockAch.valueScoreHardMode = PlayerPrefs.GetInt("ImageScoreHardMode");
        LockAch.valueDeathHardMode = PlayerPrefs.GetInt("ImageDeathEventHardMode");

        scoreCode1 = PlayerPrefs.GetInt("HighScore1");
        deathCode1 = PlayerPrefs.GetInt("DeathAmount1");

        if (scoreCount1 == scoreTrigger && scoreCode1 != 5)
        {
            StartCoroutine(HighScoreAch1());
        }

        if (deathCount1 == deathTrigger && deathCode1 != 3)
        {
            StartCoroutine(DeathAmountAch1());
        }

        IEnumerator HighScoreAch1()
        {
            yield return new WaitForSeconds(1);

            achActive = true;
            scoreCode1 = 5;
            PlayerPrefs.SetInt("HighScore1", scoreCode1);
            PlayerPrefs.SetInt("ImageScoreHardMode", 1);
            achSound.Play();
            achImage.SetActive(true);
            achTitle.GetComponent<Text>().text = "HighScore HardMode";
            achDesc.GetComponent<Text>().text = "You beat the developers high score!";
            imagePanel.SetActive(true);

            SteamUserStats.SetAchievement("Achievement_01");
            SteamUserStats.StoreStats();

            yield return new WaitForSeconds(7);
            achImage.SetActive(false);
            imagePanel.SetActive(false);
            achTitle.GetComponent<Text>().text = "";
            achDesc.GetComponent<Text>().text = "";
            achActive = false;
        }
        IEnumerator DeathAmountAch1()
        {
            yield return new WaitForSeconds(1);

            achActive1 = true;
            deathCode1 = 3;
            PlayerPrefs.SetInt("DeathAmount1", deathCode1);
            PlayerPrefs.SetInt("ImageDeathEventHardMode", 1);
            achSound.Play();
            achImage1.SetActive(true);
            achTitle1.GetComponent<Text>().text = "Death Score";
            achDesc1.GetComponent<Text>().text = "You beat the developers death score!";
            imagePanel1.SetActive(true);

            SteamUserStats.SetAchievement("Achievement_03");
            SteamUserStats.StoreStats();

            yield return new WaitForSeconds(6);
            achImage1.SetActive(false);
            imagePanel1.SetActive(false);
            achTitle1.GetComponent<Text>().text = "";
            achDesc1.GetComponent<Text>().text = "";
            achActive1 = false;
        }
    }
}
