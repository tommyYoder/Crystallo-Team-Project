using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeSpeed1 : MonoBehaviour
{
    // For Hard Mode Spikes.

    public float speed;
    public GameObject dustParticle;

    // Looks for the rigidbody of the spikes and moves it with the speed amount.
    IEnumerator Start()
    {
        dustParticle.SetActive(false);
        yield return new WaitForSeconds(.5f);
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
        dustParticle.SetActive(true);
    }

}
