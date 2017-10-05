using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneTrigger : MonoBehaviour {

    public AudioSource CraneSound;


	// Use this for initialization
	void Start () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")                  // If player tag enters collider, then sound will play.
        {
            CraneSound.Play();
        }
    }

    void OnTriggerExit(Collider other)                        // If player tag exits collider, then sound will stop.
    {
        if (other.gameObject.tag == "Player")
        {
            CraneSound.Stop();
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
