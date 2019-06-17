using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Steamworks;

public class SecretPortalAch : MonoBehaviour
{
    //General Variables
    public GameObject imagePanel;
    public AudioSource achSound;
    public bool achActive = false;
    public GameObject achTitle;
    public GameObject achDesc;

    //Secret Portal Specifics
    public GameObject achImage;
    public static bool secretPortalAch = false;
    public int secretPortalCode;

    //Secret Portal Water Level Specifics
    public static bool secretPortalAch1 = false;
    public int secretPortalCode1;

    // Update is called once per frame
    void Update()
    {
        //PlayerPrefs.DeleteAll();

        LockAch.valueSecretPortal = PlayerPrefs.GetInt("SecretPortalArea");
        LockAch.valueSecretWaterPortal = PlayerPrefs.GetInt("SecretPortalAreaWater");

        secretPortalCode = PlayerPrefs.GetInt("SecretPortal");
        secretPortalCode1 = PlayerPrefs.GetInt("SecretPortal1");

        if (secretPortalAch == true && secretPortalCode != 2)
        {
            StartCoroutine(SecretPortalDiscovered());
        }
        if (secretPortalAch1 == true && secretPortalCode1 != 3)
        {
            StartCoroutine(SecretPortalDiscovered1());
        }

        IEnumerator SecretPortalDiscovered()
        {
            achActive = true;
            secretPortalCode = 2;
            PlayerPrefs.SetInt("SecretPortal", secretPortalCode);
            PlayerPrefs.SetInt("SecretPortalArea",1);
            achSound.Play();
            achImage.SetActive(true);
            achTitle.GetComponent<Text>().text = "Secret Portal";
            achDesc.GetComponent<Text>().text = "You discovered the secret portal!";
            imagePanel.SetActive(true);

            SteamUserStats.SetAchievement("Achievement_14");
            SteamUserStats.StoreStats();

            yield return new WaitForSeconds(4);
            achImage.SetActive(false);
            imagePanel.SetActive(false);
            achTitle.GetComponent<Text>().text = "";
            achDesc.GetComponent<Text>().text = "";
            achActive = false;
        }
        IEnumerator SecretPortalDiscovered1()
        {
            achActive = true;
            secretPortalCode1 = 3;
            PlayerPrefs.SetInt("SecretPortal1", secretPortalCode1);
            PlayerPrefs.SetInt("SecretPortalAreaWater", 1);
            achSound.Play();
            achImage.SetActive(true);
            achTitle.GetComponent<Text>().text = "Secret Portal";
            achDesc.GetComponent<Text>().text = "You discovered the secret portal!";
            imagePanel.SetActive(true);

            SteamUserStats.SetAchievement("Achievement_15");
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
