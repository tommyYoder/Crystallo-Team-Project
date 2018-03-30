using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public GameObject LoadingScreen;
    public Slider slider;
    public Text percText;
    public Animator loadingScreen;
    public float delay = 2.5f;
    public Animator Fade;


    // Starts function when button is clicked.
    public void NewGameBtn(string newGameLevel)                     
    {             
        StartCoroutine(LoadAsynchronously(newGameLevel));     
    }
    // Will load the game in the background while screen fades with animator animation on UI image, music fades to 0 with animator animator, and slider will updates with loading progress.
    IEnumerator LoadAsynchronously(string newGameLevel)
    {
            LoadingScreen.SetActive(true);
            //GetComponent<Animator>().SetTrigger("Fade1");
            loadingScreen.SetTrigger("Fade1");                    //Put Fade1 onto animator trigger component for the loading screen to fade to black.
            //GetComponent<Animator>().SetTrigger("Fade");
            Fade.SetTrigger("Fade");                             // Put Fade onto animator trigger component for the audio source to fade from 1 to 0.
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

    // Ends game application when quit button is pressed. 
    public void ExitGameBtn()                                     
    {
        Application.Quit();
        GetComponent<Animator>().SetTrigger("Fade");
        Fade.SetTrigger("Fade");
    }
}
