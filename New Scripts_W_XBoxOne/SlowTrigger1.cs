using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SlowTrigger1 : MonoBehaviour
{
    // When you are out of water.

    public GameObject volumeLayer;
    public GameObject Bubbles;
    public Player player;
    public AudioSource waterSound;
    public AudioSource begginingMainSound;
    public AudioSource underwaterMainSound;
    public AudioSource waterfallSound;
    public AudioSource underWaterfallSound;

    public Collider triggerCollider;
    public Collider triggerCollider1;

    public GameObject timerNormal;
    public GameObject underwaterTimer;

    public float SpeedDivider = 3;

    public Underwater water;
    public Underwater1 water1;

    // Makes sure that the bubble gameobject is off.
    public void Start()
    {
      
        Bubbles.SetActive(false);
    }


    // Looks to see if the player has entered the collider. If yes, then the underwater sequence will stop.
    public IEnumerator OnTriggerEnter(Collider other)

    {
        if (other.gameObject.tag == "Player")
        {
            water.isUnderwater = false;
            water1.isUnderwater = false;
            volumeLayer.SetActive(false);

            timerNormal.SetActive(true);
            underwaterTimer.SetActive(false);

            Bubbles.SetActive(false);
            other.gameObject.GetComponent<Player>().speed *= SpeedDivider;
            player.rb.mass = 6;
            player.rb.angularDrag = 1;
            player.jumpHeight = 28f;
            waterSound.Play();
            underwaterMainSound.Pause();

            triggerCollider.GetComponent<Collider>().enabled = false;
            triggerCollider1.GetComponent<Collider>().enabled = true;

            yield return new WaitForSeconds(1);
            begginingMainSound.Play();
            waterfallSound.Play();
            waterfallSound.loop = true;


            underWaterfallSound.Stop();
            underWaterfallSound.loop = false;
        }
    }
}
