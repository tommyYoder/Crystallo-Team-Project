using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Settings")]
    public bool lockCursor;
    public float mouseSensitivity = 10;
    public Transform target;
    public float distFromTarget = 2;
    public Vector2 pitchMinMax = new Vector2(-40, 85);

    public float SmoothFactor = 8;
    Vector3 rotationSmoothVelocity;
    Vector3 currentRotation;

    float yaw;
    float pitch;

    public SettingsMenu settingsMenu;
    public SettingsMenu settingsMenuWater;

    //public Transform ballObject, ballCamera;
    //public float speed, turnSpeed;
    //Vector3 forceDirection;

    public GameObject Player;
    private Vector3 Offset;


    float nextTimeToSearch = 0;

    [Header("Collision Vars")]

    [Header("Speeds")]
    public float moveSpeed = 5;                     // The amount of speed when colliding with a wall.
    public float returnSpeed = 9;                   // The amount of speed to return back to the starting camera position.
    public float wallPush = 0.7f;                    // The amount of push from when the camera collides with the wall.

    [Header("Distances")]
    public float closestDistanceToPlayer = 2;       // Looks for the rotation to stop the camera from clipping into the player.
    public float evenCloserDistanceToPlayer = 1;   // Looks to make sure that the camera doesn't clip into the player.

    [Header("Mask")]
    public LayerMask collisionMask;                // Make sure the ray doesn't collide with the player.

    private bool pitchLock = false;

    // Will lock the camera to the player's transform.position when the game starts.
    void Start()
    {
        //offset = transform.position;
        settingsMenu.mouseSlider.value = PlayerPrefs.GetFloat("MouseSensetivity", 15f);
        settingsMenuWater.mouseSlider.value = PlayerPrefs.GetFloat("MouseSensetivity", 15f);
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
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


    //void FixedUpdate()
    //{
    //    // If not null
    //    if (ballObject != null)
    //    {
    //        // Looks for balls position and updates turning when vertical commands are called. RollBall command gets set to true.
    //        transform.position = ballObject.position;
    //        if (Input.GetAxis("Vertical") != 0)
    //        {
    //            RollBall();
    //        }
    //         //calculate ball turning
    //transform.Rotate((Vector3.up * Input.GetAxis("Horizontal") * turnSpeed), Space.World);
    //    }  
    //}


    //void RollBall()                                        
    //{
    //    //set force down camera's look direction
    //    forceDirection = ballCamera.transform.forward;

    //    //remove y force direction for angled camera
    //    forceDirection = new Vector3(forceDirection.x, 0, forceDirection.z);

    //}

    // Looks to see if the player is null, then will do the following conditions afterwards.
    public void LateUpdate()
    {

        if (Player == null)
        {
            Player = GameObject.Find("Player(Clone)");
        }

        // Looks to see how far the camera needs to be from the player. Also allows for WallCheck to be called.
        CollisionCheck(target.position - (transform.forward * distFromTarget));
        WallCheck();

        // Will allow the camera to rotate around the player in the X or Y directions.
        if (!pitchLock)
        {
            yaw += Input.GetAxis("PS4_RightAnalogHorizontal") * mouseSensitivity;
            pitch -= Input.GetAxis("PS4_RightAnalogVertical") * mouseSensitivity;
            yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
            pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
            pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);
            currentRotation = Vector3.Lerp(currentRotation, new Vector3(pitch, yaw), SmoothFactor * Time.deltaTime);
        }

        // Allows for the mouseSensitivity to smoothly rotate around when the mosue is moved.
        else
        {
            yaw += Input.GetAxis("PS4_RightAnalogHorizontal") * mouseSensitivity;
            yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
            pitch = pitchMinMax.y;

            currentRotation = Vector3.Lerp(currentRotation, new Vector3(pitch, yaw), SmoothFactor * Time.deltaTime);
        }


        transform.eulerAngles = currentRotation;

        Vector3 e = transform.eulerAngles;
        e.x = 0;

        target.eulerAngles = e;
    }

    public void ChangeMouseSensetivity(float X, float Y)
    {
        mouseSensitivity = X ;
        mouseSensitivity = Y ;
    }

    // Looks to see if the player has collided with a wall. If yes, then the camera will take its distance and puch towards the player. If not wall, then the camera goes back to the normal.
    private void WallCheck()
    {
        Ray ray = new Ray(target.position, -target.forward);
        RaycastHit hit;

        if (Physics.SphereCast(ray, 0.2f, out hit, 0.5f, collisionMask))
        {
            pitchLock = true;
        }
        else
        {
            pitchLock = false;
        }
    }

    // Allows rays to cast from the camera to the wall to push the camera closer or back to normal distance from the player.
    private void CollisionCheck(Vector3 retPoint)
    {
        RaycastHit hit;

        if (Physics.Linecast(target.position, retPoint, out hit, collisionMask))
        {
            Vector3 norm = hit.normal * wallPush;
            Vector3 p = hit.point + norm;

            // Will see if the camera needs to get closer to the player when colliing with a wall.
            if (Vector3.Distance(Vector3.Lerp(transform.position, p, moveSpeed * Time.deltaTime), target.position) <= evenCloserDistanceToPlayer)
            {

            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, p, moveSpeed * Time.deltaTime);
            }
            return;
        }

        // Returns the camera back to normal is no wall is detected.
        transform.position = Vector3.Lerp(transform.position, retPoint, returnSpeed * Time.deltaTime);
        pitchLock = false;
    }
}

    



