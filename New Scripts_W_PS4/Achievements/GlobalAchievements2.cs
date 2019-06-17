using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Steamworks;

public class GlobalAchievements2 : MonoBehaviour
{
    //General Variables
    public GameObject imagePanel1;
    public AudioSource achSound;
    public bool achActive1 = false;
    public GameObject achTitle1;
    public GameObject achDesc1;

    //Water Candy 2 Specifics
    public GameObject achImage1;
    public static int candyWaterHiddenCount;
    public int candyAchTriggerWaterHidden = 3;
    public int candyCodeWaterHidden;

    // Water Candy Hard Mode Specifics
    public static int candyWaterHiddenCountHardMode;
    public int candyAchTriggerWaterHiddenHardMode = 8;
    public int candyCodeWaterHiddenhardMode;


    // Update is called once per frame
    void Update()
    {
        LockAch.valueWaterCandySecret = PlayerPrefs.GetInt("Candy3");
        LockAch.valueWaterCandySecret1 = PlayerPrefs.GetInt("Candy8");

        //PlayerPrefs.DeleteAll();
        candyCodeWaterHidden = PlayerPrefs.GetInt("WaterCandyHidden");
        candyCodeWaterHiddenhardMode = PlayerPrefs.GetInt("WaterCandyHiddenHardMode");

        if (candyWaterHiddenCount == candyAchTriggerWaterHidden && candyCodeWaterHidden != 3)
        {
            StartCoroutine(WaterCandyHidden());
        }

        if (candyWaterHiddenCountHardMode == candyAchTriggerWaterHiddenHardMode && candyCodeWaterHiddenhardMode != 8)
        {
            StartCoroutine(WaterCandyHiddenHardMode());
        }

        // If player collides with the candy, then achievment is met!
        IEnumerator WaterCandyHidden()
        {
            achActive1 = true;
            candyCodeWaterHidden = 3;
            PlayerPrefs.SetInt("WaterCandyHidden", candyCodeWaterHidden);
            PlayerPrefs.SetInt("Candy3", 1);
            achSound.Play();
            achImage1.SetActive(true);
            achTitle1.GetComponent<Text>().text = "Water Candy 2";
            achDesc1.GetComponent<Text>().text = "You collected the hidden water candy.";
            imagePanel1.SetActive(true);

            SteamUserStats.SetAchievement("Achievement_06");
            SteamUserStats.StoreStats();

            yield return new WaitForSeconds(7);
            achImage1.SetActive(false);
            imagePanel1.SetActive(false);
            achTitle1.GetComponent<Text>().text = "";
            achDesc1.GetComponent<Text>().text = "";
            achActive1 = false;
        }

        // If player collides with the candy, then achievment is met!
        IEnumerator WaterCandyHiddenHardMode()
        {
            achActive1 = true;
            candyCodeWaterHiddenhardMode = 8;
            PlayerPrefs.SetInt("WaterCandyHiddenHardMode", candyCodeWaterHiddenhardMode);
            PlayerPrefs.SetInt("Candy8", 1);
            achSound.Play();
            achImage1.SetActive(true);
            achTitle1.GetComponent<Text>().text = "Water Candy 4";
            achDesc1.GetComponent<Text>().text = "You collected the hidden water candy.";
            imagePanel1.SetActive(true);

            SteamUserStats.SetAchievement("Achievement_11");
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
