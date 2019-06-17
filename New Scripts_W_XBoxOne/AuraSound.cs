using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraSound : MonoBehaviour {

    public AudioSource auraSound;
  

	// Use this for initialization
	void Start () {
      
    }

    // Sound gets played on trigger enter.
	public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            auraSound.Play();
            auraSound.loop = true;
        }
    }

    // Sound stops on trigger exit.
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            auraSound.Stop();
            auraSound.loop = false;
        }
    }
  
}
