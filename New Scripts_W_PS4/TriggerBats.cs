using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBats : MonoBehaviour
{
    public Animator Anim;

    public AudioSource batSound;

  

    // If player enters the collider, then the animation for the bats flying is set to true.
    public IEnumerator OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Anim.SetBool("Move", true);

            yield return new WaitForSeconds(1);
            batSound.Play();
            batSound.volume = 1;

            yield return new WaitForSeconds(.5f);   
            batSound.volume = .75f;

            yield return new WaitForSeconds(.5f);
            batSound.volume = .65f;

            yield return new WaitForSeconds(.5f);
            batSound.volume = .55f;

            yield return new WaitForSeconds(.5f);
            batSound.volume = .45f;

            yield return new WaitForSeconds(.5f);
            batSound.volume = .35f;

            yield return new WaitForSeconds(.5f);
            batSound.volume = .25f;

            yield return new WaitForSeconds(.5f);
            batSound.volume = .15f;

            yield return new WaitForSeconds(.5f);
            batSound.Stop();
            Destroy(gameObject);
        }
    }

}
