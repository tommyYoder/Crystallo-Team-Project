using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Underwater : MonoBehaviour {

    public GameObject volumeLayer;
    

    public Collider triggerCollider;

    public GameObject underwaterSpikeSound;



    public bool isUnderwater = false;
 

    // Turns off these gameobject when game is played
    void Start () {

        volumeLayer.SetActive(false);
        isUnderwater = false;
      
    }
    // Turns on certain colliders and then sets underwater to true.
    public void OnTriggerEnter(Collider other)
    {
    if(other.gameObject.tag == "Player")
        {
            SetUnderwater();
            isUnderwater = true;
            triggerCollider.GetComponent<Collider>().enabled = false;
            underwaterSpikeSound.SetActive(true);



        }
    }
    // Turns off underwater.
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SetNormal();
            isUnderwater = false;
           
        }
    }


    // Turns off volume gameobject
    public void SetNormal()
    {

        volumeLayer.SetActive(false);

    }

    // Turns on volume gameobject
    public void SetUnderwater()
    {
        volumeLayer.SetActive(true);

    }
  
}
