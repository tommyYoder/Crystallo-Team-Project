using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Underwater1 : MonoBehaviour {

    public GameObject volumeLayer;
    public GameObject Bubbles;
    public Player player;
    public AudioSource waterSound;
    public Collider triggerCollider;


    public float SpeedDivider = 3;
    public bool isUnderwater = false;

   
 

    // Turns off these gameobject when game is played
    void Start () {

        volumeLayer.SetActive(false);
        Bubbles.SetActive(false);
        isUnderwater = false;
    }
    // Turns on gameobjects and player's jump height to 28. Rigidbody componets are also effected to slow down the player
    public IEnumerator OnTriggerEnter(Collider other)
    {
    if(other.gameObject.tag == "Player")
        {
            SetUnderwater();
            isUnderwater = true;
            Bubbles.SetActive(true);
            player.rb.mass = 10;
            player.rb.angularDrag = 5;
            player.jumpHeight = 28f;
            waterSound.Play();
            other.gameObject.GetComponent<Player>().speed /= SpeedDivider;

            yield return new WaitForSeconds(1);
            triggerCollider.GetComponent<Collider>().enabled = false;

        }
    }
    // Turns off gameobjects, player's jump to 28, and Rigidbody components to normal.
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SetNormal();
            isUnderwater = false;
            Bubbles.SetActive(false);
            player.rb.mass = 6;
            player.rb.angularDrag = 1;
            player.jumpHeight = 28f; 
            waterSound.Play();
     
        }
    }

    // Turns off volume gameobject
    public void SetNormal()
    {

        volumeLayer.SetActive(false);

    }

    // Turns on volume gameobject
    public void SetUnderwater()
    {
        volumeLayer.SetActive(true);

    }
  
}
