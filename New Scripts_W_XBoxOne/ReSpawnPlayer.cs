using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReSpawnPlayer : MonoBehaviour
{

    public Vector3 respawnPoint;

    public Player player;
    public GameObject checkpointObject;
    public GameObject checkpointObject1;
    public GameObject checkpointObject2;
    public GameObject checkpointObject3;

    public bool hitCheckpoint = false;
    public bool hitCheckpoint1 = false;
    public bool hitCheckpoint2 = false;
    public bool hitCheckpoint3 = false;

    // Looks for these gameobject and sets the player's position to the starting position when the level starts.
    void Start()
    {
        respawnPoint = transform.position;
        hitCheckpoint = false;
        hitCheckpoint1 = false;
        hitCheckpoint2 = false;
        hitCheckpoint3 = false;
    }

    // Looks for these tags in the game.
    public IEnumerator OnTriggerEnter(Collider other)
    {
        // If the player hits Mine, then after 2 seconds the player will restart at the starting position. If checkpoint is hit, then the player restarts at that location.
        if (other.gameObject.tag == "Mine")
        {
            yield return new WaitForSeconds(2);
            transform.position = respawnPoint;
        }

        // If the player hits Mine2, then after 2 seconds the player will restart at the starting position. If checkpoint is hit, then the player restarts at that location.
        if (other.gameObject.tag == "Mine2")
        {
            yield return new WaitForSeconds(1.99f);
            transform.position = respawnPoint;
        }

        // If the player hits Lava, then after 2 seconds the player will restart at the starting position. If checkpoint is hit, then the player restarts at that location.
        if (other.gameObject.tag == "Lava")
        {
            yield return new WaitForSeconds(1.95f);
            transform.position = respawnPoint;
        }

        // Will update the player's restart position for when they hit any of the above tags. The checkpoint icon is then disabled.
        if (other.gameObject.tag == "CheckPoint")
        {
            hitCheckpoint = true;
            player.checkPointSound.Play();
            checkpointObject.SetActive(false);

            yield return new WaitForSeconds(.1f);
            hitCheckpoint = false;

            yield return new WaitForSeconds(2.25f);
            respawnPoint = other.transform.position;
        }

        // Will update the player's restart position for when they hit any of the above tags. The checkpoint icon is then disabled.
        if (other.gameObject.tag == "CheckPoint1")
        {
            hitCheckpoint1 = true;
            player.checkPointSound.Play();
            checkpointObject1.SetActive(false);

            yield return new WaitForSeconds(.1f);
            hitCheckpoint1 = false;

            yield return new WaitForSeconds(2.25f);
            respawnPoint = other.transform.position;
        }

        // Will update the player's restart position for when they hit any of the above tags. The checkpoint icon is then disabled.
        if (other.gameObject.tag == "CheckPoint2")
        {
            hitCheckpoint2 = true;
            player.checkPointSound.Play();
            checkpointObject2.SetActive(false);

            yield return new WaitForSeconds(.1f);
            hitCheckpoint2 = false;

            yield return new WaitForSeconds(2.25f);
            respawnPoint = other.transform.position;
        }

        // Will update the player's restart position for when they hit any of the above tags. The checkpoint icon is then disabled.
        if (other.gameObject.tag == "CheckPoint3")
        {
            hitCheckpoint3 = true;
            player.checkPointSound.Play();
            checkpointObject3.SetActive(false);

            yield return new WaitForSeconds(.1f);
            hitCheckpoint3 = false;

            yield return new WaitForSeconds(2.25f);
            respawnPoint = other.transform.position;
        }
        // Will update the player's restart position for when they hit any of the above tags. The checkpoint icon is then disabled.
        if (other.gameObject.tag == "UnderwaterCheckPoint")
        {
            player.underwaterCheckpointSound.Play();
            checkpointObject.SetActive(false);

            yield return new WaitForSeconds(2.25f);
            respawnPoint = other.transform.position;
        }

        // Will update the player's restart position for when they hit any of the above tags. The checkpoint icon is then disabled.
        if (other.gameObject.tag == "UnderwaterCheckPoint1")
        {
            player.underwaterCheckpointSound.Play();
            checkpointObject1.SetActive(false);

            yield return new WaitForSeconds(2.25f);
            respawnPoint = other.transform.position;
        }

        // Will update the player's restart position for when they hit any of the above tags. The checkpoint icon is then disabled.
        if (other.gameObject.tag == "UnderwaterCheckPoint2")
        {
            player.underwaterCheckpointSound.Play();
            checkpointObject2.SetActive(false);

            yield return new WaitForSeconds(2.25f);
            respawnPoint = other.transform.position;
        }

        // Will update the player's restart position for when they hit any of the above tags. The checkpoint icon is then disabled.
        if (other.gameObject.tag == "UnderwaterCheckPoint3")
        {
            player.underwaterCheckpointSound.Play();
            checkpointObject3.SetActive(false);

            yield return new WaitForSeconds(2.25f);
            respawnPoint = other.transform.position;
        }
    }
}
