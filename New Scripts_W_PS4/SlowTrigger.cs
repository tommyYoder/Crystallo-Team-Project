using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SlowTrigger : MonoBehaviour
{
    // When you are in water.

   
    public GameObject Bubbles;
    public Player player;
    public AudioSource waterSound;
    public AudioSource begginingMainSound;
    public AudioSource underwaterMainSound;
    public AudioSource waterfallSound;
    public AudioSource underWaterfallSound;

    public Collider triggerCollider;

    public GameObject pauseMenu;
    public GameObject underwaterPauseMenu;
    
    public GameObject underwaterTimer;

    public float SpeedDivider = 3;

    // Makes sure that the bubble gameobject is turned off.
    public void Start()
    {
        pauseMenu.SetActive(true);
        underwaterPauseMenu.SetActive(false);
        Bubbles.SetActive(false);
    }

    // Looks to see if the player has entered the collider. If yes, then the underwater sequence will start.
    public IEnumerator OnTriggerEnter(Collider other)

    {
        if (other.gameObject.tag == "Player")
        {

            Bubbles.SetActive(true);
            player.rb.mass = 10;
            player.rb.angularDrag = 5;
            player.jumpHeight = 40f;
            underwaterTimer.SetActive(true);

            pauseMenu.SetActive(false);
            underwaterPauseMenu.SetActive(true);

            underwaterTimer.SetActive(true);
            waterSound.Play();
            begginingMainSound.Pause();
            other.gameObject.GetComponent<Player>().speed /= SpeedDivider;

            yield return new WaitForSeconds(1);
            underwaterMainSound.Play();
            waterfallSound.Stop();
            waterfallSound.loop = false;

            triggerCollider.GetComponent<Collider>().enabled = false;
          

            underWaterfallSound.Play();
            underWaterfallSound.loop = true;
        }
    }
}
     
   


