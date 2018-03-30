using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowGUITriggeredText : MonoBehaviour {

    //Use for triggered colliders.

    public GameObject Text;
    public GameObject Border;

    // Use this for initialization
    void Start()
    {
        Text.SetActive(false);
        Border.SetActive(false);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Text.SetActive(true);
            Border.SetActive(true);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Text.SetActive(false);
            Border.SetActive(false);
        }
    }
}