﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowGUIText : MonoBehaviour
{
    //Use for first level tutorial colliders.

    public GameObject Text;
    // Use this for initialization
    void Start()
    {
        Text.SetActive(false);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Text.SetActive(true);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Text.SetActive(false);
            Destroy(gameObject);
        }
    }
}
   
