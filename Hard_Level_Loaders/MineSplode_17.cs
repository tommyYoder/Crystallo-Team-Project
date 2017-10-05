using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MineSplode_17 : MonoBehaviour
{

   
    public Transform Player;
    private GameObject Mine;
    public GameObject deathParticle;
    public AudioSource DeathSound;



    float nextTimeToSearch = 0;

    // Use this for initialization
    void Start()
    {
        //particleSystem.stop();

    }




    void Update()
    {
        if (Player == null)                                                           // If player is null, then script will look for player and FindPlayer is called.
        {
            FindPlayer();
            return;

        }

    }
    void FindPlayer()                                                                // If time to search is less then or equal to time, then script will look for player tag by its transform position.
    {
        if (nextTimeToSearch <= Time.time)
        {
            GameObject searchResult = GameObject.FindGameObjectWithTag("Player");
            if (searchResult != null)
                Player = searchResult.transform;
            nextTimeToSearch = Time.deltaTime * 0.5f;

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


    IEnumerator KillPlayer()                                                        // If player is dead, then player's mesh renderer is set to false, particle effect is instantiated, and after 1.5 seconds the level will reload the previous loading screen.
    {
        Player.GetComponent<MeshRenderer>().enabled = false;
        Instantiate(deathParticle, transform.position, Quaternion.identity);
        DeathSound.Play();
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("LoadingScreen 5");

        print("worked");
    }
}


