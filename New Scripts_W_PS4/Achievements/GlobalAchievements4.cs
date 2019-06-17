using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Steamworks;

public class GlobalAchievements4 : MonoBehaviour
{
    //General Variables
    public GameObject imagePanel1;
    public AudioSource achSound;
    public bool achActive1 = false;
    public GameObject achTitle1;
    public GameObject achDesc1;

    //Final Candy Specifics
    public GameObject achImage1;
    public static int candyLastLevelCount;
    public int candyAchTriggerLastLevel = 5;
    public int candyCodeLastLevel;

    //Final Candy Hard Mode Specifics
    public static int candyLastLevelCountHardMode;
    public int candyAchTriggerLastLevelHardMode = 10;
    public int candyCodeLastLevelHardMode;


    // Update is called once per frame
    void Update()
    {
        LockAch.valueFinalCandy = PlayerPrefs.GetInt("Candy5");
        LockAch.valueFinalCandy1 = PlayerPrefs.GetInt("Candy10");

        //PlayerPrefs.DeleteAll();
        candyCodeLastLevel = PlayerPrefs.GetInt("LastLevelCandy");
        candyCodeLastLevelHardMode = PlayerPrefs.GetInt("LastLevelCandyhardMode");

        // Looks to see if the candy count doesn't equal 5.
        if (candyLastLevelCount == candyAchTriggerLastLevel && candyCodeLastLevel != 5)
        {
            StartCoroutine(LastLevelCandy());
        }

        // Looks to see if the candy count doesn't equal 10.
        if (candyLastLevelCountHardMode == candyAchTriggerLastLevelHardMode && candyCodeLastLevelHardMode != 10)
        {
            StartCoroutine(LastLevelCandyHardMode());
        }

        // If player collides with the candy, then achievment is met!
        IEnumerator LastLevelCandy()
        {
            achActive1 = true;
            candyCodeLastLevel = 5;
            PlayerPrefs.SetInt("LastLevelCandy", candyCodeLastLevel);
            PlayerPrefs.SetInt("Candy5", 1);
            achSound.Play();
            achImage1.SetActive(true);
            achTitle1.GetComponent<Text>().text = "Final Candy";
            achDesc1.GetComponent<Text>().text = "You collected the hidden final candy.";
            imagePanel1.SetActive(true);

            SteamUserStats.SetAchievement("Achievement_08");
            SteamUserStats.StoreStats();

            yield return new WaitForSeconds(7);
            achImage1.SetActive(false);
            imagePanel1.SetActive(false);
            achTitle1.GetComponent<Text>().text = "";
            achDesc1.GetComponent<Text>().text = "";
            achActive1 = false;
        }

        // If player collides with the candy, then achievment is met!
        IEnumerator LastLevelCandyHardMode()
        {
            achActive1 = true;
            candyCodeLastLevelHardMode = 10;
            PlayerPrefs.SetInt("LastLevelCandyhardMode", candyCodeLastLevelHardMode);
            PlayerPrefs.SetInt("Candy10", 1);
            achSound.Play();
            achImage1.SetActive(true);
            achTitle1.GetComponent<Text>().text = "Final Candy 2";
            achDesc1.GetComponent<Text>().text = "You collected the hidden final candy.";
            imagePanel1.SetActive(true);

            SteamUserStats.SetAchievement("Achievement_13");
            SteamUserStats.StoreStats();

            yield return new WaitForSeconds(7);
            achImage1.SetActive(false);
            imagePanel1.SetActive(false);
            achTitle1.GetComponent<Text>().text = "";
            achDesc1.GetComponent<Text>().text = "";
            achActive1 = false;
        }
    }
}
