using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPlayer : MonoBehaviour
{
    public MonoBehaviour[] disableScripts;

    protected virtual void ToggleScript(bool value)
    {
        foreach(var scripts in disableScripts)
        {
            scripts.enabled = value;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            ToggleScript(false);
        }
    }
}
