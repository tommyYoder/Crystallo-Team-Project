using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowGUIText : MonoBehaviour
{
    //Use for first level tutorial colliders.

    public GameObject Text;
    public GameObject Border;

    // Use this for initialization
   

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
            Destroy(gameObject);
        }
    }
}
   
