using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelSoundTrigger : MonoBehaviour
{

    public GameObject Barrel_Destructable;
    public AudioSource Barrel;



    // use this for initialization
    void Start()
    {

    }


    void OnTriggerEnter(Collider other)                                  // If player enters collider, then sound will play.
    { 
        {
            Barrel.Play();
        }
    }

    void OnTriggerExit()                                                // If player enters collider, then sound will play.
    {
        {

            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

