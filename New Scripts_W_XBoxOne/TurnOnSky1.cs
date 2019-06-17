using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnSky1 : MonoBehaviour
{
    public GameObject skyObject;

    public Collider colliderObject;
    public Collider colliderObject1;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            skyObject.SetActive(true);

            colliderObject.GetComponent<Collider>().enabled = true;
            colliderObject1.GetComponent<Collider>().enabled = false;
        }
    }
}
