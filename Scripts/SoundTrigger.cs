using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour {

    public AudioSource MainSound;
    public AudioSource HarpSound;

	// Use this for initialization
	void Start () {
		
	}
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            MainSound.Stop();
            HarpSound.Play();
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            MainSound.Play();
            HarpSound.Stop();
        }
    }
    // Update is called once per frame

    
    // Update is called once per frame
 
	void Update () {
		
	}
}
