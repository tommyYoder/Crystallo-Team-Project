using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MineSplode_4 : MonoBehaviour
{
   
    public Transform Player;
    private GameObject Mine;
    public Transform destination;
 
 
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
    void FindPlayer()                                           // If time to search is less then or equal to time, then script will look for player tag by its transform position.
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
            
        }
    }

   
    void KillPlayer()                       // Will transport the player to the destenation by its transform position. This is effective for teleporting the player to different areas in the game level.
    {


        if (Player == null)
        {
            Mine = GameObject.Find("Player(Clone)");
        }
        else
        {
            Player.transform.position = destination.transform.position;
        }
    }
}


