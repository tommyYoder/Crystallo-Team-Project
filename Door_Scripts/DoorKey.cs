using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKey : MonoBehaviour {

    public GUIStyle guiStyle = new GUIStyle();
    public bool inTrigger;

    public AudioSource KeySound;

    void OnTriggerEnter(Collider other)                            // If player enters collider, then inTrigger is called.
    {
        if (other.gameObject.tag == "Player")
        {
            inTrigger = true;
        }
    }
    void OnTriggerExit(Collider other)                            // If player exits collider, then inTrigger is set to false.
    {  
        inTrigger = false;
    }

    void Update()
    {
        if (inTrigger)                                           // If true and K is pressed, then key is picked up, Door script will call this function, sound will play, and game object is destroyed.
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                DoorScript.doorKey = true;
                KeySound.Play();
                Destroy(this.gameObject);
            }
        }
    }

    void OnGUI()                                               // GUI text is displayed before key is collected. 
    {
        if (inTrigger)
        {
            guiStyle.fontSize = 20;
            GUI.Box(new Rect(400, 300, 300, 50), "Press K to take key", guiStyle);
        }
    }
}