using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Steamworks;

public class GlobalAchievements3 : MonoBehaviour
{
    //General Variables
    public GameObject imagePanel1;
    public AudioSource achSound;
    public bool achActive1 = false;
    public GameObject achTitle1;
    public GameObject achDesc1;

    //Fire Candy Specifics
    public GameObject achImage1;
    public static int candyFireCount;
    public int candyAchTriggerFire = 4;
    public int candyCodeFire;

    //Fire Candy Hard Mode Specifics
    public static int candyFireCountHardMode;
    public int candyAchTriggerFireHardMode = 9;
    public int candyCodeFireHardMode;


    // Update is called once per frame
    void Update()
    {
        LockAch.valueFireCandy = PlayerPrefs.GetInt("Candy4");
        LockAch.valueFireCandy1 = PlayerPrefs.GetInt("Candy9");

        //PlayerPrefs.DeleteAll();
        candyCodeFire = PlayerPrefs.GetInt("FireCandy");
        candyCodeFireHardMode = PlayerPrefs.GetInt("FireCandyHardMode");

        if (candyFireCount == candyAchTriggerFire && candyCodeFire != 4)
        {
            StartCoroutine(FireCandy());
        }

        if (candyFireCountHardMode == candyAchTriggerFireHardMode && candyCodeFireHardMode != 9)
        {
            StartCoroutine(FireCandyHardMode());
        }

        // If player collides with the candy, then achievment is met!
        IEnumerator FireCandy()
        {
            achActive1 = true;
            candyCodeFire = 4;
            PlayerPrefs.SetInt("FireCandy", candyCodeFire);
            PlayerPrefs.SetInt("Candy4", 1);
            achSound.Play();
            achImage1.SetActive(true);
            achTitle1.GetComponent<Text>().text = "Fire Candy";
            achDesc1.GetComponent<Text>().text = "You collected the hidden fire candy.";
            imagePanel1.SetActive(true);

            SteamUserStats.SetAchievement("Achievement_07");
            SteamUserStats.StoreStats();

            yield return new WaitForSeconds(7);
            achImage1.SetActive(false);
            imagePanel1.SetActive(false);
            achTitle1.GetComponent<Text>().text = "";
            achDesc1.GetComponent<Text>().text = "";
            achActive1 = false;
        }

        // If player collides with the candy, then achievment is met!
        IEnumerator FireCandyHardMode()
        {
            achActive1 = true;
            candyCodeFireHardMode = 9;
            PlayerPrefs.SetInt("FireCandyHardMode", candyCodeFireHardMode);
            PlayerPrefs.SetInt("Candy9", 1);
            achSound.Play();
            achImage1.SetActive(true);
            achTitle1.GetComponent<Text>().text = "Fire Candy 2";
            achDesc1.GetComponent<Text>().text = "You collected the hidden fire candy.";
            imagePanel1.SetActive(true);

            SteamUserStats.SetAchievement("Achievement_12");
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
