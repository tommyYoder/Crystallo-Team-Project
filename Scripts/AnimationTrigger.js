#pragma strict

var Button : GameObject;
var breakSound : AudioClip;



function OnTriggerEnter (col : Collider) {
  
    if(col.gameObject.tag == "Player")
    {
        AudioSource.PlayClipAtPoint(breakSound, transform.position);
        Button.GetComponent.<Animation>().Play();
        Destroy(gameObject);
    }

 }



