using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Underwater : MonoBehaviour {

    public bool isUnderwater = false;
    public Color normalColor;
    public Color underwaterColor;
    public GameObject Bubbles;
    public Player player;

	// Use this for initialization
	void Start () {
        normalColor = new Color(0.5f, 0.5f, 0.5f, 0.5f);
        underwaterColor = new Color(0.22f, 0.65f, 0.77f, 0.5f);
        Bubbles.SetActive(false);
    }
    // Sets water fog to blue tint and player's jump height to 60.
    public void OnTriggerEnter(Collider other)
    {
    if(other.gameObject.tag == "Player")
        {
            SetUnderwater();
            Bubbles.SetActive(true);
            player.jumpHeight = 60f;
        }
    }
    // Sets fog to normal grey tint and player's jump height to 90.
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SetNormal();
            Bubbles.SetActive(false);
            player.jumpHeight = 90f;
        }
    }

    // Allows render setting to be normal grey fog color.
    public void SetNormal()
    {
        RenderSettings.fogColor = normalColor;
        RenderSettings.fogDensity = 0.001f;
    }

    // Allows render setting to be blue fog color.
    public void SetUnderwater()
    {
        RenderSettings.fogColor = underwaterColor;
        RenderSettings.fogDensity = 0.20f;
    }
  
}
