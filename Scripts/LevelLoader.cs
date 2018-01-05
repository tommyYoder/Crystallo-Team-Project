using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour {

    public GameObject LoadingScreen;
    public Slider slider;
    public Text percText;
    public float delay = 2.5f;
    public string newGameLevel;
    public Animation anim;
    public Animator loadingScreen;
    public Animator Fade;
    
   
    
    IEnumerator Start()
    {
        anim = GetComponent<Animation>();                      // Gets Animator component on game object.
        anim.Play(anim.clip.name);                            // Will play animation clip.
        yield return new WaitForSeconds(anim.clip.length);   // Yields anything from happening until animation is completed.
        StartCoroutine(LoadLevelAfterDelay(newGameLevel));  // Will start function after animation is completed.
    }
    // Will load the game in the background after animations are completed, screen fades with animator animation on UI image, music fades to 0 with animator animator, and slider will updates with loading progress.
    IEnumerator LoadLevelAfterDelay(string newGameLevel)
    {
        LoadingScreen.SetActive(true);
        GetComponent<Animator>().SetTrigger("Fader");
        loadingScreen.SetTrigger("Fader");
        GetComponent<Animator>().SetTrigger("Fade");
        Fade.SetTrigger("Fade");
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

