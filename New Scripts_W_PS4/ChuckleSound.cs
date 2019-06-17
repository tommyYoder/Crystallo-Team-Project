using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChuckleSound : MonoBehaviour
{

    public AudioSource chuckleSound;


    // Will play chuckle sound when player enters the collider. Will destroy colldier after 1 second.
    public IEnumerator OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            chuckleSound.Play();

            yield return new WaitForSeconds(1.5f);
            Destroy(gameObject);
        }
    }
}
