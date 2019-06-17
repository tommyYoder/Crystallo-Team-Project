using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameMaster : MonoBehaviour
{
  
    public static GameMaster gm;
   

    void Start()
    {
        if (gm == null)                                                                // Looks for GameManager script.
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
         
        }
    }

    public Transform playerPrefab;
    public Transform spawnPoint;

    public int spawnDelay = 2;



    public IEnumerator RespawnPlayer()
    {

        yield return new WaitForSeconds(spawnDelay);                                 // If player is dead and spawnDelay is true, then player will instantiate at spawn point's transform position and rotation.

        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);

    }


    public static void KillPlayer(Player player)                                     // Will kill player before GM respawns player.
    {
        Destroy(player.gameObject);
        gm.StartCoroutine(gm.RespawnPlayer());
    }
 }




