#pragma strict

var sound : AudioClip;


function Start () {
    //var audio : AudioSource = GetComponent,<AudioSource>();
    //audio.Play();
}
function OnTriggerEnter(Col : Collider)
    {
    if(Col.CompareTag("Player"))
    {
        GetComponent.<AudioSource>(). PlayOneShot(sound);
        yield WaitForSeconds (0.9);
        Destroy(gameObject);
    }
}
