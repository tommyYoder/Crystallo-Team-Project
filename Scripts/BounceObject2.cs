using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceObject2 : MonoBehaviour {

    public bool Move = true;    ///gives you control in inspector to trigger it or not
    public Vector3 MoveVector = Vector3.up; //unity already supplies us with a readonly vector representing up and we are just chaching that into MoveVector
    public float MoveRange = 2.0f; //change this to increase/decrease the distance between the highest and lowest points of the bounce
    public float MoveSpeed = 0.5f; //change this to make it faster or slower

 
     private BounceObject2 bounceObject2; //for caching this transform

    Vector3 startPosition; //used to cache the start position of the transform
    IEnumerator Start()
    {
        yield return new WaitForSeconds(.5f);
        bounceObject2 = this;
        startPosition = bounceObject2.transform.position;
    }
     void Update()
    {
        if (Move) //bool is checked
                  //See if you can work out whats going on here, for your own enjoyment
            bounceObject2.transform.position = startPosition + MoveVector * (MoveRange * Mathf.Sin(Time.timeSinceLevelLoad * MoveSpeed));
        
     }
}
