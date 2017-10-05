using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public GUIStyle guiStyle = new GUIStyle();
    public static bool doorKey;
    public bool open;
    public bool close;
    public bool inTrigger;

    public AudioSource DoorSound;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")                                     // If player enters collider, then inTrigger is called.
        {
            inTrigger = true;
        }
    }
    void OnTriggerExit(Collider other)                                           // If player exitss collider, then inTrigger is set to false.
    {
        inTrigger = false;
    }

    void Update()                                                              // If inTrigger is true, then door will open and close when E is pressed. Sound will play when true.
    {
        if (inTrigger)
        {
            if (close)
            {
                if (doorKey)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        open = false;
                       
                        close = false;
                        DoorSound.Play();
                    }
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.E))                            // If inTrigger is true, then door will open and close when E is pressed. Sound will play when true.
                {
                    open = true;
                    close = true;
                  
                    DoorSound.Play();
                }
            }
        }

        if (open)                                                         // If open, then door will rotate 180 degrees and update this by the transform rotation.
        {
            var newRot = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 180, 0), Time.deltaTime * 300);
            transform.rotation = newRot;
        }
        else                                                            // If closed, then door will rotate 180 degrees and update this by the transform rotation.
        {
            var newRot = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 90, 0), Time.deltaTime * 300);
            transform.rotation = newRot;
        }
    }

    void OnGUI()                                                      // When inTrigger is true, then first GUI text is displayed. If player has key, then second GUI text is displayed. If open and closed, then third GUI text is displayed.
    {
        if (inTrigger)
        {
            if (open)
            {
                guiStyle.fontSize = 20;
                GUI.Box(new Rect(400, 300, 300, 50), "Press E to close", guiStyle);
            }
            else
            {
                if (doorKey)
                {
                    guiStyle.fontSize = 20;
                    GUI.Box(new Rect(400, 300, 300, 50), "Press E to open", guiStyle);
                }
                else
                {
                    guiStyle.fontSize = 20;
                    GUI.Box(new Rect(400, 300, 300, 50), "Find They key To Unlock Thee!", guiStyle);
                }
            }
        }
    }
}