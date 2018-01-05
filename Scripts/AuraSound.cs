using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraSound : MonoBehaviour {

    public AudioSource auraSound;
	// Use this for initialization
	void Start () {
		
	}
	public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            auraSound.Play();
            auraSound.loop = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            auraSound.Stop();
            auraSound.loop = false;
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
