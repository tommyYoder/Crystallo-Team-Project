#pragma strict

var BrokenPlayer : Transform;
var Effect : Transform; 
var EffectII :Transform;




function OnCollisionEnter (theCollision : Collision){

    if(theCollision.gameObject.tag == "Mine")
        BreakDeath();
}

    function BreakDeath(){
        Debug.Log("BreakDeathRead");
        Instantiate(BrokenPlayer, transform.position,BrokenPlayer.transform.rotation);
        Instantiate(Effect,transform.position,BrokenPlayer.transform.rotation);
        Instantiate(EffectII,transform.position,BrokenPlayer.transform.rotation);
        Destroy(gameObject);
    }