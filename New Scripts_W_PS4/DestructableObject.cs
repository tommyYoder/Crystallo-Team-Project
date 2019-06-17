using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObject : MonoBehaviour
{
    public GameObject BrokenObject;
    public GameObject Effect;
    public GameObject Effect2;
    public AudioSource BreakSound;

    public void Start()
    {
        GetComponent<Collider>().enabled = true;                    // Collider is set to true.
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GetComponent<Collider>().enabled = false;
            Instantiate(BrokenObject, transform.position, transform.rotation);
            Instantiate(Effect, transform.position, transform.rotation);
            Instantiate(BreakSound, transform.position, Quaternion.identity);
            Instantiate(Effect2, transform.position, transform.rotation);
            Destroy(gameObject);


        }
    }
}
