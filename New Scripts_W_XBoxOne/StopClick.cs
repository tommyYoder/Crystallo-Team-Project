using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopClick : MonoBehaviour
{

    public GameObject clickSound;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        clickSound.SetActive(false);

        yield return new WaitForSeconds(.5f);

        clickSound.SetActive(true);
    }
}
