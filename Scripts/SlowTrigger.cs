using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SlowTrigger : MonoBehaviour {

    public float SpeedDivider = 2;
    
    

    void Start()
    {

    }
  
    void OnTriggerEnter(Collider other)
        
    {

            if (other.transform.tag == "Player")
            {

           
            other.gameObject.GetComponent<Player>().speed /= SpeedDivider;

            }


        }

    

    

    void Update()
    {

    }


    void OnTriggerExit(Collider other)
    {

        if (other.transform.tag == "Player")
        {

            other.gameObject.GetComponent<Player>().speed *= SpeedDivider;

        }

    }

    
}

