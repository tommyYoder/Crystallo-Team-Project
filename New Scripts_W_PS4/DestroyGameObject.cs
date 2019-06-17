using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObject : MonoBehaviour
{

    public float timer;

    // Will destroy any gameobject when the timer is met in the inspector.
    void Start()
    {
        Destroy(gameObject, timer);
    }
}
