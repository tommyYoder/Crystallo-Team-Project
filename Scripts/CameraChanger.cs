using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChanger : MonoBehaviour
{

    public Camera cam1;
    public Camera cam2;

    // Use this for initialization
    void Start()
    {
        cam1.enabled = true;
        cam2.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag.Equals("Player"))
        {

            cam1.enabled = !cam1.enabled;
            cam2.enabled = !cam2.enabled;
            Debug.Log("pass");
        }
    }
    void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag.Equals("Player"))
        {
            cam1.enabled = !cam1.enabled;
            cam2.enabled = !cam2.enabled;
            Debug.Log("pass");
        }
    }
}
   
        
 