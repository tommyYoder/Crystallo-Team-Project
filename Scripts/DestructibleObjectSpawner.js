#pragma strict

var BrokenObject : Transform;

var Effect : Transform; 

var SoundEffect :Transform;

var Coin :Transform; 

var sound : AudioClip;

var SoundEffect1 :Transform;



function OnCollisionEnter (theCollision : Collision){

    

    if(theCollision.gameObject.tag == "Player")
        BreakDeath();
}


    function BreakDeath(){
        Debug.Log("BreakDeathRead");
        Instantiate(BrokenObject, transform.position,BrokenObject.transform.rotation);
        Instantiate(Effect,transform.position,BrokenObject.transform.rotation);
   		Instantiate(SoundEffect,transform.position,BrokenObject.transform.rotation);
   	    Destroy(gameObject);
   	    GetComponent.<AudioSource>(). PlayOneShot(sound);
   	    Instantiate(Coin, transform.position,Coin.transform.rotation);
   	   
   	    Instantiate(SoundEffect1,transform.position,Coin.transform.rotation);
   	    yield WaitForSeconds(.6);
   	    Destroy(gameObject);
    }
   