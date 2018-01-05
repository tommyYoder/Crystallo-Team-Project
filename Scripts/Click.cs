using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour {

    public AudioSource ClickSound;

    // Use this for initialization
    void Start () {
       

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))           // If left mouse button is pressed sound will play.
        {
            ClickSound.Play();
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.Mouse0))       // If mouse button is released sound will stop.
            {
                ClickSound.Stop();
            }
        }
    }
}
