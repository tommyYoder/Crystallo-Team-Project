#pragma strict


private var theCollider : String;


function OnTriggerEnter (other : Collider)
    {

    theCollider = other.tag;

    if (theCollider == "Player"){

        GetComponent.<AudioSource>().Play();
        GetComponent.<AudioSource>().loop = true;
    } 
}
    function OnTriggerExit (other : Collider)
        {

            theCollider = other.tag;

            if (theCollider == "Player"){
            GetComponent.<AudioSource>().loop = false;
            GetComponent.<AudioSource>().Stop();
         
           

        }

    }
