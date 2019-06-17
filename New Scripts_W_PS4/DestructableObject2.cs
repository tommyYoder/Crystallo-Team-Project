using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObject2 : MonoBehaviour {

    
    public GameObject BrokenObject;
    public GameObject Effect;
    public GameObject Coins;
    public AudioSource BreakSound;

    public void Start()
    {
        GetComponent<Collider>().enabled = true;                    // Collider is set to true.
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            GetComponent<Collider>().enabled = false;
            Instantiate(BrokenObject, transform.position, transform.rotation);
            Instantiate(Effect, transform.position, transform.rotation);
            Instantiate(BreakSound, transform.position, transform.rotation);
            Instantiate(Coins, transform.position, transform.rotation);
            Destroy(gameObject);          
        }
    }
		
}

