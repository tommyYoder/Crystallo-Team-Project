using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpikeTrigger : MonoBehaviour {

    public AudioSource WallSpikeSound;

	// Use this for initialization
	void Start () {
		
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")                          // When player enters collider, then sound will play.
        {
            WallSpikeSound.Play();
            WallSpikeSound.loop = true;
        }
    }
        void OnTriggerExit(Collider other)                           // When player exits collider, then sound will stop.
    {
            if (other.gameObject.tag == "Player")
            {
                WallSpikeSound.Stop();
            WallSpikeSound.loop = false;
        }
        }
    
    
	// Update is called once per frame
	void Update () {
		
	}
}
