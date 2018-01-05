using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwooshTrigger : MonoBehaviour {

    public AudioSource SwooshSound;

    void OnTriggerEnter(Collider other)                                    // When player enters collider, then sound will play.
    {
        if (other.gameObject.tag == "Player")
        {
            SwooshSound.Play();
            SwooshSound.loop = true;
        }
    }
    void OnTriggerExit(Collider other)                                  // When player exits collider, then sound will stop.
    {
        if (other.gameObject.tag == "Player")
        {
            SwooshSound.Stop();
            SwooshSound.loop = false;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
