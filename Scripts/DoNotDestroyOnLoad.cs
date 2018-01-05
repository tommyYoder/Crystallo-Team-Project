using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroyOnLoad : MonoBehaviour
{
    public static Player player;
  
    public int finalScore;
    // Use this for initialization
    void Start()
    {
        if(player == null)
        DontDestroyOnLoad(gameObject);
       
    }
}	
	