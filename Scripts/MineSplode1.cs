﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MineSplode1 : MonoBehaviour
{
   //Use for Lava level.
    public Transform destination;
    public Transform Player;
    private GameObject Lava;
    public GameObject deathParticle;
    public GameObject Eyes;


    float nextTimeToSearch = 0;

    // Use this for initialization
    void Start()
    {
        //particleSystem.stop();
        Eyes.SetActive(true);
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

            Lava.GetComponent<MeshRenderer>().enabled = true;
            KillPlayer();
           
            StartCoroutine("KillPlayer");
        }
    }

    // Kills player on trigger contact and disables mesh renderer for 2 seconds. After 2 seconds player is revived by the destination transform position. Great for floating spirites when the player is dead!
    IEnumerator KillPlayer()
    {
        Player.GetComponent<MeshRenderer>().enabled = false;
        Eyes.SetActive(false);
        Instantiate(deathParticle, transform.position, Quaternion.identity);

        yield return new WaitForSeconds(2);
    
        print("worked");

        if (Player == null)
        {
            Lava = GameObject.Find("Player(Clone)");
        }
        else
        {
            Player.transform.position = destination.transform.position;
           
            Player.GetComponent<MeshRenderer>().enabled = true;
            Eyes.SetActive(true);

        }
    }
      
 }
    
 


    
   
   


    











