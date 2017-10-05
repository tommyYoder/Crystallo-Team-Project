using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerButton : MonoBehaviour {

    public GameObject Door;
    

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")                         // If player enters collider, then script will call Door script to open door.
            StartCoroutine(Door.GetComponent<Door>().OpenUp());
           
    }
}