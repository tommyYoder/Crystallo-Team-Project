using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentGameobject : MonoBehaviour
{

    public GameObject player;

    // If player enters the crane triggered event, then the player is parented to the triggered event.
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            player.transform.parent = transform;
        }
    }

    // If player exits the crane triggered event, then the player is unparented to the triggered event.
    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            player.transform.parent = null;
        }
    }
}
