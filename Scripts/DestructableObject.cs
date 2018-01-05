using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObject : MonoBehaviour {
    public GameObject BrokenObject;
    public GameObject Effect;
    public GameObject Effect2;
    public AudioSource BreakSound;
    // Use this for initialization
    void Start () {
		
	}
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Instantiate(BrokenObject, transform.position, transform.rotation);
            Instantiate(Effect, transform.position, transform.rotation);
            Instantiate(BreakSound, transform.position, transform.rotation);
            Instantiate(Effect2, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
