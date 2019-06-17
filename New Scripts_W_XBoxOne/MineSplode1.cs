using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MineSplode1 : MonoBehaviour
{
   //Use for Lava level.
   
    public Transform Player;
    private GameObject Lava;
   
   


    float nextTimeToSearch = 0;

    // Use this for initialization
    void Start()
    {
        //particleSystem.stop();
       
    }
  
    

    // Looks for player
    void Update()
    {
        if (Player == null)                    // If player is null, then script will look for player and FindPlayer is called.
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
            Lava = GameObject.Find("Lava");
           
            StartCoroutine("KillPlayer");
        }
    }

    // Kills player on trigger contact and disables mesh renderer for 2 seconds. After 2 seconds, then the player is revived and the respawn script takes care of the spawning loaction. Great for floating spirites when the player is dead!
    IEnumerator KillPlayer()
    {
        yield return new WaitForSeconds(2);
    
        print("worked");

        if (Player == null)
        {
            Lava = GameObject.Find("Player(Clone)");
        }
    }    
 }
    
 


    
   
   


    











