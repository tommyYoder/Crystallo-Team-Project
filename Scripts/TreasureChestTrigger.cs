using UnityEngine;
using System.Collections;

public class TreasureChestTrigger : MonoBehaviour {

    public GameObject TreasureChest;
    public AudioSource CoinSound;



    // use this for initialization
    void Start()
    {

    }


    void OnTriggerEnter(Collider other)                            // When player enters collider, then sound will play.
    {
        {
            CoinSound.Play();
        }
    }
    
    void OnTriggerExit()                                          // When player exits collider, then sound will stop.
    {
        {

            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

}


