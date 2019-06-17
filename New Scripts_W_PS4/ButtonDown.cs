using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDown : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject secondCamera;

    public MonoBehaviour[] disableScripts;

    public BounceObject bounceMine;

    public GameObject showText;

    public Player player;


    public Animator buttonAnim;
    public Animator buttonAnim1;
    public AudioSource buttonDownSound;
    public AudioSource openSound;
    public Collider buttonObject;
    public Collider buttonObject1;
    public Animator door;
    public Animator door1;
    public Collider triggerBats;
    public AudioSource batSound;

    public AudioSource mineSound;
   

    public GameObject dustParticle;
    public GameObject dustParticle1;

    public bool button1 = false;
    public bool button2 = false;

    // Use this for initialization
    void Start()
    {
        triggerBats.GetComponent<Collider>().enabled = false;      // TriggerBat's collider is set to false.

        button1 = false;                                           // Button1 is set to false.

        button2 = false;

        mainCamera.SetActive(true);
        secondCamera.SetActive(false);
        dustParticle.SetActive(false);
        dustParticle1.SetActive(false);
    }

    public IEnumerator OnTriggerEnter(Collider other)
    {
        // Looks to see if button is pressed. If yes, then animation is played along with other commands.
        if (other.gameObject.tag == "Button")
        {
            buttonAnim.SetTrigger("Down");
            button1 = true;
            buttonObject.GetComponent<Collider>().enabled = false;
            ButtonTrigger();
            buttonDownSound.Play();
           


            yield return new WaitForSeconds(1f);
            mainCamera.SetActive(false);
            secondCamera.SetActive(true);
            ToggleScripts(false);
            mineSound.Stop();
            mineSound.loop = false;
            player.rb.drag = 25;

            yield return new WaitForSeconds(1f);
            door.SetBool("Door", true);
            openSound.Play();
            dustParticle.SetActive(true);
          

            yield return new WaitForSeconds(4f);
            mainCamera.SetActive(true);
            secondCamera.SetActive(false);
            ToggleScripts(true);
            player.rb.drag = .1f;
            Destroy(dustParticle);
            mineSound.Play();
            mineSound.loop = true;
        } 

        // Looks to see if button1 is pressed. If yes, then animation is played along with other commands.
        if (other.gameObject.tag == "Button1")
        {
            buttonAnim1.SetTrigger("Down");
            button2 = true;          
            buttonObject1.GetComponent<Collider>().enabled = false;
            ButtonTrigger();
            buttonDownSound.Play();
            bounceMine.Move = false;
           

            yield return new WaitForSeconds(1f);
            mineSound.Stop();
            mineSound.loop = false;
            mainCamera.SetActive(false);
            secondCamera.SetActive(true);
            ToggleScripts(false);
            player.rb.drag = 25;

            yield return new WaitForSeconds(1f);
            door1.SetBool("Door 1", true);
            openSound.Play();
            dustParticle1.SetActive(true);

            yield return new WaitForSeconds(4f);
            mainCamera.SetActive(true);
            secondCamera.SetActive(false);
            ToggleScripts(true);          
            player.rb.drag = .1f;
            Destroy(dustParticle1);
            mineSound.Play();
            mineSound.loop = true;

            yield return new WaitForSeconds(.25f);
            bounceMine.Move = true;
        }
    }

    protected virtual void ToggleScripts(bool value)
    {
        foreach (var scripts in disableScripts)
        {
            scripts.enabled = value;
        }
    }

    // If both buttons are down. then the triggerBat's collider is set to true.
    public void ButtonTrigger()
        {
            if (button1 == true && button2 == true)
            {
            triggerBats.GetComponent<Collider>().enabled = true;
            batSound.Stop();
            Destroy(showText);
           
        }
    }
}