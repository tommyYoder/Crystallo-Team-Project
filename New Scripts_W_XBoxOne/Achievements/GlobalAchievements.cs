using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Steamworks;

public class GlobalAchievements : MonoBehaviour
{
    //General Variables
    public GameObject imagePanel;
    public AudioSource achSound;
    public bool achActive = false;
    public GameObject achTitle;
    public GameObject achDesc;

    //Dungeon Candy Specifics
    public GameObject achImage;
    public static int candyCount;
    public int candyAchTrigger = 1;
    public int candyCode;

    // Dungeon Candy Hard Mode Specifics
    public static int candyCountHardMode;
    public int candyAchTriggerHardMode = 6;
    public int candyCodeHardMode;

    // Update is called once per frame
    void Update()
    {
        //PlayerPrefs.DeleteAll();
        LockAch.valueCandyDungeon = PlayerPrefs.GetInt("Candy");
        LockAch.valueCandyDungeon1 = PlayerPrefs.GetInt("Candy6");

        candyCode = PlayerPrefs.GetInt("DungeonCandy");
        candyCodeHardMode = PlayerPrefs.GetInt("DungeonCandyHardMode");

        if (candyCount == candyAchTrigger && candyCode != 1)
        {
            StartCoroutine(DungeonCandy());
        }

        if (candyCountHardMode == candyAchTriggerHardMode && candyCodeHardMode != 6)
        {
            StartCoroutine(DungeonCandyHardMode());
        }

        // If player collides with the candy, then achievment is met!
        IEnumerator DungeonCandy()
        {
            achActive = true;
            candyCode = 1;
            PlayerPrefs.SetInt("DungeonCandy", candyCode);
            PlayerPrefs.SetInt("Candy", 1);
            achSound.Play();
            achImage.SetActive(true);
            achTitle.GetComponent<Text>().text = "Dungeon Candy";
            achDesc.GetComponent<Text>().text = "You collected the hidden dungeon candy.";
            imagePanel.SetActive(true);

            SteamUserStats.SetAchievement("Achievement_04");
            SteamUserStats.StoreStats();

            yield return new WaitForSeconds(7);
            achImage.SetActive(false);
            imagePanel.SetActive(false);
            achTitle.GetComponent<Text>().text = "";
            achDesc.GetComponent<Text>().text = "";
            achActive = false;

        }

        // If player collides with the candy, then achievment is met!
        IEnumerator DungeonCandyHardMode()
        {
            achActive = true;
            candyCodeHardMode = 6;
            PlayerPrefs.SetInt("DungeonCandyHardMode", candyCodeHardMode);
            PlayerPrefs.SetInt("Candy6", 1);
            achSound.Play();
            achImage.SetActive(true);
            achTitle.GetComponent<Text>().text = "Dungeon Candy 2";
            achDesc.GetComponent<Text>().text = "You collected the hidden dungeon candy.";
            imagePanel.SetActive(true);

            SteamUserStats.SetAchievement("Achievement_09");
            SteamUserStats.StoreStats();

            yield return new WaitForSeconds(7);
            achImage.SetActive(false);
            imagePanel.SetActive(false);
            achTitle.GetComponent<Text>().text = "";
            achDesc.GetComponent<Text>().text = "";
            achActive = false;

        }
    }
}
