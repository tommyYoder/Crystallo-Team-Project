#pragma strict

var BrokenObject : Transform;
var Effect : Transform; 
var EffectII :Transform;
var SoundEffect :Transform; 




function OnCollisionEnter (theCollision : Collision){

    if(theCollision.gameObject.tag == "Player")
        BreakDeath();
}

    function BreakDeath(){
        Debug.Log("BreakDeathRead");
        Instantiate(BrokenObject, transform.position,BrokenObject.transform.rotation);
        Instantiate(Effect,transform.position,BrokenObject.transform.rotation);
        Instantiate(EffectII,transform.position,BrokenObject.transform.rotation);
        Destroy(gameObject);
        Instantiate(SoundEffect,transform.position,BrokenObject.transform.rotation);

    }