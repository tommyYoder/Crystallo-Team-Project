using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FirstSelectedButton : MonoBehaviour
{
    public GameObject firstObject;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(firstObject, null);
    }
}
