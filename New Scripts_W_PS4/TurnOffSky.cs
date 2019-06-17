using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffSky : MonoBehaviour
{

    public GameObject skyObject;

    public Collider colliderObject;
    public Collider colliderObject1;

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            skyObject.SetActive(false);

            colliderObject.GetComponent<Collider>().enabled = true;
            colliderObject1.GetComponent<Collider>().enabled = false;
        }
    }
}
