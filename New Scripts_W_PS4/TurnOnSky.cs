using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnSky : MonoBehaviour
{
    public GameObject skyObject;

    public GameObject colliderObject;

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            skyObject.SetActive(true);

            colliderObject.GetComponent<Collider>().enabled = false;
        }
    }
}
