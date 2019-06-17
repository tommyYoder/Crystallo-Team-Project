using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Steamworks;

public class HighScoreAchievement : MonoBehaviour
{
 

    //General Variables
    public GameObject imagePanel;

    public AudioSource achSound;


    public bool achActive = false;
    public GameObject achTitle;
    public GameObject achDesc;

    //HighScore Specifics
    public GameObject achImage;
    public static int scoreCount;
    public int scoreTrigger = 4;
    public int scoreCode;

    //Death General Variables
    public GameObject imagePanel1;
    public bool achActive1 = false;
    public GameObject achTitle1;
    public GameObject achDesc1;

    //Death Score Amount
    public GameObject achImage1;
    public static int deathCount;
    public int deathTrigger = 2;
    public int deathCode;




    public void Awake()
    {
        //PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    void Update()
    {
        LockAch.value = PlayerPrefs.GetInt("Image");
        LockAch.valueDeath = PlayerPrefs.GetInt("ImageDeathEvent");

        scoreCode = PlayerPrefs.GetInt("HighScore");    
        deathCode = PlayerPrefs.GetInt("DeathAmount");

        if (scoreCount == scoreTrigger && scoreCode != 4)
        {
            StartCoroutine(HighScoreAch());
        }

        if (deathCount == deathTrigger && deathCode != 2)
        {
            StartCoroutine(DeathAmountAch());
        }

        IEnumerator HighScoreAch()
        {
            achActive = true;
            imagePanel.SetActive(true);
            scoreCode = 4;
            achSound.Play();
            PlayerPrefs.SetInt("HighScore", scoreCode);
            PlayerPrefs.SetInt("Image", 1);
            achImage.SetActive(true);
            achTitle.GetComponent<Text>().text = "HighScore";
            achDesc.GetComponent<Text>().text = "You beat the developers high score!";

            SteamUserStats.SetAchievement("Achievement_00");
            SteamUserStats.StoreStats();

            yield return new WaitForSeconds(6);
            achImage.SetActive(false);
            imagePanel.SetActive(false);
            achTitle.GetComponent<Text>().text = "";
            achDesc.GetComponent<Text>().text = "";
            achActive = false;

        
        }
        IEnumerator DeathAmountAch()
        {
            achActive1 = true;
            deathCode = 2;
            PlayerPrefs.SetInt("DeathAmount", deathCode);
            PlayerPrefs.SetInt("ImageDeathEvent", 1);
            achSound.Play();
            achImage1.SetActive(true);
            achTitle1.GetComponent<Text>().text = "Death Score";
            achDesc1.GetComponent<Text>().text = "You beat the developers death score!";
            imagePanel1.SetActive(true);

            SteamUserStats.SetAchievement("Achievement_02");
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
