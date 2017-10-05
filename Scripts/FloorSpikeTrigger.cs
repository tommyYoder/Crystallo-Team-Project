using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpikeTrigger : MonoBehaviour {

    public AudioSource FloorSpikeSound;

    // Use this for initialization
    void Start()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")                               // If player enters collider, then sound will play.
        {
            FloorSpikeSound.Play();
            FloorSpikeSound.loop = true;
        }
    }
    void OnTriggerExit(Collider other)                                    // If player exits collider, then sound will stop.
    {
        if (other.gameObject.tag == "Player")
        {
            FloorSpikeSound.Stop();
            FloorSpikeSound.loop = false;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
