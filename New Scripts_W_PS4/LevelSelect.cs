using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{

    [System.Serializable]
    public struct ButtonPlayerPrefs
    {
        public GameObject gameObject;
        public string playerPrefKey;
    }

    public GameObject loadScreen;
    public Slider loadBar;
    public Text percText;
    public Animator loadingScreen;
    public float delay = 2.5f;
    public Animator Fade;
    public AudioSource clickSound;
    public AudioSource flameSound;

    public ButtonPlayerPrefs[] buttons;

    public static int releasedLevelStatic = 1;
    public int releasedLevel;
    public string nextLevel;

    //Looks to see if the playerPrefKey has been met. If it has, then the level is unlocked in the menu screen. If not, then the button is not enable.
    void Awake()
    {
        //PlayerPrefs.DeleteAll();
        if (PlayerPrefs.HasKey("Level"))
        {
            releasedLevelStatic = PlayerPrefs.GetInt("Level", releasedLevelStatic);

        }
    }

    // Loops to see if the key is greater then the previous level.
    void Start()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            int score = PlayerPrefs.GetInt(buttons[i].playerPrefKey, 0);
        }
    }

    // Starts each level when the button is pressed.
    public void OnButtonPress(string newGameLevel)
    {
        StartCoroutine(LoadAsynchronously(newGameLevel));
    }
    public IEnumerator LoadAsynchronously(string newGameLevel)
    {
        clickSound.Play();
        flameSound.Stop();
        loadScreen.SetActive(true);
        loadingScreen.SetTrigger("Fade1");
        Fade.SetTrigger("Fade");

        yield return new WaitForSeconds(delay);
        AsyncOperation operation = SceneManager.LoadSceneAsync(newGameLevel);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            loadBar.value = progress;
            percText.text = progress * 100 + "%";
            yield return null;
        }

    }

    // End the game when button is pressed.
    public void OnQuit()
    {
        Application.Quit();
    }

    // Allowed for the next level to be unlocked when winning conditions have been met.
    public void ButtonNextLevel(string newGameLevel)
    {
        StartCoroutine(LoadAsynchronously(newGameLevel));
        if (releasedLevelStatic <= releasedLevel)
        {
            releasedLevelStatic = releasedLevel;
            PlayerPrefs.SetInt("Level", releasedLevelStatic);

        }
    }
}
