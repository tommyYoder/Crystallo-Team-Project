using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Steamworks;

public class GlobalAchievements1 : MonoBehaviour
{
    //General Variables
    public GameObject imagePanel1;
    public AudioSource achSound;
    public bool achActive1 = false;
    public GameObject achTitle1;
    public GameObject achDesc1;

    //Water Candy Specifics
    public GameObject achImage1;
    public static int candyWaterCount;
    public int candyAchTriggerWater = 2;
    public int candyCodeWater;

    // Water Candy Hard Mode Specifics
    public static int candyWaterHardModeCount;
    public int candyAchTriggerWaterhardMode = 7;
    public int candyCodeWaterHardMode;


    // Update is called once per frame
    void Update()
    {
        LockAch.valueWaterCandy = PlayerPrefs.GetInt("Candy2");
        LockAch.valueWaterCandy1 = PlayerPrefs.GetInt("Candy7");

        //PlayerPrefs.DeleteAll();
        candyCodeWater = PlayerPrefs.GetInt("WaterCandy");
        candyCodeWaterHardMode = PlayerPrefs.GetInt("WaterCandyHardMode");

        if (candyWaterCount == candyAchTriggerWater && candyCodeWater != 2)
        {
            StartCoroutine(WaterCandy());
        }

        if (candyWaterHardModeCount == candyAchTriggerWaterhardMode && candyCodeWaterHardMode != 7)
        {
            StartCoroutine(WaterCandyHardMode());
        }

        // If player collides with the candy, then achievment is met!
        IEnumerator WaterCandy()
        {
            achActive1 = true;
            candyCodeWater = 2;
            PlayerPrefs.SetInt("WaterCandy", candyCodeWater);
            PlayerPrefs.SetInt("Candy2", 1);
            achSound.Play();
            achImage1.SetActive(true);
            achTitle1.GetComponent<Text>().text = "Water Candy";
            achDesc1.GetComponent<Text>().text = "You collected the hidden water candy.";
            imagePanel1.SetActive(true);

            SteamUserStats.SetAchievement("Achievement_05");
            SteamUserStats.StoreStats();

            yield return new WaitForSeconds(7);
            achImage1.SetActive(false);
            imagePanel1.SetActive(false);
            achTitle1.GetComponent<Text>().text = "";
            achDesc1.GetComponent<Text>().text = "";
            achActive1 = false;
        }

        // If player collides with the candy, then achievment is met!
        IEnumerator WaterCandyHardMode()
        {
            achActive1 = true;
            candyCodeWaterHardMode = 7;
            PlayerPrefs.SetInt("WaterCandyHardMode", candyCodeWaterHardMode);
            PlayerPrefs.SetInt("Candy7", 1);
            achSound.Play();
            achImage1.SetActive(true);
            achTitle1.GetComponent<Text>().text = "Water Candy 3";
            achDesc1.GetComponent<Text>().text = "You collected the hidden water candy.";
            imagePanel1.SetActive(true);

            SteamUserStats.SetAchievement("Achievement_10");
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
