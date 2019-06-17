using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelSoundTrigger : MonoBehaviour
{

    public GameObject Barrel_Destructable;
    public AudioSource Barrel;



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
}

