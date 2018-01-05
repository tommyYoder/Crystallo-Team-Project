using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject Player;
    public Transform target2;
    public Transform target;
    public Transform ballObject, ballCamera;
    public float speed, turnSpeed;
    Vector3 forceDirection;
    private Vector3 offset;

   

   

    float nextTimeToSearch = 0;

    // Use this for initialization
    void Start()                                                    // Looks for cameras transform position to the player's transform position.
    {
        offset = transform.position - Player.transform.position;
      

    }

    void Update()
    {
        if (target == null)                                       // If camera is not equal to the player, then FindPlayer gets called.
        {
            FindPlayer();
            return;
        }
    }
    void FindPlayer()                                           // If time to search is less than or equal to time, then camera will search for Player tag.
    {
        if (nextTimeToSearch <= Time.time)
        {
            GameObject searchResult = GameObject.FindGameObjectWithTag("Player");
            if (searchResult != null)
                target = searchResult.transform;
            nextTimeToSearch = Time.time + 0.5f;

        }
 }
    
            void FixedUpdate()
    {
        // If not null
        if (ballObject != null)                               
        {
            // Looks for balls position and updates turning when vertical commands are called. RollBall command gets set to true.
            transform.position = ballObject.position;
            if (Input.GetAxis("Vertical") != 0)
            {
                RollBall();
            }
            //calculate ball turning
            transform.Rotate((Vector3.up * Input.GetAxis("Horizontal") * turnSpeed), Space.World);

        }
    }
    void RollBall()                                        
    {
        //set force down camera's look direction
        forceDirection = ballCamera.transform.forward;

        //remove y force direction for angled camera
        forceDirection = new Vector3(forceDirection.x, 0, forceDirection.z);

    }

    void LateUpdate()                                      // If Player is null, then camera will look for a player clone's transform position. Camera then offset itself from the Player's position. 
    {

        if (Player == null)
        {
            Player = GameObject.Find("Player(Clone)");
        }
        else
        {
            transform.position = Player.transform.position + offset;
        }
    }
}
    

    



