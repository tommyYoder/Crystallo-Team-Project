using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PortalLoader : MonoBehaviour
{
    [System.Serializable]
    public struct ButtonPlayerPrefs
    {
        public GameObject gameObject;
        public string playerPrefKey;
    }

    public GameObject LoadingScreen;
    public Slider slider;
    public Text percText;
    public float delay = 2.5f;
    public string newGameLevel;
    public Animator loadingScreen;
    public Animator Fade;
    public Animator fade;

    public AudioSource WarpSound;
    public AudioSource flameSound;
    public AudioSource flameSound1;


    public Player player;


    public static int releasedLevelStatic = 1;
    public int releasedLevel;
    public string nextLevel;

    public ButtonPlayerPrefs[] buttons;


    // Looks to see if the PrefKey has been met to unlock the next level.
    void Awake()
    {
        if (PlayerPrefs.HasKey("Level"))
        {
            releasedLevelStatic = PlayerPrefs.GetInt("Level", releasedLevelStatic);

        }
    }

    // Loops to see if the PrefKey is greater then the current level. If yes, then the next level is unlocked in the menu title screen.
    void Start()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            int score = PlayerPrefs.GetInt(buttons[i].playerPrefKey, 0);
        }
    }

    // Will start the loading phase when entering the portal collider.
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine(LoadLevelAfterDelay(newGameLevel)); 
        }
    }
    // Will load the game in the background after animations are completed, screen fades with animator animation on UI image, 
    // music fades to 0 with animator animator, PlayerPref key allows for the next level to be unlocked, and slider updates with loading progress.
    IEnumerator LoadLevelAfterDelay(string newGameLevel)
    {
        SecretPortalAch.secretPortalAch = true;
        player.rb.isKinematic = true;
        player.rb.useGravity = false;

        if (releasedLevelStatic <= releasedLevel)
        {
            releasedLevelStatic = releasedLevel;
            PlayerPrefs.SetInt("Level", releasedLevelStatic);

        }
        yield return new WaitForSeconds(2);

        LoadingScreen.SetActive(true);
        //GetComponent<Animator>().SetTrigger("Fader");
        loadingScreen.SetTrigger("Fader");
        //GetComponent<Animator>().SetTrigger("Fade");
        Fade.SetTrigger("Fade");
        fade.SetTrigger("Fade");
        WarpSound.Play();                                   // Plays Warp Sound.
        flameSound.Stop();
        flameSound1.Stop();
        player.MoveSound.volume = 0;

        yield return new WaitForSeconds(delay);
        AudioListener.pause = true;              // Will stop all sounds from playing.
        AsyncOperation operation = SceneManager.LoadSceneAsync(newGameLevel);



        // While loop that allows the game to load in the background. Perfect for loading bars or animations!
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            percText.text = progress * 100f + "%";
            yield return null;

        }
    }
}
