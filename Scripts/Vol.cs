using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vol : MonoBehaviour {


    void Start()

    {
     

    }




   public void ChangeVol(float newValue)
    {


        float newVol = AudioListener.volume;    // Updates volume when slider is adjusted.


        newVol = newValue;


        AudioListener.volume = newVol;


       }
}

