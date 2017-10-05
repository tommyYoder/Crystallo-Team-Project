using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapsingFloor : MonoBehaviour
{

    public GameObject[] Platforms;



    private Rigidbody rb;

    public AudioSource CollapseSound;

    private Vector3 initialPosition;



    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();                 // Looks for Rigidbody.

        rb.isKinematic = true;                         // Makes isKinematic true.

        initialPosition = transform.position;         // Sets initial position to transform position of game object.

        GetComponent<Collider>().enabled = true;     // Makes collider true.

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")      // If Player tag enters collider, then FallingPlatform gets called.
        {

            StartCoroutine(FallingPlatform());


        }
    }
    IEnumerator FallingPlatform()
    {
       // After 2.5 seconds, then isKinematic is set to false, collider is set to false, and sound is played.
            yield return new WaitForSeconds(2.5f);
            rb.isKinematic = false;
            GetComponent<Collider>().enabled = false;
            CollapseSound.Play();

        // After 5 seconds, then isKinematic is set to true, collider is set to true, game object is set back to starting position, and sound is played.
            yield return new WaitForSeconds(5f);
            rb.isKinematic = true;
            transform.position = initialPosition;
            GetComponent<Collider>().enabled = true;
            CollapseSound.Play();
        }
    }



