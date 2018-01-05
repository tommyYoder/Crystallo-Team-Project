using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTrigger : MonoBehaviour
{
    public GameObject wall;
    private Vector3 startPos;
    private Vector3 endPos;
    private float distance = 8f;
    private float lerpTime = 8;
    private float currentLerpTime = 0;


    // Use this for initialization
    void Start()
    {
        startPos = wall.transform.position;
        endPos = wall.transform.position + Vector3.up * distance;
    }

    // Update is called once per frame
    void Update()
    {

         currentLerpTime += Time.deltaTime;

      if (currentLerpTime >= lerpTime)
        {
            currentLerpTime = lerpTime;
        }

        float Perc = currentLerpTime /lerpTime;
        wall.transform.position = Vector3.Lerp(startPos, endPos, Perc);
    }
}
