using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReSpawnPlayer1 : MonoBehaviour
{

    public Vector3 respawnPoint;

    public Player player;

    public ReSpawnPlayer respawnPlayer;



    // Looks for these gameobject and sets the player's position to the starting position when the level starts.
    void Start()
    {
        respawnPoint = transform.position;
    }

    public void Update()
    {
        // Looks to see if the player is dead. If this is true, then the MoveSpikeBack will start.
        if (player.isDead == true)
        {
            StartCoroutine(MoveSpikeBack());
        }

        // Looks to see if the respawnpoint hitcheckpoint is true. If yes, then the spikes transform updates to the new transform position.
        if (respawnPlayer.hitCheckpoint == true)
        {
            respawnPoint = transform.position;
        }

        // Looks to see if the respawnpoint hitcheckpoint1 is true. If yes, then the spikes transform updates to the new transform position.
        if (respawnPlayer.hitCheckpoint1 == true)
        {
            respawnPoint = transform.position;
        }

        // Looks to see if the respawnpoint hitcheckpoint2 is true. If yes, then the spikes transform updates to the new transform position.
        if (respawnPlayer.hitCheckpoint2 == true)
        {
            respawnPoint = transform.position;
        }

        // Looks to see if the respawnpoint hitcheckpoint3 is true. If yes, then the spikes transform updates to the new transform position.
        if (respawnPlayer.hitCheckpoint3 == true)
        {
            respawnPoint = transform.position;
        }
    }

    // Will wait for 2 seconds before sending the spikes back to the respawn transformation point that was saved,
    public IEnumerator MoveSpikeBack()
    {
        yield return new WaitForSeconds(2);
        transform.position = respawnPoint;
    }
}
