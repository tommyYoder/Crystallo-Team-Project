using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeSpeed : MonoBehaviour
{
    // For Normal Mode Spikes.


    public float speed;
    public GameObject dustParticle;


    // Looks for the rigidbody of the spikes and moves it with the speed amount.
    public IEnumerator Start()
    {
        dustParticle.SetActive(false);
        yield return new WaitForSeconds(1);
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
        dustParticle.SetActive(true);
    }

}
