using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObject2 : MonoBehaviour {

    public GameObject BrokenObject;
    public GameObject Effect;
    public GameObject Coins;
    public AudioSource BreakSound;


	// Use this for initialization
	void Start () {
		
	}


    public IEnumerator OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Instantiate(BrokenObject, transform.position, transform.rotation);
            Instantiate(Effect, transform.position, transform.rotation);
            Instantiate(BreakSound, transform.position, transform.rotation);
            Instantiate(Coins, transform.position, transform.rotation);
            yield return new WaitForSeconds(.6f);
           
            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
