using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDown : MonoBehaviour {


    Animator anim;
    public AudioSource BreakSound;
    public GameObject Door;

	// Use this for initialization
	void Start () {
        anim= GetComponent<Animator>();
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetTrigger("Down");
            BreakSound.Play();
            GetComponent<Collider>().enabled = false;
            Destroy(Door);
        }
   }
   
    
	// Update is called once per frame
	void Update () {
	
        
	}
}
