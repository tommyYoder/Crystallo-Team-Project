using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MineSplode_4 : MonoBehaviour
{
   //Use for Escape level
    public Transform Player;
    public Transform Camera;
    private GameObject Mine;
    public Transform destination;
    public AudioSource WarpSound;
    public AudioSource errorCorrectSound;
    

   float nextTimeToSearch = 0;


    // Use this for initialization
    void Start()
    {
        //particleSystem.stop();
    }



    // Finds player 
    void Update()                                                 // If player is null, then script will look for player and FindPlayer is called.
    {
        if (Player == null)
        {
            FindPlayer();
            return;

        }

    }
    // If time to search is less then or equal to time, then script will look for player tag by its transform position.
    void FindPlayer()                                         
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
         
            WarpSound.Play();
            errorCorrectSound.Play();
            KillPlayer();
            
        }
    }

    // Will transport the player and camera to the destenation by its transform position. This is effective for teleporting the player to different areas in the game level.
   public void KillPlayer()                     
    {


        if (Player == null)
        {
            Mine = GameObject.Find("Player(Clone)");
        }
        else
        {


            Camera.transform.position = destination.transform.position;
            Player.transform.position = destination.transform.position;
        }
    }
}


