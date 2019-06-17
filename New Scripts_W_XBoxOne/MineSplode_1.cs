using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MineSplode_1 : MonoBehaviour
{
   

    public Transform Player;
    private GameObject Mine;
    public GameObject Eyes;
    public GameObject LoadingScreen;
    public float delay = 2.5f;
    public string newGameLevel;
    public Animator loadingScreen;
    public Animator Fade;

    float nextTimeToSearch = 0;

    // Use this for initialization
    void Start()
    {
        //particleSystem.stop();
        Eyes.SetActive(true);
    }

    
    void Update()
    {
        if (Player == null)                                      // If player is null, then script will look for player and FindPlayer is called.
        {
            FindPlayer();
            return;
        }
    }
    void FindPlayer()                                          // If time to search is less then or equal to time, then script will look for player tag by its transform position.
    {
        if (nextTimeToSearch <= Time.time)
        {
            GameObject searchResult = GameObject.FindGameObjectWithTag("Player");
            if (searchResult != null)
                Player = searchResult.transform;
             nextTimeToSearch = Time.deltaTime + 0.5f;
        }
    }

    // Checks for Player and Mine Tag when they collide to start KillPlayer sequence
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Mine = GameObject.Find("Mine");
            Mine.GetComponent<MeshRenderer>().enabled = true;
            KillPlayer();
            StartCoroutine("KillPlayer");
          
        }

    }
    IEnumerator KillPlayer()                                 // If player is dead, then player's mesh renderer is set to false, particle effect is instantiated, and after 1.5 seconds the level will reload the level again.
    {
        Player.GetComponent<MeshRenderer>().enabled = false;
        Eyes.SetActive(false);
        yield return new WaitForSeconds(.5f);
        LoadingScreen.SetActive(true);
        //GetComponent<Animator>().SetTrigger("Fader");
        loadingScreen.SetTrigger("Fader");
        //GetComponent<Animator>().SetTrigger("Fade");
        Fade.SetTrigger("Fade");
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Roll-a-ball_Escape_Level");
    }

 }

