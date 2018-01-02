using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellSound : MonoBehaviour {

    public AudioSource cellSound;

	// Use this for initialization
	void Start () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            cellSound.Play();
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
