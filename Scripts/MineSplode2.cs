using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MineSplode2 : MonoBehaviour
{
    //Use for Water level
    public Transform destination;
    public Transform Player;
    private GameObject Mine2;
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
    void FindPlayer()
    {
        if (nextTimeToSearch <= Time.time)    // If time to search is less then or equal to time, then script will look for player tag by its transform position.
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
            Mine2 = GameObject.Find("Mine2");

            Mine2.GetComponent<MeshRenderer>().enabled = true;
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
            Mine2 = GameObject.Find("Player(Clone)");
        }
        else
        {
            Player.transform.position = destination.transform.position;
           
            Player.GetComponent<MeshRenderer>().enabled = true;
            Eyes.SetActive(true);

        }
    }
      
 }
    
 


    
   
   


    











