using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelScreenLoader : MonoBehaviour {

    public GameObject LoadingImage;
    public Slider slider;
    public Text percText;
    public float delay = 2.5f;
    public string newGameLevel;
    public Animator loadingScreen;

    // Use this for initialization
    IEnumerator Start () {
        yield return new WaitForSeconds(4.5f);   // Yields anything from happening until animation is completed.
        StartCoroutine(LoadLevelAfterDelay(newGameLevel));  // Will start function after animation is completed.
    }

    // Will load the game in the background after animations are completed, screen fades with animator animation on UI image, music fades to 0 with animator animator, and slider will updates with loading progress.
    IEnumerator LoadLevelAfterDelay(string newGameLevel)
    {
        LoadingImage.SetActive(true);
        GetComponent<Animator>().SetTrigger("Fader");
        loadingScreen.SetTrigger("Fader");
        yield return new WaitForSeconds(delay);
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

