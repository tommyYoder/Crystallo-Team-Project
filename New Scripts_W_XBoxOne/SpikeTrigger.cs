using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrigger : MonoBehaviour {

    public AudioSource FloorSpike_Sound;

    // use this for initialization
    void Start()
    {
    }

    void OnTriggerEnter()                      // When player enters collider, then sound will play.
    {

        FloorSpike_Sound.Play();               
    }


    void OnTriggerExit()                     // When player exits collider, then sound will stop.
    {
        FloorSpike_Sound.Stop();
    }

    // Update is called once per frame
    void Update()
    {

    }
}